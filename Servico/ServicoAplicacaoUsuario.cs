using Aplicacao.Servico.Interfaces;
using Dominio21.Entitidade;
using Dominio21.Interfaces;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoUsuario : IServicoAplicacaoUsuario
    {
        private readonly IServicoUsuario servicoUsuario;

        public ServicoAplicacaoUsuario(IServicoUsuario servicoUsuario)
        {
            this.servicoUsuario = servicoUsuario;
        }

        public Usuario RetornarDadosUsuario(string email, string senha)
        {
            return this.servicoUsuario.Listagem().Where(x => x.Email == email && x.Senha.ToUpper() == senha.ToUpper()).FirstOrDefault();
        }

        public bool ValidarLogin(string email, string senha)
        {
            return this.servicoUsuario.ValidarLogin(email, senha);
        }
    }
}
