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
        public string Mensagem { get; set; }
    }
}
