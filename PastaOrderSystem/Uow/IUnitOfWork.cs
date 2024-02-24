namespace PastaOrderSystem.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
        
    }
}
