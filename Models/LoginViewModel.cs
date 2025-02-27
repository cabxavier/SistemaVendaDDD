using System.ComponentModel.DataAnnotations;

namespace SistemaVenda.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "Informe o e-mail")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Informe a senha")]
    public string Senha { get; set; }
}