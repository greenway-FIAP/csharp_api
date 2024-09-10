using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGreenway.Models;

[Table("T_GRW_SECTOR")]
public class Sector
{
    [Key]
    public int id_sector { get; set; }


    public required string ds_name { get; set; }
    public required string tx_description { get; set; }
    public required DateTime dt_created_at { get; set; } = DateTime.Now;
    public DateTime dt_updated_at { get; set; }
    public DateTime dt_finished_at { get; set; }
}
