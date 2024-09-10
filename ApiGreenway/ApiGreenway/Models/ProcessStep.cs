using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGreenway.Models;

[Table("T_GRW_PROCESS_STEP")]
public class ProcessStep
{
    [Key]
    public int id_process_step { get; set; }


    public required DateTime dt_created_at { get; set; } = DateTime.Now;
    public DateTime dt_updated_at { get; set; }
    public DateTime dt_finished_at { get; set; }


    // Relationships
    public required int id_step { get; set; }
    public required int id_process { get; set; }
}
