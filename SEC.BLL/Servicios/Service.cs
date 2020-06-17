using Sec.Bll.Interfaces;
using Sec.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sec.Bll.Servicios
{
    public class Service<T> : IService<T> where T : class
    {
        protected readonly IAsyncRepository<T> _repository;

        public Service(IAsyncRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<IReadOnlyList<T>> List()
        {
            return await _repository.List();
        }

        public virtual async Task<List<T>> Search(Expression<Func<T, bool>> expr)
        {
            return await _repository.Search(expr);
        }

        public virtual async Task<T> SearchById(int id)
        {
            return await _repository.SearchById(id);
        }

        public virtual async Task<T> Find(Expression<Func<T, bool>> expr)
        {
            return await _repository.Find(expr);
        }

        public virtual async Task<T> Add(T reg)
        {
            return await _repository.Add(reg);
        }

        public virtual async Task Update(T reg)
        {
            await _repository.Update(reg);
        }

        public virtual async Task Delete(int id)
        {
            var reg = await _repository.SearchById(id);
            await _repository.Delete(reg);
        }

        public virtual async Task Delete(T reg)
        {
            await _repository.Delete(reg);
        }

        public virtual async Task<bool> Any(Expression<Func<T, bool>> expr)
        {
            return await _repository.Any(expr);
        }
    }
}
