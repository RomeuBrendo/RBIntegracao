using RBIntegracao.Domain.Entities;
using RBIntegracao.Domain.Interfaces.Repositories;
using RBIntegracao.Infra.Repositories;
using RBIntegracao.Infra.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBIntegracao.Infra.Repositories
{
    public class RepositoryPedido : RepositoryBase<Pedido, Guid>, IRepositoryPedido
    {
        private readonly RBIntegracaoContext _context;
        public RepositoryPedido(RBIntegracaoContext context) : base(context)
        {
            _context = context;
        }
    }
}
