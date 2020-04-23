using System;

namespace RBIntegracao.Domain.Commands.Solicitacao.AdicionarSolicitacao
{
    public class AdicionarSolicitacaoResponse
    {
        public AdicionarSolicitacaoResponse(Guid id, int idExternoSolicitacao)
        {
            Id = id;
            IdExternoSolicitacao = idExternoSolicitacao;
        }
        public Guid Id { get; set; }
        public int IdExternoSolicitacao { get; set; }
    }
}
