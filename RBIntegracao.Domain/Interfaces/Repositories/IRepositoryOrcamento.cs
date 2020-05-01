using RBIntegracao.Domain.Entities;
using RBIntegracao.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;

namespace RBIntegracao.Domain.Interfaces.Repositories
{
    public interface IRepositoryOrcamento : IRepositoryBase<Orcamento, Guid>
    {
        public Solicitacao VerificaIdExternoSolicitacao(Guid IdUsuario, int idExterno);

        public Orcamento AdicionarOrcamentoCompleto(Orcamento orcamento, List<Solicitacao> solicitacao);

        public Orcamento RetornarOrcamentoIdExternoIdUsuario(int IdExterno, Guid idUsuario);
    }
}
