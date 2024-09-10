using ApiGreenway.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGreenway.Models;

[Table("T_GRW_STEP")]
public class Step
{
    [Key]
    public int id_step { get; set; }


    public required string ds_name { get; set; }
    public required string tx_description { get; set; }
    public required double nr_estimated_time { get; set; }
    public required StatusProcess st_step { get; set; }
    public DateOnly dt_start { get; set; }
    public DateOnly dt_end { get; set; }
    public required DateTime dt_created_at { get; set; } = DateTime.Now;
    public DateTime dt_updated_at { get; set; }
    public DateTime dt_finished_at { get; set; }
}
