using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGreenway.Models;

[Table("T_GRW_COMPANY")]
public class Company
{
    [Key]
    public int id_company { get; set; }


    public required string ds_name { get; set; }
    public required string tx_description { get; set; }
    public required double vl_current_revenue { get; set; }
    public required int nr_size { get; set; }
    public required int nr_cnpj { get; set; }
    public required DateTime dt_created_at { get; set; } = DateTime.Now;
    public DateTime dt_updated_at { get; set; }
    public DateTime dt_finished_at { get; set; }

    // Relationships
    public required int id_sector { get; set; }
    public required int id_address { get; set; }

}
