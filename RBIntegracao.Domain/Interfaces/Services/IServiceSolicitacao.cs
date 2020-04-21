using RBIntegracao.Domain.Commands.Solicitacao.AdicionarSolicitacao;
using RBIntegracao.Domain.Commands.Solicitacao.ListarSolicitacao;
using RBIntegracao.Domain.Interfaces.Services.Base;
using System;

namespace RBIntegracao.Domain.Interfaces.Services
{
    public interface IServiceSolicitacao : IServiceBase
    {
        AdicionarSolicitacaoResponse AdicionarSolicitacao(AdicionarSolicitacaoRequest request, Guid idUsuario);
        ListarSolicitacaoResponse ListarSolicitacaoFornecedor(ListarSolicitacaoRequest request);
    }
}
