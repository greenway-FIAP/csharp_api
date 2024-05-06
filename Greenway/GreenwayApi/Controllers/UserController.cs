using GreenwayApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GreenwayApi.Controllers;

public class UserController : Controller
{
	//Lista de Empresa para simular o banco de dados
	private static List<User> _lista = new List<User>();
	private static int _id = 0; //Controla o ID

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
		_lista[index] = user;
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
