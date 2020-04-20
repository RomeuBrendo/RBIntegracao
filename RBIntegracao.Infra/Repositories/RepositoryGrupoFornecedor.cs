using RBIntegracao.Domain.Entities;
using RBIntegracao.Domain.Interfaces.Repositories;
using RBIntegracao.Infra.Repositories;
using RBIntegracao.Infra.Repositories.Base;
using System;

namespace RBIntegracao.Infra.Repositories
{
    public class RepositoryGrupoFornecedor : RepositoryBase<GrupoFornecedor, Guid>, IRepositoryGrupoFornecedor
    {
        private readonly RBIntegracaoContext _context;
        public RepositoryGrupoFornecedor(RBIntegracaoContext context) : base(context)
        {
            _context = context;
        }
    }
}
