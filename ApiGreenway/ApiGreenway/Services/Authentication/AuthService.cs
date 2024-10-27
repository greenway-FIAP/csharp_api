﻿using ApiGreenway.Data;
using ApiGreenway.Models;
using ApiGreenway.Models.Dtos;
using FirebaseAdmin.Auth;
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
        /// <inheritdoc/>
        public async Task<string> LoginAsync(UserLoginDTO request)
        {
            if (request == null || string.IsNullOrEmpty(request.ds_email) || string.IsNullOrEmpty(request.ds_password))
            {
                return "E-mail ou senha inválidos!";
            }

            // Cria um objeto com as credenciais do usuário
            var credentials = new
            {
                request.ds_email,
                request.ds_password,
                returnSecureToken = true,
            };

            // Envia uma solicitação POST para autenticar o usuário
            var response = await _httpClient.PostAsJsonAsync(_httpClient.BaseAddress, credentials);

            var authFirebaseObject = await response.Content.ReadFromJsonAsync<AuthFirebase>();
            return authFirebaseObject!.IdToken!;
        }

        /// <inheritdoc/>
        public async Task<string> RegisterAsync(UserRegisterDTO request)
        {
            try
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
                return "Usuário cadastrado com sucesso! \n ID do usuário (BD): " + newUser.id_user + " \n Uid (FB): " + newUserDb.Uid;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao registrar usuário: " + ex.Message, ex);
            }
        }

        // Método para atualizar os dados de um usuário existente
        /// <inheritdoc/>
        public async Task<string> UpdateUserByEmailAsync(string oldEmail, UserUpdateDto request)
        {
            try
            {
                // Busca o usuário no banco de dados pelo ID
                var userDb = await _dbContext.Users.FirstOrDefaultAsync(r => r.ds_email == oldEmail && r.dt_finished_at == null)
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
                await FirebaseAuth.DefaultInstance.UpdateUserAsync(userArgs);

                // Atualiza o usuário no banco de dados
                userDb.ds_email = request.ds_email; // Atualiza o e-mail no banco de dados
                if (request.ds_password != null)
                {
                    userDb.ds_password = BCrypt.Net.BCrypt.HashPassword(request.ds_password); // Atualiza a senha no banco de dados (se fornecida)
                }
                userDb.dt_updated_at = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(-3)); // Insere a data de atualização do dado no formato UTC-3 Brasília

                // Salva as alterações no banco de dados
                await _dbContext.SaveChangesAsync();

                return "Usuário atualizado com sucesso!";
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar usuário: " + ex.Message, ex);
            }
        }

        // Método para desativar um usuário
        /// <inheritdoc/>
        public async Task<string> DeleteAsync(int userId)
        {
            try
            {
                var userDb = await _dbContext.Users.FirstOrDefaultAsync(r => r.id_user == userId);
                if (userDb != null)
                {
                    var uidFirebase = userDb.ds_uid_fb;

                    if (string.IsNullOrEmpty(uidFirebase))
                    {
                        throw new Exception("UID do Firebase não encontrado.");
                    }

                    userDb.dt_finished_at = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(-3));

                    await _dbContext.SaveChangesAsync();

                    var userArgs = new UserRecordArgs
                    {
                        Uid = uidFirebase,
                        Disabled = true,
                    };

                    await FirebaseAuth.DefaultInstance.UpdateUserAsync(userArgs);
                    
                    return "Usuário desativado com sucesso";
                }
                else
                {
                    throw new Exception("Usuário não encontrado.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao desativar o usuário: " + ex.Message, ex);
            }
        }
    }
}