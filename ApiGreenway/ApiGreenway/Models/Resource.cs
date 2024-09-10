using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGreenway.Models;

[Table("T_GRW_RESOURCE")]
public class Resource
{
    [Key]
    public int id_resource { get; set; }


    public required string ds_name { get; set; }
    public required string tx_description { get; set; }
    public required double vl_cost_per_unity { get; set; }
    public required string ds_unit_of_measurement { get; set; }
    public required double nr_availability { get; set; }
    public required DateTime dt_created_at { get; set; } = DateTime.Now;
    public DateTime dt_updated_at { get; set; }
    public DateTime dt_finished_at { get; set; }

    // Relationships
    public required int id_resource_type { get; set; }
}
