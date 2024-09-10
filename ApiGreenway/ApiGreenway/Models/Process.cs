using ApiGreenway.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGreenway.Models;

[Table("T_GRW_PROCESS")]
public class Process
{
    [Key]
    public int id_process { get; set; }

    public required string ds_name { get; set; }
    public StatusProcess st_process { get; set; }
    public required int nr_priority { get; set; }
    public required DateOnly dt_start { get; set; }
    public required DateOnly dt_end { get; set; }
    public required string tx_description { get; set; }
    public string tx_comments { get; set; }
    public required DateTime dt_created_at { get; set; } = DateTime.Now;
    public DateTime dt_updated_at { get; set; }
    public DateTime dt_finished_at { get; set; }

    // Relationships
    public required int id_company { get; set; }
    public required int id_company_representative { get; set; }

}
