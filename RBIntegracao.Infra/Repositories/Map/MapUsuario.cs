using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RBIntegracao.Domain.Entities;
using RBIntegracao.Domain.ValueObjects;

namespace RBIntegracao.Infra.Repositories.Map
{
    public class MapUsuario : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            ////Propriedades
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Senha).HasMaxLength(36).IsRequired();
            builder.Property(x => x.CnpjCpf).IsRequired();
            builder.Property(x => x.ClienteOuFornecedor).IsRequired();

            builder.OwnsOne<Nome>(x => x.Nome, cb => {
                cb.Property(x => x.RazaoSocial).HasMaxLength(500).IsRequired();
                cb.Property(x => x.NomeFantasia).HasMaxLength(500).IsRequired();
            });

            builder.OwnsOne<Email>(x => x.Email, cb => {
                cb.Property(x => x.Endereco).HasMaxLength(200).HasColumnName("Email").IsRequired();
            });
        }
    }
}
