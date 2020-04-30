using RBIntegracao.Domain.Entities;
using RBIntegracao.Domain.Interfaces.Repositories.Base;
using System;

namespace RBIntegracao.Domain.Interfaces.Repositories
{
    public interface IRepositoryOrcamento : IRepositoryBase<Orcamento, Guid>
    {
        public bool VerificaIdExternoSolicitacao(Guid IdUsuario, int idExterno);
    }
}
