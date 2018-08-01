using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using YoAdopto.API.Helpers;

namespace YoAdopto.API.Contracts
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> Get( Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        Task<PagedList<T>> GetPaged( Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "",
            int pageNumber = 1,
            int pageSize = 12);
        Task<T> GetSingleByCondition(Expression<Func<T, bool>> filter = null,
            string includeProperties = "");
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);        
    }
}