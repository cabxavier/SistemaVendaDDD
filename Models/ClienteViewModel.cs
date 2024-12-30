using System.ComponentModel.DataAnnotations;

namespace SistemaVenda.Models;

public class ClienteViewModel
{
    public int? Codigo { get; set; }
    
    [Required(ErrorMessage = "Informe o nome")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Informe o cnpj e/ou cpf")]
    public string CNPJ_CPF { get; set; }
    
    [Required(ErrorMessage = "Informe o e-mail")]
    public string Email {get; set;}
    
    [Required(ErrorMessage = "Informe o celular")]
    public string Celular {get; set;}
}