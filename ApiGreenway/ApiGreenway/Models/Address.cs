using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGreenway.Models;

[Table("T_GRW_ADDRESS")]
public class Address
{
    [Key]
    public int id_address { get; set; }


    public required string ds_street { get; set; }
    public required string ds_zip_code { get; set; }
    public required string ds_number { get; set; }
    public required string ds_uf { get; set; }
    public required string ds_neighborhood { get; set; }
    public required string ds_city { get; set; }
    public DateTime dt_created_at { get; set; } = DateTime.UtcNow;
    public DateTime? dt_updated_at { get; set; }
    public DateTime? dt_finished_at { get; set; }

    // Relationships
    public required int id_company { get; set; }
}
