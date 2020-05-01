using RBIntegracao.Domain.Entities.Base;

namespace RBIntegracao.Domain.Entities
{
    public class SolicitacaoOrcamento : EntityBase
    {
        public Solicitacao Solicitacao { get; set; }
        public Orcamento Orcamento { get; set; }
    }
}
