using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RBIntegracao.Domain.Entities;

namespace RBIntegracao.Infra.Repositories.Map
{
    public class MapGrupoFornecedor : IEntityTypeConfiguration<GrupoFornecedor>
    {
        public void Configure(EntityTypeBuilder<GrupoFornecedor> builder)
        {
            builder.ToTable("GrupoFornecedor");

            builder.HasOne(x => x.Solicitacao).WithMany().HasForeignKey("IdSolicitacao");
            builder.HasOne(x => x.Fornecedor).WithMany().HasForeignKey("IdFornecedor");
        }
    }
}
