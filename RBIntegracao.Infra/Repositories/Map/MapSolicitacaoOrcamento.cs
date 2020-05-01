using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RBIntegracao.Domain.Entities;

namespace RBIntegracao.Infra.Repositories.Map
{
    public class MapSolicitacaoOrcamento : IEntityTypeConfiguration<SolicitacaoOrcamento>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoOrcamento> builder)
        {
            builder.ToTable("SolicitacaoOrcamento");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Solicitacao).WithMany().HasForeignKey("IdSolicitacao");

            builder.HasOne(x => x.Orcamento).WithMany().HasForeignKey("IdOrcamento");
        }
    }
}
