using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGreenway.Models;

[Table("T_GRW_PRODUCT_TYPE")]
public class ProductType
{
    [Key]
    public int id_product_type { get; set; }


    public required string ds_name { get; set; }
    public required string tx_description { get; set; }
    public required DateTime dt_created_at { get; set; } = DateTime.Now;
    public DateTime dt_updated_at { get; set; }
    public DateTime dt_finished_at { get; set; }
}
