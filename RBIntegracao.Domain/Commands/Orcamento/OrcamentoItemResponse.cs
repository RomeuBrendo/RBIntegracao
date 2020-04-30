using System;
using System.Collections.Generic;
using System.Text;

namespace RBIntegracao.Domain.Commands.Orcamento
{
    public class OrcamentoItemResponse
    {
        public string Descricao { get; private set; }
        public double Quantidade { get; private set; }
        public double ValorUnitarioItem { get; private set; }
        public double ValorTotalItem { get; private set; }
    }
}
