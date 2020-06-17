using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sec.Dal.Interfaces
{
     public interface IAsyncRepository<T> : IDisposable where T : class
    {
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<List<T>> Search(Expression<Func<T, bool>> expr);
        Task<T> Find(Expression<Func<T, bool>> expr);
        Task<T> SearchById(int id);
        Task<List<T>> List();
        Task<bool> Any(Expression<Func<T, bool>> expr);
    }
}
