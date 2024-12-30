using Aplicacao.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Dominio21.Models;

namespace SistemaVenda.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IServicoAplicacaoCliente servicoAplicacaoCliente;

        public ClienteController(IServicoAplicacaoCliente servicoAplicacaoCliente)
        {
            this.servicoAplicacaoCliente = servicoAplicacaoCliente;
        }

        public IActionResult Index()
        {
            return View(this.servicoAplicacaoCliente.Listagem());
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            var Cliente = new ClienteViewModel();

            if (id is not null)
            {
                Cliente = this.servicoAplicacaoCliente.CarregarRegistro((int)id);
            }

            return View(Cliente);
        }


        [HttpPost]
        public IActionResult Cadastro(ClienteViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                this.servicoAplicacaoCliente.Cadastrar(entidade);
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
            this.servicoAplicacaoCliente.Excluir(id);

            return RedirectToAction("Index");
        }
    }
}