using Aplicacao.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SistemaVenda.Controllers;

public class RelatorioController : Controller
{
    private readonly IServicoAplicacaoVenda servicoAplicacaoVenda;

    public RelatorioController(IServicoAplicacaoVenda servicoAplicacaoVenda)
    {
        this.servicoAplicacaoVenda = servicoAplicacaoVenda;
    }

    // GET
    public IActionResult Grafico()
    {
        var lista = this.servicoAplicacaoVenda.ListaGrafico().ToList();

        string valores = string.Empty;
        string labels = string.Empty;
        string cores = string.Empty;

        var random = new Random();

        for (int i = 0; i < lista.Count; i++)
        {
            valores += lista[i].TotalVendido.ToString() + ",";
            labels += "'" + lista[i].Descricao + "',";
            cores += "'" + string.Format("#{0:X6}", random.Next(0x1000000)) + "',";
        }

        ViewBag.Valores = valores;
        ViewBag.Labels = labels;
        ViewBag.Cores = cores;

        return View();
    }
}