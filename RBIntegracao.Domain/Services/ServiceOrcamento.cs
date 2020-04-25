using prmToolkit.NotificationPattern;
using RBIntegracao.Domain.Commands.Orcamento;
using RBIntegracao.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBIntegracao.Domain.Services
{
    public class ServiceOrcamento : Notifiable, IServiceOrcamento
    {
        public AdicionarOrcamentoResponse AdicionarSolicitacao(AdicionarOrcamentoRequest request, Guid idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
