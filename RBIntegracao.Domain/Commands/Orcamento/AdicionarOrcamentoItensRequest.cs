namespace RBIntegracao.Domain.Commands.Orcamento
{
    public class AdicionarOrcamentoItensRequest
    {
        public string Descricao { get; set; }
        public double Quantidade { get; set; }
        public double ValorUnitarioItem { get; set; }
        public double ValorTotalItem { get; set; }
       
    }
}
