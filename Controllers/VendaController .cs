using Aplicacao.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Dominio21.Models;

namespace SistemaVenda.Controllers
{
    public class VendaController : Controller
    {
        private readonly IServicoAplicacaoVenda servicoAplicacaoVenda;
        private readonly IServicoAplicacaoProduto servicoAplicacaoProduto;
        private readonly IServicoAplicacaoCliente servicoAplicacaoCliente;

        public VendaController(IServicoAplicacaoVenda servicoAplicacaoVenda, IServicoAplicacaoProduto servicoAplicacaoProduto, IServicoAplicacaoCliente servicoAplicacaoCliente)
        {
            this.servicoAplicacaoVenda = servicoAplicacaoVenda;
            this.servicoAplicacaoProduto = servicoAplicacaoProduto;
            this.servicoAplicacaoCliente = servicoAplicacaoCliente;
        }

        public IActionResult Index()
        {
            return View(this.servicoAplicacaoVenda.Listagem());
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            var viewModel = new VendaViewModel();

            if (id != null)
            {
                viewModel = this.servicoAplicacaoVenda.CarregarRegistro((int)id);
            }

            viewModel.ListaClientes = this.servicoAplicacaoCliente.ListaClientesDropDownList();
            viewModel.ListaProdutos = this.servicoAplicacaoProduto.ListaProdutosDropDownList();

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Cadastro(VendaViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                this.servicoAplicacaoVenda.Cadastrar(entidade);
            }
            else
            {
                entidade.ListaClientes = this.servicoAplicacaoCliente.ListaClientesDropDownList();
                entidade.ListaProdutos = this.servicoAplicacaoProduto.ListaProdutosDropDownList();

                return View(entidade);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            this.servicoAplicacaoVenda.Excluir(id);

            return RedirectToAction("Index");
        }

        [HttpGet("LerValorProduto/{CodigoProduto}")]
        public decimal LerValorProduto(int CodigoProduto)
        {
            return (decimal)this.servicoAplicacaoProduto.CarregarRegistro(CodigoProduto).Valor;
        }
    }
}