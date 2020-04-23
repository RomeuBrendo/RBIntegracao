using System;

namespace RBIntegracao.Domain.Commands.Solicitacao.AdicionarSolicitacao
{
    public class AdicionarSolicitacaoResponse
    {
        public AdicionarSolicitacaoResponse(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
