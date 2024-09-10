using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGreenway.Models;

[Table("T_GRW_MEASUREMENT")]
public class Measurement
{
    [Key]
    public int id_measurement { get; set; }


    public required string ds_name { get; set; }
    public required string tx_description { get; set; }
    public required DateTime dt_created_at { get; set; } = DateTime.Now;
    public DateTime dt_updated_at { get; set; }
    public DateTime dt_finished_at { get; set; }

    // Relationships
    public required int id_measurement_type { get; set; }
    public required int id_improvement_measurement { get; set; }
    public required int id_sustainable_goal { get; set; }
}
