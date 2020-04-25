using RBIntegracao.Domain.Commands.Orcamento;
using RBIntegracao.Domain.Interfaces.Services.Base;
using System;

namespace RBIntegracao.Domain.Interfaces.Services
{
    public interface IServiceOrcamento : IServiceBase
    {
        AdicionarOrcamentoResponse AdicionarSolicitacao(AdicionarOrcamentoRequest request, Guid idUsuario);
    }
}
