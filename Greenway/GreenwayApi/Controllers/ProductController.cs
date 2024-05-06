﻿using GreenwayApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GreenwayApi.Controllers;

public class ProductController : Controller
{
	//Lista de Empresa para simular o banco de dados
	private static List<Product> _lista = new List<Product>();
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
	public IActionResult Cadastrar(Product product)
	{
		//Setar o código do product
		product.id_product = ++_id;
		//Adicionar o product na lista
		_lista.Add(product);
		//Mandar uma mensagem de sucesso para a view
		TempData["msg"] = "Produto cadastrado com sucesso!";
		//Redireciona para o método Cadastrar
		return RedirectToAction("Cadastrar");
	}

	// Read
	public IActionResult Index()
	{
		//Enviar a lista de product para a view
		return View(_lista);
	}

	// Update
	[HttpGet] //Abrir o formulário com os dados preenchidos
	public IActionResult Editar(int id)
	{
		//Recuperar a posição do product na lista através do id
		var index = _lista.FindIndex(c => c.id_product == id);
		//Recuperar o product através do ID
		var user = _lista[index];
		//Enviar o product para a view
		return View(user);
	}

	[HttpPost]
	public IActionResult Editar(Product product)
	{
		//Atualizar o product na lista
		var index = _lista.FindIndex(c => c.id_product == product.id_product);
		//Substitui o objeto na posição do product antigo
		_lista[index] = product;
		//Mensagem de sucesso
		TempData["msg"] = "Produto atualizado com sucesso!";
		//Redirect para a listagem/editar
		return RedirectToAction("editar");
	}

	// Remove 
	[HttpPost]
	public IActionResult Remover(int id)
	{
		//Remover o product da lista
		_lista.RemoveAt(_lista.FindIndex(c => c.id_product == id));
		//Mensagem de sucesso
		TempData["msg"] = "Produto removido com sucesso!";
		//Redirecionar para a listagem
		return RedirectToAction("Index");
	}
}