using System;
using System.Collections.Generic;
using System.Text;

namespace RBIntegracao.Domain.Commands.Orcamento
{
    public class AdicionarOrcamentoResponse
    {
        public AdicionarOrcamentoResponse(Guid id, int idExternoOrcamento)
        {
            Id = id;
            IdExternoOrcamento = idExternoOrcamento;
        }

        public Guid Id { get; set; }
        public int IdExternoOrcamento { get; set; }
    }
}
