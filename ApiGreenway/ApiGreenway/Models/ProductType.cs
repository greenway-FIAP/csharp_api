﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiGreenway.Models;

[Table("T_GRW_PRODUCT_TYPE")]
public class ProductType
{
    [Key]
    public int id_product_type { get; set; }


    public required string ds_name { get; set; }
    public required string tx_description { get; set; }

    public DateTimeOffset dt_created_at { get; set; } = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(-3)); // UTC-3 Brasília

    public DateTimeOffset? dt_updated_at { get; set; }

    public DateTimeOffset? dt_finished_at { get; set; }
}
