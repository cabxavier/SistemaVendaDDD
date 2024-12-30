using Aplicacao.Servico.Interfaces;
using Dominio21.Entitidade;
using Dominio21.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dominio21.Models;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoCliente : IServicoAplicacaoCliente
    {
        private readonly IServicoCliente servicoCliente;

        public ServicoAplicacaoCliente(IServicoCliente servicoCliente)
        {
            this.servicoCliente = servicoCliente;
        }

        public void Cadastrar(ClienteViewModel cliente)
        {
            var item = new Cliente()
            {
                Codigo = cliente.Codigo,
                Nome = cliente.Nome,
                CNPJ_CPF = cliente.CNPJ_CPF,
                Email = cliente.Email,
                Celular = cliente.Celular
            };

            this.servicoCliente.Cadastrar(item);
        }

        public ClienteViewModel CarregarRegistro(int codigoCliente)
        {
            var registro = this.servicoCliente.CarregarRegistro(codigoCliente);
            var cliente = new ClienteViewModel();

            if (registro is not null)
            {
                cliente.Codigo = registro.Codigo;
                cliente.Nome = registro.Nome;
                cliente.CNPJ_CPF = registro.CNPJ_CPF;
                cliente.Email = registro.Email;
                cliente.Celular = registro.Celular;
            }

            return cliente;
        }

        public void Excluir(int id)
        {
            this.servicoCliente.Excluir(id);
        }

        public IEnumerable<SelectListItem> ListaClientesDropDownList()
        {
            var retorno = new List<SelectListItem>();

            var lista = this.Listagem();

            foreach (var item in lista)
            {
                retorno.Add(new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Nome,
                });
            }

            return retorno;
        }

        public IEnumerable<ClienteViewModel> Listagem()
        {
            var lista = this.servicoCliente.Listagem();
            var listaCliente = new List<ClienteViewModel>();

            foreach (var item in lista)
            {
                listaCliente.Add(new ClienteViewModel
                {
                    Codigo = item.Codigo,
                    Nome = item.Nome,
                    CNPJ_CPF = item.CNPJ_CPF,
                    Email = item.Email,
                    Celular = item.Celular
                });
            }

            return listaCliente;
        }
    }
}
