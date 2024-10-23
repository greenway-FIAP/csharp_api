using System.Text.Json.Serialization;

namespace ApiGreenway.Models.Dtos;

public class UserUpdateDto : User
{
    public string? ds_email { get; set; }
    public string? ds_password { get; set; }
}
