using RBIntegracao.Domain.Entities;
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

        public static explicit operator OrcamentoItemResponse(OrcamentoItem entidade)
        {
            return new OrcamentoItemResponse()
            {
                Descricao = entidade.Descricao,
                Quantidade = entidade.Quantidade,
                ValorUnitarioItem = entidade.ValorUnitarioItem,
                ValorTotalItem = entidade.ValorTotalItem

            };
        }
    }
}
