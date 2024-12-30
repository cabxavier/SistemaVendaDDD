using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SistemaVenda.Models;

public class ProdutoViewModel
{
    public int? Codigo { get; set; }
    
    [Required(ErrorMessage = "Informe a descrição")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "Informe a quantidade em estoque")]
    public double Quantidade { get; set; }
    
    [Required(ErrorMessage = "Informe o valor unitário")]
    [Range(0.1, Double.PositiveInfinity)]
    public decimal? Valor {get; set;}
    
    [Required(ErrorMessage = "Informe a categoria")]
    public int? CodigoCategoria {get; set;}
    
    public IEnumerable<SelectListItem>? ListaCategorias { get; set; }

    public string? DescricaoCategoria { get; set; }
}