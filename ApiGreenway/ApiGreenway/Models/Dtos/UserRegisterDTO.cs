using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiGreenway.Models.Dtos;

public class UserRegisterDTO : User
{
    public string ds_email { get; set; } = string.Empty;
    public string ds_password { get; set; } = string.Empty;
}
