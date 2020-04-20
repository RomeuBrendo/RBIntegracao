using RBIntegracao.Domain.Entities;
using RBIntegracao.Domain.Interfaces.Repositories;
using RBIntegracao.Infra.Repositories;
using RBIntegracao.Infra.Repositories.Base;
using System;

namespace RBIntegracao.Infra.Repositories
{
    public class RepositoryUsuario : RepositoryBase<Usuario, Guid>, IRepositoryUsuario
    {
        private readonly RBIntegracaoContext _context;
        public RepositoryUsuario(RBIntegracaoContext context) : base(context)
        {
            _context = context;
        }
    }
}
