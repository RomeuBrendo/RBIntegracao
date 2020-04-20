using RBIntegracao.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBIntegracao.Domain.Entities
{
    public class Pedido : EntityBase
    {
        public Solicitacao Solicitacao { get; private set; }
        public DateTime? PrevisaoEntrega { get; set; }
        public double ValorUnitario { get; set; }
        public double ValorTotal { get; set; }
        public string Responsavel { get; set; }
    }
}
