﻿using Dominio21.Models;

namespace Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoVenda
    {
        IEnumerable<GraficoViewModel> ListaGrafico();

        IEnumerable<VendaViewModel> Listagem();

        VendaViewModel CarregarRegistro(int codigoVenda);

        void Cadastrar(VendaViewModel venda);

        void Excluir(int id);
    }
}
