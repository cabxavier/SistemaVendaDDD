using Aplicacao.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Dominio21.Models;

namespace SistemaVenda.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly IServicoAplicacaoCategoria servicoAplicacaoCategoria;

        public CategoriaController(IServicoAplicacaoCategoria servicoAplicacaoCategoria)
        {
            this.servicoAplicacaoCategoria = servicoAplicacaoCategoria;
        }

        public IActionResult Index()
        {
            return View(this.servicoAplicacaoCategoria.Listagem());
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            var categoria = new CategoriaViewModel();

            if (id is not null)
            {
                categoria = this.servicoAplicacaoCategoria.CarregarRegistro((int)id);
            }

            return View(categoria);
        }


        [HttpPost]
        public IActionResult Cadastro(CategoriaViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                this.servicoAplicacaoCategoria.Cadastrar(entidade);
            }
            else
            {
                return View(entidade);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            this.servicoAplicacaoCategoria.Excluir(id);

            return RedirectToAction("Index");
        }
    }
}