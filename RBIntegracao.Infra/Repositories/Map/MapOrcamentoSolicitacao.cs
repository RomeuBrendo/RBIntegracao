using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RBIntegracao.Domain.Entities;

namespace RBIntegracao.Infra.Repositories.Map
{
    public class MapOrcamentoSolicitacao : IEntityTypeConfiguration<OrcamentoSolicitacao>
    {
        public void Configure(EntityTypeBuilder<OrcamentoSolicitacao> builder)
        {
            builder.ToTable("OrcamentoSolicitacao");

            builder.HasOne(x => x.Orcamento).WithMany().HasForeignKey("IdOrcamento");
            builder.HasOne(x => x.Solicitacao).WithMany().HasForeignKey("IdSolicitacao");
        }
    }
}
