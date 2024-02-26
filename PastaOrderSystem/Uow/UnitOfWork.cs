using Microsoft.EntityFrameworkCore;

namespace PastaOrderSystem.Uow
{
    public class UnitOfWork(DbContext context) : IUnitOfWork
    {
        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public void Disposable()
        {
            throw new NotImplementedException();
        }
    }
}
