using Aplicacao.Servico.Interfaces;
using Dominio21.Entitidade;
using Dominio21.Interfaces;
using Dominio21.Models;
using Newtonsoft.Json;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoVenda : IServicoAplicacaoVenda
    {
        private readonly IServicoVenda servicoVenda;

        public ServicoAplicacaoVenda(IServicoVenda servicoVenda)
        {
            this.servicoVenda = servicoVenda;
        }

        public void Cadastrar(VendaViewModel venda)
        {
            var item = new Venda()
            {
                Codigo = venda.Codigo,
                Data = (DateTime)venda.Data,
                CodigoCliente = (int)venda.CodigoCliente,
                Total = venda.Total,
                Produtos = JsonConvert.DeserializeObject<ICollection<VendaProdutos>>(venda.JsonProdutos)
            };

            this.servicoVenda.Cadastrar(item);
        }

        public VendaViewModel CarregarRegistro(int codigoVenda)
        {
            var registro = this.servicoVenda.CarregarRegistro(codigoVenda);
            var venda = new VendaViewModel();

            if (registro is not null)
            {
                venda.Codigo = registro.Codigo;
                venda.Data = registro.Data;
                venda.CodigoCliente = registro.CodigoCliente;
                venda.NomeCliente = registro.Cliente?.Nome;
                venda.Total = registro.Total;
            }

            return venda;
        }

        public void Excluir(int id)
        {
            this.servicoVenda.Excluir(id);
        }

        public IEnumerable<VendaViewModel> Listagem()
        {
            var lista = this.servicoVenda.Listagem();
            var listaVenda = new List<VendaViewModel>();

            foreach (var item in lista)
            {
                listaVenda.Add(new VendaViewModel
                {
                    Codigo = item.Codigo,
                    Data = item.Data,
                    CodigoCliente = item.CodigoCliente,
                    NomeCliente = item.Cliente.Nome,
                    Total = item.Total
                });
            }

            return listaVenda;
        }

        public IEnumerable<GraficoViewModel> ListaGrafico()
        {
           return this.servicoVenda.ListaGrafico();
        }
    }
}
