using RBIntegracao.Domain.Enums;

namespace RBIntegracao.Domain.Commands.Base
{
    public class AlterarStatusBaseRequest
    {
        public int IdExterno { get; set; }
        public EnumStatus NovoStatus { get; set; }
    }
}
