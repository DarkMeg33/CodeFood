using System.ComponentModel.DataAnnotations;

namespace CodeFood.Models;

public class LoginViewModel
{
    [Required][Display(Name = "Login")] public string? UserName { get; set; }
    [Required][UIHint("password")][Display(Name = "Password")] public string? Password { get; set; }
    [Required][Display(Name = "Remember me?")] public bool RememberMe { get; set; }
}
