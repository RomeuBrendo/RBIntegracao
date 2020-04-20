using RBIntegracao.Domain.Entities;
using RBIntegracao.Domain.Interfaces.Repositories.Base;
using System;
using System.Linq;

namespace RBIntegracao.Domain.Interfaces.Repositories
{
    public interface IRepositorySolicitacao : IRepositoryBase<Solicitacao, Guid>
    {
        public IQueryable<Solicitacao> ListarSolicitacaoFornecedor(Guid idFornecedor);
    }
}
