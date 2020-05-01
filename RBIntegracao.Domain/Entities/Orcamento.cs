using prmToolkit.NotificationPattern;
using RBIntegracao.Domain.Commands.Orcamento;
using RBIntegracao.Domain.Entities.Base;
using RBIntegracao.Domain.Enums;
using System;
using System.Collections.Generic;

namespace RBIntegracao.Domain.Entities
{
    public class Orcamento : EntityBase
    {
        protected Orcamento()
        {

        }
        public Orcamento(Usuario fornecedorSolicitante, int idExterno, double valorTotal, double frete, double seguro, string formaPagamento, 
                         int parcelas, List<OrcamentoItem> itens)
        {
            IdExterno = idExterno;
            FornecedorSolicitante = fornecedorSolicitante;
            ValorTotal = valorTotal;
            Frete = frete;
            Seguro = seguro;
            FormaPagamento = formaPagamento;
            Parcelas = parcelas;
            Itens = itens;
            DataOrcamento = DateTime.Now;
            Status = EnumStatus.Aberta;


            ValidaDados();
        }

        public int IdExterno { get; private set; }
        public Usuario FornecedorSolicitante { get ; private set; }
        public EnumStatus Status { get; private set; }
        public Double ValorTotal { get; private set; }
        public Double Frete { get; private set; }
        public Double Seguro { get; private set; }
        public string FormaPagamento { get; private set; }
        public int Parcelas { get; private set; }
        public List<OrcamentoItem> Itens { get; private set; }
        public DateTime DataOrcamento { get; private set; }

        private void ValidaDados()
        {
            if (this.IdExterno <= 0)
                AddNotification("Id Externo ", "Inválido");

            if (this.ValorTotal <= 0)
                AddNotification("Valor Total", "Inválido");

            if (this.Frete < 0)
                AddNotification("Frete", "Inválido");

            if (this.Seguro < 0)
                AddNotification("Seguro", "Inválido");

            if (this.Parcelas < 0)
                AddNotification("Parcelas", "Inválido");

            if (FornecedorSolicitante.ClienteOuFornecedor == EnumClienteOuFornecedor.Cliente)
                AddNotification("Usuario", "O mesmo tem que esta cadastrado como fornecedor, para realizar um Orçamento");

            new AddNotifications<Orcamento>(this)
                .IfNullOrInvalidLength(x => x.FormaPagamento, 1, 100, "Deve conter entre 1 e 100 caracteres");

        }


    }
}
