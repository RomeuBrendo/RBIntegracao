using System;

namespace RBIntegracao.Domain.Commands.Solicitacao.AlterarStatus
{
    public class AlterarStatusSolicitacaoResponse
    {
        public AlterarStatusSolicitacaoResponse(int idExterno, string mensagem)
        {
            IdExterno = idExterno;
            Mensagem = mensagem;
        }

        public int IdExterno { get; private set; }
        public String Mensagem { get; private set; }
    }
}
