using Microsoft.AspNetCore.Mvc.Rendering;
using Dominio21.Models;

namespace Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoProduto
    {
        IEnumerable<SelectListItem> ListaProdutosDropDownList();

        IEnumerable<ProdutoViewModel> Listagem();

        ProdutoViewModel CarregarRegistro(int codigoProduto);

        void Cadastrar(ProdutoViewModel produto);

        void Excluir(int id);
    }
}
