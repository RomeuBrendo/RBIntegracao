namespace RBIntegracao.Infra.Repositories.Transactions
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
