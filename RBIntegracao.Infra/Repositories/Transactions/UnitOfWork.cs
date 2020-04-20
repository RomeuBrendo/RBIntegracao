using RBIntegracao.Infra.Repositories;
using RBIntegracao.Infra.Repositories.Base;
using RBIntegracao.Infra.Repositories.Transactions;

namespace VemDeZap.Infra.Repositories.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RBIntegracaoContext _context;

        public UnitOfWork(RBIntegracaoContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
