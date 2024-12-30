using Aplicacao.Servico.Interfaces;
using Dominio21.Entitidade;
using Dominio21.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dominio21.Models;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoCategoria : IServicoAplicacaoCategoria
    {
        private readonly IServicoCategoria servicoCategoria;

        public ServicoAplicacaoCategoria(IServicoCategoria servicoCategoria)
        {
            this.servicoCategoria = servicoCategoria;
        }

        public void Cadastrar(CategoriaViewModel categoria)
        {
            var item = new Categoria()
            {
                Codigo = categoria.Codigo,
                Descricao = categoria.Descricao
            };

            this.servicoCategoria.Cadastrar(item);
        }

        public CategoriaViewModel CarregarRegistro(int codigoCategoria)
        {
            var registro = this.servicoCategoria.CarregarRegistro(codigoCategoria);
            var categoria = new CategoriaViewModel();

            if (registro is not null)
            {
                categoria.Codigo = registro.Codigo;
                categoria.Descricao = registro.Descricao;
            }

            return categoria;
        }

        public void Excluir(int id)
        {
            this.servicoCategoria.Excluir(id);
        }

        public IEnumerable<SelectListItem> ListaCategoriasDropDownList()
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

        public IEnumerable<CategoriaViewModel> Listagem()
        {
            var lista = this.servicoCategoria.Listagem();
            var listaCategoria = new List<CategoriaViewModel>();

            foreach (var item in lista)
            {
                listaCategoria.Add(new CategoriaViewModel
                {
                    Codigo = item.Codigo,
                    Descricao = item.Descricao
                });
            }

            return listaCategoria;
        }
    }
}
