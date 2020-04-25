using RBIntegracao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBIntegracao.Domain.Commands.Orcamento
{
    public class AdicionarOrcamentoRequest
    {
        public Double ValorTotal { get; set; }
        public Double Frete { get; set; }
        public Double Seguro { get; set; }
        public string FormaPagamento { get; set; }
        public int Parcelas { get; set; }
        public List<OrcamentoItem> Itens { get; set; }
        public List<int> IdExternoSolicitacao { get; set; }
    }
}
