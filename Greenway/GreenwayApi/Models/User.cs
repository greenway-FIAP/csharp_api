namespace GreenwayApi.Models;

public class User
{
	public int id_user { get; set; }
	public string? ds_email { get; set; }
	public string? password { get; set; }
	public DateTime dt_created_at { get; set; } = DateTime.Now;
	public DateTime dt_updated_at { get; set; } = DateTime.Now;
	public DateTime dt_finished_at { get; set; } = DateTime.Now;
}
