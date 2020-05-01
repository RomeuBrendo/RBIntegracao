using RBIntegracao.Domain.Entities;
using RBIntegracao.Domain.Interfaces.Repositories;
using RBIntegracao.Infra.Repositories.Base;
using System;

namespace RBIntegracao.Infra.Repositories
{
    public class RepositorySolicitacaoOrcamento : RepositoryBase<SolicitacaoOrcamento, Guid>, IRepositorySolicitacaoOrcamento
    {
        private readonly RBIntegracaoContext _context;
        public RepositorySolicitacaoOrcamento(RBIntegracaoContext context) : base(context)
        {
            _context = context;
        }
    }
}
