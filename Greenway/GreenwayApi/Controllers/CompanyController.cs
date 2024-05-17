using GreenwayApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GreenwayApi.Controllers;

public class CompanyController : Controller
{
	//Lista de Empresa para simular o banco de dados
	private static List<Company> _lista = new List<Company>();
	private static int _id = 0; //Controla o ID

    [HttpGet] //Abrir o formulário com os dados preenchidos
    public IActionResult PesquisaNome(string searchString)
    {
        if (string.IsNullOrEmpty(searchString))
        {
            // Se a string de pesquisa estiver vazia, redireciona para a lista de jogos
            return RedirectToAction("Index");
        }

        // Procura jogos que correspondam ao termo de pesquisa (insensível a maiúsculas e minúsculas)
        var companies = _lista.Where(c => c.ds_name!.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();

        if (companies.Count == 0)
        {
            // Caso nenhum jogo for encontrado
            TempData["msg"] = "Nenhuma Empresa Encontrada!!";
            return RedirectToAction("Index");
        }

        // Se os jogos forem encontrados, envie-os para a visualização de índice
        return View("Index", companies);
    }

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
        // Verificar se o CNPJ já está cadastrado
        if (_lista.Any(c => c.nr_cnpj == company.nr_cnpj))
        {
            TempData["msg"] = "CNPJ já cadastrado!";
            return View();
        }

        // Setar o código da empresa
        company.id_company = ++_id;
        // Adicionar a empresa na lista
        _lista.Add(company);
        // Mandar uma mensagem de sucesso para a view
        TempData["msg"] = "Empresa cadastrada com sucesso!";
        // Redireciona para o método Cadastrar
        return RedirectToAction("Cadastrar");
    }

	// Read
	public IActionResult Index()
	{
        //Enviar a lista de company para a view
        return View(_lista);
	}

	// Update
	[HttpGet] //Abrir o formulário com os dados preenchidos
	public IActionResult Editar(int id)
	{
        //Recuperar a posição do company na lista através do id
        var index = _lista.FindIndex(c => c.id_company == id);
        //Recuperar o company através do ID
        var company = _lista[index];
        //Enviar o company para a view
        return View(company);
	}

	[HttpPost]
	public IActionResult Editar(Company company)
	{
		//Atualizar o greenway na lista
		var index = _lista.FindIndex(c => c.id_company == company.id_company);
        //Substitui o objeto na posição do greenway antigo
        if (index != -1)
        {
            // Atualizar a data dt_updated_at
            _lista[index].dt_updated_at = DateTime.Now;

            // Atualizar outras propriedades conforme necessário
            _lista[index].ds_name = company.ds_name;
            _lista[index].tx_description = company.tx_description;
            _lista[index].vl_current_revenue = company.vl_current_revenue;
            _lista[index].nr_size = company.nr_size;
            _lista[index].nr_cnpj = company.nr_cnpj;
            _lista[index].dt_finished_at = company.dt_finished_at;
        }
        //Mensagem de sucesso
        TempData["msg"] = "Empresa atualizada com sucesso!";
		//Redirect para a listagem/editar
		return RedirectToAction("editar");
	}

	// Remove 
	[HttpPost]
	public IActionResult Remover(int id)
	{
		//Remover o greenway da lista
		_lista.RemoveAt(_lista.FindIndex(c => c.id_company == id));
		//Mensagem de sucesso
		TempData["msg"] = "Empresa removida com sucesso!";
		//Redirecionar para a listagem
		return RedirectToAction("Index");
	}
}
