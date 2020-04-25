using RBIntegracao.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace RBIntegracao.Domain.Entities
{
    public class Orcamento : EntityBase
    {
        public Double ValorTotal { get; private set; }
        public Double Frete { get; private set; }
        public Double Seguro { get; private set; }
        public string FormaPagamento { get; private set; }
        public int Parcelas { get; private set; }
        public List<OrcamentoItem> Itens { get; private set; }
    }
}
