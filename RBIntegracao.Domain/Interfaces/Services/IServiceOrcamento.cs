using RBIntegracao.Domain.Commands.Orcamento;
using RBIntegracao.Domain.Commands.Orcamento.ListarOrcamento;
using RBIntegracao.Domain.Entities;
using RBIntegracao.Domain.Interfaces.Services.Base;
using System;
using System.Collections.Generic;

namespace RBIntegracao.Domain.Interfaces.Services
{
    public interface IServiceOrcamento : IServiceBase
    {
        AdicionarOrcamentoResponse AdicionarOrcamento(AdicionarOrcamentoRequest request, Guid idFornecedor);

        AlterarStatusResponse AlterarStatus(AlterarStatusRequest request, Guid idUsuario);

        AlterarStatusResponse Deletar(int idExterno, Guid idUsuario);

        public List<OrcamentoResponse> ListarOrcamentoPorData(ListarOrcamentoRequest request);
    }
}
