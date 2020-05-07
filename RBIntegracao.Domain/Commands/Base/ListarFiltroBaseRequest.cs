using System;
using System.Collections.Generic;
using System.Text;

namespace RBIntegracao.Domain.Commands.Base
{
    public class ListarFiltroBaseRequest
    {
        public Guid? Id { get; set; }
        public string DataInicio { get; set; }
        public string DataFim { get; set; }
    }
}
