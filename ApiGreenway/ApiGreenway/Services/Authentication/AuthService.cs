using ApiGreenway.Data;
using ApiGreenway.Models;
using ApiGreenway.Models.Dtos;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ApiGreenway.Services.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient; // Cliente HTTP para chamadas à API
        private readonly dbContext _dbContext; // Contexto do banco de dados para operações com usuários

        // Construtor que recebe o HttpClient e o dbContext
        public AuthService(HttpClient httpClient, dbContext dbContext)
        {
            _httpClient = httpClient;
            _dbContext = dbContext;
        }

        // Método para autenticar um usuário e retornar um token
        public async Task<string> LoginAsync(UserLoginDTO request)
        {
            // Cria um objeto com as credenciais do usuário
            var credentials = new
            {
                request.ds_email,
                request.ds_password,
                returnSecureToken = true, // Solicita um token de autenticação
            };

            // Envia uma solicitação POST para autenticar o usuário
            var response = await _httpClient.PostAsJsonAsync("", credentials);

            // Lê a resposta como um objeto AuthFirebase
            var authFirebaseObject = await response.Content.ReadFromJsonAsync<AuthFirebase>();

            // Retorna o token de autenticação
            return authFirebaseObject!.IdToken!;
        }

        public async Task<string> RegisterAsync(UserRegisterDTO request)
        {
            // Valida os dados de entrada
            if (request == null || string.IsNullOrEmpty(request.ds_email) || string.IsNullOrEmpty(request.ds_password))
            {
                throw new ArgumentException("E-mail e senha são obrigatórios.");
            }

            // Prepara os argumentos para criar um novo usuário no Firebase
            var userArgs = new UserRecordArgs
            {
                Email = request.ds_email,
                Password = request.ds_password, // Usamos a senha sem criptografar, pois o Firebase lida com isso.
                Disabled = false
            };

            // Cria o usuário no Firebase
            var newUserDb = await FirebaseAuth.DefaultInstance.CreateUserAsync(userArgs);

            // Cria um novo objeto User para o banco de dados
            var newUser = new User
            {
                ds_email = newUserDb.Email,
                ds_password = BCrypt.Net.BCrypt.HashPassword(request.ds_password), // Criptografa a senha para o banco de dados
                ds_uid_fb = newUserDb.Uid, // Salva o UID do Firebase
                id_user_type = request.id_user_type,
                id_company_representative = request.id_company_representative,
            };

            // Adiciona o novo usuário ao banco de dados
            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync(); // Salva as mudanças

            // Retorna o Uid do novo usuário
            return newUserDb.Uid;
        }

        // Método para atualizar os dados de um usuário existente
        public async Task<string> UpdateUserByEmailAsync(string oldEmail, UserUpdateDto request)
        {
            try
            {
                // Busca o usuário no banco de dados pelo ID
                var userDb = await _dbContext.Users.FirstOrDefaultAsync(u => u.ds_email == oldEmail && u.ds_uid_fb != null && u.dt_finished_at == null)
                    ?? throw new Exception("Usuário não encontrado");

                // Prepara os argumentos para atualizar o usuário no Firebase
                var userArgs = new UserRecordArgs
                {
                    Uid = userDb.ds_uid_fb, // Use o UID armazenado
                    Email = request.ds_email, // Novo e-mail
                    // Atualiza a senha se for fornecida
                    Password = request.ds_password != null ? BCrypt.Net.BCrypt.HashPassword(request.ds_password) : null,
                };

                // Atualiza o usuário no Firebase
                var updateUserDb = await FirebaseAuth.DefaultInstance.UpdateUserAsync(userArgs);

                // Atualiza o usuário no banco de dados
                userDb.ds_email = request.ds_email; // Atualiza o e-mail no banco de dados
                if (request.ds_password != null)
                {
                    userDb.ds_password = BCrypt.Net.BCrypt.HashPassword(request.ds_password);
                }
                userDb.dt_updated_at = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(-3)); // UTC-3 Brasília

                // Salva as alterações no banco de dados
                _dbContext.Users.Update(userDb);
                await _dbContext.SaveChangesAsync();

                return updateUserDb.Uid;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar usuário: " + ex.Message, ex);
            }
        }

        public async void DeleteAsync(int userId)
        {
            // Busca o usuário no banco de dados pelo ID
            var userDb = await _dbContext.Users.FirstOrDefaultAsync(r => r.id_user == userId && r.ds_uid_fb != null && r.dt_finished_at == null);

            // Verifica se o usuário existe
            if (userDb == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            // Prepara os argumentos para desativar o usuário no Firebase
            var userArgs = new UserRecordArgs
            {
                Uid = userDb.ds_uid_fb, // UID correto do Firebase
                Disabled = true, // Marca o usuário como desativado
            };

            // Atualiza o usuário no Firebase
            await FirebaseAuth.DefaultInstance.UpdateUserAsync(userArgs);

            // Marca o usuário como desativado no banco de dados
            userDb.dt_finished_at = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(-3)); // UTC-3 Brasília

            // Salva as mudanças no banco de dados
            await _dbContext.SaveChangesAsync();
        }
    }
}