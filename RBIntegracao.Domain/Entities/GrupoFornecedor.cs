using prmToolkit.NotificationPattern;
using RBIntegracao.Domain.Entities.Base;

namespace RBIntegracao.Domain.Entities
{
    public class GrupoFornecedor : EntityBase
    {
        protected GrupoFornecedor()
        {

        }
        public GrupoFornecedor(Usuario fornecedor, Solicitacao solicitacao)
        {
            Fornecedor = fornecedor;
            Solicitacao = solicitacao;

        }

        public Usuario Fornecedor { get; private set; }
        public Solicitacao Solicitacao { get; private set; }

    }
}
