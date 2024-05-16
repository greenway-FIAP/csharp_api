using Microsoft.AspNetCore.Mvc;

namespace GreenwayApi.Models;

public class Product
{
    [HiddenInput]
    public int id_product { get; set; }
	public string? ds_name { get; set; }
	public string? tx_description { get; set; }
	public decimal? vl_sale_price { get; set; }
	public decimal? vl_cost_price { get; set; }
	public decimal? nr_weight { get; set; }
	public DateTime dt_created_at { get; set; } = DateTime.Now;
	public DateTime dt_updated_at { get; set; } = DateTime.Now;
	public DateTime dt_finished_at { get; set; } = DateTime.Now;
}
