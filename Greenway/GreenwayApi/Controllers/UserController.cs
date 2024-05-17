using GreenwayApi.Models;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GreenwayApi.Controllers;

public class UserController : Controller
{
	//Lista de Empresa para simular o banco de dados
	private static List<User> _lista = new List<User>();
	private static int _id = 0; // Controla o ID

    [HttpGet] //Abrir o formulário com os dados preenchidos
    public IActionResult PesquisaNome(string searchString)
    {
        if (string.IsNullOrEmpty(searchString))
        {
            // Se a string de pesquisa estiver vazia, redireciona para a lista de jogos
            return RedirectToAction("Index");
        }

        // Procura jogos que correspondam ao termo de pesquisa (insensível a maiúsculas e minúsculas)
        var users = _lista.Where(c => c.ds_email!.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();

        if (users.Count == 0)
        {
            // Caso nenhum jogo for encontrado
            TempData["msg"] = "Nenhum Usuário Encontrado(a)!!";
            return RedirectToAction("Index");
        }

        // Se os jogos forem encontrados, envie-os para a visualização de índice
        return View("Index", users);
    }

    // GET: UserController/Details/5
    [HttpGet]
	public ActionResult Details(int id)
	{
		return View();
	}

	// GET: UserController/Create
	[HttpGet]
	public IActionResult Cadastrar()
	{
		return View();
	}

	[HttpPost]
	public IActionResult Cadastrar(User user)
	{
		if (_lista.Any(c => c.ds_email == user.ds_email))
		{
			TempData["msg"] = "E-mail já cadastrado!";
			return View();
		}

		//Setar o código do user
		user.id_user = ++_id;
		//Adicionar o user na lista
		_lista.Add(user);
		//Mandar uma mensagem de sucesso para a view
		TempData["msg"] = "Usuário cadastrado com sucesso!";
		//Redireciona para o método Cadastrar
		return RedirectToAction("Cadastrar");
	}

	// Read
	public IActionResult Index()
	{
		//Enviar a lista de user para a view
		return View(_lista);
	}

	// Update
	[HttpGet] //Abrir o formulário com os dados preenchidos
	public IActionResult Editar(int id)
	{
		//Recuperar a posição do user na lista através do id
		var index = _lista.FindIndex(c => c.id_user == id);
		//Recuperar o user através do ID
		var user = _lista[index];
		//Enviar o user para a view
		return View(user);
	}

	[HttpPost]
	public IActionResult Editar(User user)
	{
		//Atualizar o user na lista
		var index = _lista.FindIndex(c => c.id_user == user.id_user);
        //Substitui o objeto na posição do user antigo
        if (index != -1)
        {
            _lista[index].dt_updated_at = DateTime.Now;

            _lista[index].ds_email = user.ds_email;
            _lista[index].password = user.password;
            _lista[index].dt_finished_at = user.dt_finished_at;
        }

        //Mensagem de sucesso
        TempData["msg"] = "Usuário atualizado com sucesso!";
		//Redirect para a listagem/editar
		return RedirectToAction("editar");
	}

	// Remove 
	[HttpPost]
	public IActionResult Remover(int id)
	{
		//Remover o user da lista
		_lista.RemoveAt(_lista.FindIndex(c => c.id_user == id));
		//Mensagem de sucesso
		TempData["msg"] = "Usuário removido com sucesso!";
		//Redirecionar para a listagem
		return RedirectToAction("Index");
	}
}
