﻿using RBIntegracao.Domain.Commands.Orcamento;
using RBIntegracao.Domain.Commands.Solicitacao.AdicionarSolicitacao;
using RBIntegracao.Domain.Commands.Solicitacao.AlterarStatus;
using RBIntegracao.Domain.Commands.Solicitacao.ListarSolicitacao;
using RBIntegracao.Domain.Entities;
using RBIntegracao.Domain.Interfaces.Services.Base;
using System;
using System.Collections.Generic;

namespace RBIntegracao.Domain.Interfaces.Services
{
    public interface IServiceSolicitacao : IServiceBase
    {
        AdicionarSolicitacaoResponse AdicionarSolicitacao(AdicionarSolicitacaoRequest request, Guid idUsuario);
        IEnumerable<ListarSolicitacaoSemOrcamentoResponse> ListarSolicitacaoFornecedor(Guid IdFornecedor, int status);
        public IEnumerable<ListarSolicitacaoResponse> ListarSolicitacaoCliente(ListarSolicitacaoRequest listarSolicitacaoRequest);
        public AlterarStatusSolicitacaoResponse AlterarStatus(AlterarStatusSolicitacaoRequest request, Guid idUsuario);
    }
}
