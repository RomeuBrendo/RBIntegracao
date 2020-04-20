using RBIntegracao.Domain.Entities;
using RBIntegracao.Domain.Interfaces.Repositories.Base;
using System;

namespace RBIntegracao.Domain.Interfaces.Repositories
{
    public interface IRepositoryPedido : IRepositoryBase<Pedido, Guid>
    {
    }
}
