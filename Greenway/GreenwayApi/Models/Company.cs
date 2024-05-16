using Microsoft.AspNetCore.Mvc;

namespace GreenwayApi.Models;

public class Company
{
	[HiddenInput]
	public int id_company { get; set; }
	public string? ds_name { get; set; }
	public string? tx_description { get; set; }
	public decimal? vl_current_revenue { get; set; }
	public int nr_size { get; set; }
	public string? nr_cnpj { get; set; }
	public DateTime dt_created_at { get; set; } = DateTime.Now;
	public DateTime dt_updated_at { get; set; } = DateTime.Now;
	public DateTime dt_finished_at { get; set; } = DateTime.Now;
}
