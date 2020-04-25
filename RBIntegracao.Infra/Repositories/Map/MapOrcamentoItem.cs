using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RBIntegracao.Domain.Entities;
using System;

namespace RBIntegracao.Infra.Repositories.Map
{
    public class MapOrcamentoItem : IEntityTypeConfiguration<OrcamentoItem>
    {
        public void Configure(EntityTypeBuilder<OrcamentoItem> builder)
        {
            builder.ToTable("OrcamentoItem");

            ////Propriedades
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao).HasMaxLength(500);
            builder.Property(x => x.Quantidade);
            builder.Property(x => x.ValorTotalItem);
            builder.Property(x => x.ValorUnitarioItem);

        }
    }
}


//public string Descricao { get; private set; }
//public double Quantidade { get; private set; }
//public double ValorUnitarioItem { get; private set; }
//public double ValorTotalItem { get; private set; }