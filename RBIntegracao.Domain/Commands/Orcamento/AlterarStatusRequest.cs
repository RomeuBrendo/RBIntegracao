using RBIntegracao.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBIntegracao.Domain.Commands.Orcamento
{
    public class AlterarStatusRequest
    {
        public int IdExterno { get; set; }
        public EnumStatus NovoStatus { get; set; }
    }
}
