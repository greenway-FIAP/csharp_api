using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGreenway.Models;

[Table("T_GRW_USER")]
public class User
{
    [Key]
    public int id_user { get; set; }


    public required string ds_email { get; set; }
    public required string ds_password { get; set; }
    public required DateTime dt_created_at { get; set; } = DateTime.Now;
    public DateTime dt_updated_at { get; set; }
    public DateTime dt_finished_at { get; set; }

    // Relationships
    public required int id_user_type { get; set; }
    public required int id_company_representative { get; set; }
}
