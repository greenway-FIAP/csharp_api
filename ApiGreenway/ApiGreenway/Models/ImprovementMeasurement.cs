using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGreenway.Models;

[Table("T_GRW_IMPROVEMENT_MEASUREMENT")]
public class ImprovementMeasurement
{
    [Key]
    public int id_improvement_measurement { get; set; }


    public required DateTime dt_created_at { get; set; }
    public DateTime dt_updated_at { get; set; }
    public DateTime dt_finished_at { get; set; }

    // Relationships
    public required int id_sustainable_improvement_actions { get; set; }

}
