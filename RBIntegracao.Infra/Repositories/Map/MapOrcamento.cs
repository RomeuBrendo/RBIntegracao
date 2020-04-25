using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RBIntegracao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBIntegracao.Infra.Repositories.Map
{
    public class MapOrcamento : IEntityTypeConfiguration<Orcamento>
    {
        public void Configure(EntityTypeBuilder<Orcamento> builder)
        {
            builder.ToTable("Orcamento");

            ////Propriedades
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ValorTotal).IsRequired();
            builder.Property(x => x.Frete);
            builder.Property(x => x.FormaPagamento).HasMaxLength(50);
            builder.Property(x => x.Parcelas);

            builder.Ignore(x => x.Itens);


        }
    }
}
