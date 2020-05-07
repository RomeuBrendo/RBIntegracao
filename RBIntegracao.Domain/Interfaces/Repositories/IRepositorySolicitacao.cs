using RBIntegracao.Domain.Entities;
using RBIntegracao.Domain.Enums;
using RBIntegracao.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RBIntegracao.Domain.Interfaces.Repositories
{
    public interface IRepositorySolicitacao : IRepositoryBase<Solicitacao, Guid>
    {
        public IEnumerable<Solicitacao> ListarSolicitacaoFornecedor(Guid idFornecedor, EnumStatus status);

        public IEnumerable<Solicitacao> ListarOrcamentoReferenteSolicitacao(List<Solicitacao> solicitacoes);

    }
}
