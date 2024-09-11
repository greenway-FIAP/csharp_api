using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGreenway.Models;


[Table("T_GRW_MEASUREMENT_PROCESS_STEP")]
public class MeasurementProcessStep
{
    [Key]
    public int id_measurement_process_step { get; set; }

    public required double nr_result { get; set; }
    public required DateTime dt_created_at { get; set; }
    public DateTime dt_updated_at { get; set; }
    public DateTime dt_finished_at { get; set; }

    // Relationships
    public required int id_measurement { get; set; }
    public required int id_process_step { get; set; }
}
