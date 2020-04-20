using Microsoft.EntityFrameworkCore;
using prmToolkit.NotificationPattern;
using RBIntegracao.Domain.Entities;
using RBIntegracao.Infra.Repositories.Map;

namespace RBIntegracao.Infra.Repositories.Base
{
    public class RBIntegracaoContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Solicitacao> Solicitacao { get; set; }
        public DbSet<GrupoFornecedor> GrupoFornecedor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=RBIntegracao;Uid=root;Pwd=root;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //ignorar classes
            modelBuilder.Ignore<Notification>();
            modelBuilder.Ignore<Pedido>();

            modelBuilder.ApplyConfiguration(new MapUsuario());
            modelBuilder.ApplyConfiguration(new MapSolicitacao());
            modelBuilder.ApplyConfiguration(new MapGrupoFornecedor());

            base.OnModelCreating(modelBuilder);
        }
    }
}
