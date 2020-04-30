using System;
using System.Collections.Generic;
using System.Text;

namespace RBIntegracao.Domain.Commands.Orcamento
{
    public class OrcamentoResponse
    {
        public int IdExterno { get; private set; }
        public Double ValorTotal { get; private set; }
        public Double Frete { get; private set; }
        public Double Seguro { get; private set; }
        public string FormaPagamento { get; private set; }
        public int Parcelas { get; private set; }
        public List<OrcamentoItemResponse> Itens { get; private set; }
        public DateTime DataOrcamento { get; private set; }
    }
}
