using Dominio.Interfaces;
using Dominio21.Entitidade;
using Dominio21.Repositorio;

namespace Dominio.Servicos
{
    public class ServicoCategoria : IServicoCategoria
    {
        private readonly IRepositorioCategoria RepositorioCategoria;

        public ServicoCategoria(IRepositorioCategoria RepositorioCategoria)
        {
            this.RepositorioCategoria = RepositorioCategoria;
        }

        public void Cadastrar(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Categoria CarregarRegistro(int id)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Categoria> Listagem()
        {
            return this.RepositorioCategoria.Read().ToList();
        }
    }
}
