using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGreenway.Models;

[Table("T_GRW_COMPANY_REPRESENTATIVE")]
public class CompanyRepresentative
{
    [Key]
    public int id_company_representative { get; set; }


    public required string nr_phone { get; set; }
    public required string ds_role { get; set; }
    public required string ds_name { get; set; }
    public required DateTime dt_created_at { get; set; } = DateTime.Now;
    public DateTime dt_updated_at { get; set; }
    public DateTime dt_finished_at { get; set; }

    // Relationships
    public required int id_user { get; set; }
    public required int id_company { get; set; }

}
