using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApiGreenway.Enums;

namespace ApiGreenway.Models;

[Table("T_GRW_BADGE")]
public class Badge
{
    [Key]
    public int id_badge { get; set; }


    public required string ds_name { get; set; }
    public required string tx_description { get; set; }
    public required string ds_criteria { get; set; }
    public required StatusProcess st_badge { get; set; }
    public required string url_image { get; set; }

    // Relationships
    public required int id_badge_level { get; set; }
    public required int id_sustainable_goal { get; set; }
}
