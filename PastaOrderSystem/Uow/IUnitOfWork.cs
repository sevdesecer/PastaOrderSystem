﻿namespace WebApi.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();

        Task SaveChangesAsync();

        void Disposable();
    }
}