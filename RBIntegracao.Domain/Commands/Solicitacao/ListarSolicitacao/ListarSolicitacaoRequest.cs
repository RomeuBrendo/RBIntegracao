using MediatR;
using System;

namespace RBIntegracao.Domain.Commands.Solicitacao.ListarSolicitacao
{
    public class ListarSolicitacaoRequest : IRequest<Response>
    {
        public Guid Id { get; set; }
    }
}
