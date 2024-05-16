using GreenwayApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreenwayApi.Controllers;

public class CompanyController : Controller
{
	//Lista de carro para simular o banco de dados
	private static List<Company> _lista = new List<Company>();
	private static int _id = 0; //Controla o ID

	// GET: CompanyController/Details/5
	[HttpGet]
	public ActionResult Details(int id)
	{
		return View();
	}

	// GET: CompanyController/Create
	[HttpGet]
	public IActionResult Cadastrar()
	{
		return View();
	}

	[HttpPost]
	public IActionResult Cadastrar(Company company)
	{
		//Setar o código do game
		company.id_company = ++_id;
		//Adicionar o game na lista
		_lista.Add(company);
		//Mandar uma mensagem de sucesso para a view
		TempData["msg"] = "Empresa cadastrada com sucesso!";
		//Redireciona para o método Cadastrar
		return RedirectToAction("Cadastrar");
	}

	// Read
	public IActionResult Index()
	{
		//Enviar a lista de game para a view
		return View(_lista);
	}

	// Update
	[HttpGet] //Abrir o formulário com os dados preenchidos
	public IActionResult Editar(int id)
	{
		//Recuperar a posição do game na lista através do id
		var index = _lista.FindIndex(c => c.id_company == id);
		//Recuperar o game através do ID
		var game = _lista[index];
		//Enviar o game para a view
		return View(game);
	}

	[HttpPost]
	public IActionResult Editar(Company company)
	{
		//Atualizar o game na lista
		var index = _lista.FindIndex(c => c.id_company == company.id_company);
		//Substitui o objeto na posição do game antigo
		_lista[index] = company;
		//Mensagem de sucesso
		TempData["msg"] = "Empresa atualizada com sucesso!";
		//Redirect para a listagem/editar
		return RedirectToAction("editar");
	}

	// Remove 
	[HttpPost]
	public IActionResult Remover(int id)
	{
		//Remover o game da lista
		_lista.RemoveAt(_lista.FindIndex(c => c.id_company == id));
		//Mensagem de sucesso
		TempData["msg"] = "Empresa removida com sucesso!";
		//Redirecionar para a listagem
		return RedirectToAction("Index");
	}
}
