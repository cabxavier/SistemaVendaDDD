using Aplicacao.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Dominio21.Models;

namespace SistemaVenda.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IServicoAplicacaoProduto servicoAplicacaoProduto;
        private readonly IServicoAplicacaoCategoria servicoAplicacaoCategoria;

        public ProdutoController(IServicoAplicacaoProduto servicoAplicacaoProduto, IServicoAplicacaoCategoria servicoAplicacaoCategoria)
        {
            this.servicoAplicacaoProduto = servicoAplicacaoProduto;
            this.servicoAplicacaoCategoria = servicoAplicacaoCategoria;
        }

        public IActionResult Index()
        {
            return View(this.servicoAplicacaoProduto.Listagem());
        }


        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            var viewModel = new ProdutoViewModel();

            if (id != null)
            {
                viewModel = this.servicoAplicacaoProduto.CarregarRegistro((int)id);
            }

            viewModel.ListaCategorias = this.servicoAplicacaoCategoria.ListaCategoriasDropDownList();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(ProdutoViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                this.servicoAplicacaoProduto.Cadastrar(entidade);
            }
            else
            {
                entidade.ListaCategorias = this.servicoAplicacaoCategoria.ListaCategoriasDropDownList();

                return View(entidade);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            this.servicoAplicacaoProduto.Excluir(id);

            return RedirectToAction("Index");
        }
    }
}