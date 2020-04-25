using RBIntegracao.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBIntegracao.Domain.Entities
{
    public class OrcamentoSolicitacao : EntityBase
    {
        public Orcamento Orcamento { get; private set; }
        public Solicitacao Solicitacao { get; private set; }
    }
}
