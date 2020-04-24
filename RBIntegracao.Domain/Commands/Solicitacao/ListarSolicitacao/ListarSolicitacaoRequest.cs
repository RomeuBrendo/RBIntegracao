using MediatR;
using System;

namespace RBIntegracao.Domain.Commands.Solicitacao.ListarSolicitacao
{
    public class ListarSolicitacaoRequest 
    {
        public Guid? Id { get; set; }
        public string DataInicio { get; set; }
        public string DataFim { get; set; }
    }
}
