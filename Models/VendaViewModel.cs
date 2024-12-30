using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SistemaVenda.Models;

public class VendaViewModel
{
    public int? Codigo { get; set; }
    
    [Required(ErrorMessage = "Informe a data")]
    public DateTime? Data { get; set; }

    [Required(ErrorMessage = "Informe o cliente")]
    public int? CodigoCliente { get; set; }
    
    public IEnumerable<SelectListItem>? ListaClientes { get; set; }
    
    public IEnumerable<SelectListItem>? ListaProdutos { get; set; }
    
    public string JsonProdutos { get; set; }
    
    public decimal Total { get; set; }

    public string? NomeCliente { get; set; }
}