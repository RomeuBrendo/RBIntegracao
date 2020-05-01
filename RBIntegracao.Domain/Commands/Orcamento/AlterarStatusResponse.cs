using System;
using System.Collections.Generic;
using System.Text;

namespace RBIntegracao.Domain.Commands.Orcamento
{
    public class AlterarStatusResponse
    {
        public AlterarStatusResponse(int idExterno, string mensagem)
        {
            IdExterno = idExterno;
            Mensagem = mensagem;
        }

        public int IdExterno { get; private set; }
        public String Mensagem { get; private set; }
    }
}
