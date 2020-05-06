using prmToolkit.NotificationPattern;
using RBIntegracao.Domain.Commands.Orcamento;
using RBIntegracao.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace RBIntegracao.Domain.Entities
{
    public class OrcamentoItem : EntityBase
    {
        protected OrcamentoItem()
        {

        }
        public OrcamentoItem(string descricao, double quantidade, double valorUnitarioItem, double valorTotalItem)
        {
           
            Descricao = descricao;
            Quantidade = quantidade;
            ValorUnitarioItem = valorUnitarioItem;
            ValorTotalItem = valorTotalItem;

            new AddNotifications<OrcamentoItem>(this)
                .IfNullOrEmpty(x => x.Descricao, "Descrição do produto não pode ser vazia");

            if (this.Quantidade <= 0)
                AddNotification("Quantidade", "Inválida");            
            
            if (this.ValorUnitarioItem <= 0)
                AddNotification("ValorUnitarioItem", "Inválido");           
            
            if (this.ValorTotalItem <= 0)
                AddNotification("ValorTotalItem", "Inválido");

        }

        public string Descricao { get; private set; }
        public double Quantidade { get;  private set; }
        public double ValorUnitarioItem { get; private set; }
        public double ValorTotalItem { get; private set; }
        public Guid? OrcamentoId { get; private set; }

    }
}
