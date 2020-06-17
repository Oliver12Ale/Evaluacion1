using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sec.Bll.Interfaces
{
    public interface IService<T>
    {
        Task<IReadOnlyList<T>> List();
        Task<T> SearchById(int id);
        Task<List<T>> Search(Expression<Func<T, bool>> expr);
        Task<T> Find(Expression<Func<T, bool>> expr);
        Task<T> Add(T reg);
        Task Update(T reg);
        Task Delete(int id);
        Task Delete(T reg);
        Task<bool> Any(Expression<Func<T, bool>> expr);
    }
}
