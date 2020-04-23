using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RBIntegracao.Domain.Entities;
namespace RBIntegracao.Infra.Repositories.Map
{
    public class MapSolicitacao : IEntityTypeConfiguration<Solicitacao> 
    {

        public void Configure(EntityTypeBuilder<Solicitacao> builder)
        {
            builder.ToTable("Solicitacao");

            ////Propriedades
            builder.HasKey(x => x.Id);

            builder.Property(x => x.IdExternoSolicitacao).IsRequired();
            builder.Property(x => x.CodigoProduto).IsRequired();
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(500);
            builder.Property(x => x.PrevisaoTermino).IsRequired();
            builder.Property(x => x.DataSolicitacao).IsRequired();
            builder.Property(x => x.Observacao).HasMaxLength(1000);


            builder.HasOne(x => x.EmpresaSolicitante).WithMany().HasForeignKey("IdUsuario");
        }
    }
}


