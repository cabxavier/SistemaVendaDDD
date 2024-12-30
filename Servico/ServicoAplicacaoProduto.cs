using Aplicacao.Servico.Interfaces;
using Dominio21.Entitidade;
using Dominio21.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dominio21.Models;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoProduto : IServicoAplicacaoProduto
    {
        private readonly IServicoProduto servicoProduto;

        public ServicoAplicacaoProduto(IServicoProduto servicoProduto)
        {
            this.servicoProduto = servicoProduto;
        }

        public void Cadastrar(ProdutoViewModel produto)
        {
            var item = new Produto()
            {
                Codigo = produto.Codigo,
                Descricao = produto.Descricao,
                Quantidade = produto.Quantidade,
                Valor = (decimal)produto.Valor,
                CodigoCategoria = (int)produto.CodigoCategoria
            };

            this.servicoProduto.Cadastrar(item);
        }

        public ProdutoViewModel CarregarRegistro(int codigoProduto)
        {
            var registro = this.servicoProduto.CarregarRegistro(codigoProduto);
            var produto = new ProdutoViewModel();

            if (registro is not null)
            {
                produto.Codigo = registro.Codigo;
                produto.Descricao = registro.Descricao;
                produto.Quantidade = registro.Quantidade;
                produto.Valor = (decimal)registro.Valor;
                produto.CodigoCategoria = (int)registro.CodigoCategoria;
            }

            return produto;
        }

        public void Excluir(int id)
        {
            this.servicoProduto.Excluir(id);
        }

        public IEnumerable<ProdutoViewModel> Listagem()
        {
            var lista = this.servicoProduto.Listagem();
            var listaProduto = new List<ProdutoViewModel>();

            foreach (var item in lista)
            {
                listaProduto.Add(new ProdutoViewModel
                {
                    Codigo = item.Codigo,
                    Descricao = item.Descricao,
                    Quantidade = item.Quantidade,
                    Valor = (decimal)item.Valor,
                    CodigoCategoria = (int)item.CodigoCategoria,
                    DescricaoCategoria = item.Categoria.Descricao
                });
            }

            return listaProduto;
        }

        public IEnumerable<SelectListItem> ListaProdutosDropDownList()
        {
            var retorno = new List<SelectListItem>();

            var lista = this.Listagem();

            foreach (var item in lista)
            {
                retorno.Add(new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Descricao,
                });
            }

            return retorno;
        }
    }
}
