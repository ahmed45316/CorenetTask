using PersonalDiary.Data.Repository;
using System;
using System.Threading.Tasks;

namespace PersonalDiary.Data.UnitOfWork
{
    public interface IUnitOfWork<T> : IDisposable where T : class
    {
        IRepository<T> Repository { get; }
        Task<int> SaveChanges();
    }
}
