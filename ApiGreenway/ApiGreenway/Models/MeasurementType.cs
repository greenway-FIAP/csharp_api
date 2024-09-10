﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGreenway.Models;


[Table("T_GRW_MEASUREMENT_TYPE")]
public class MeasurementType
{
    [Key]
    public int id_measurement_type { get; set; }


    public required int ds_name { get; set; }
    public required string tx_description { get; set; }
    public required DateTime dt_created_at { get; set; } = DateTime.Now;
    public DateTime dt_updated_at { get; set; }
    public DateTime dt_finished_at { get; set; }

}
