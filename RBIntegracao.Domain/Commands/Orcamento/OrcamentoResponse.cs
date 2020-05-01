using RBIntegracao.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RBIntegracao.Domain.Commands.Orcamento
{
    public class OrcamentoResponse
    {
        public int IdExterno { get; private set; }
        public string Fornecedor { get; private set; }

        public EnumStatus Status { get; private set; }
        public Double ValorTotal { get; private set; }
        public Double Frete { get; private set; }
        public Double Seguro { get; private set; }
        public string FormaPagamento { get; private set; }
        public int Parcelas { get; private set; }
        public List<OrcamentoItemResponse> Itens { get; private set; }
        public DateTime DataOrcamento { get; private set; }

        public static explicit operator OrcamentoResponse(Entities.Orcamento entidade)
        {
            return new OrcamentoResponse()
            {
                IdExterno = entidade.IdExterno,
                Fornecedor = entidade.FornecedorSolicitante.CnpjCpf,
                ValorTotal = entidade.ValorTotal,
                Frete = entidade.Frete,
                Seguro = entidade.Seguro,
                FormaPagamento = entidade.FormaPagamento,
                Parcelas = entidade.Parcelas,
                DataOrcamento = entidade.DataOrcamento,
                Itens = entidade.Itens.ToList().Select(entidade => (OrcamentoItemResponse)entidade).ToList(),
                Status = entidade.Status,
            };
        }
    }
}
