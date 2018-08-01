using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YoAdopto.API.Contracts;
using YoAdopto.API.Helpers;

namespace YoAdopto.API.Data
{
   public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DataContext context { get; set; }
        internal DbSet<T> dbSet;

        public GenericRepository(DataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }
 
        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            return await GetQuery(filter, orderBy, includeProperties).ToListAsync();
        }

        public async Task<PagedList<T>> GetPaged(Expression<Func<T, bool>> filter = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            string includeProperties = "",
            int pageNumber = 1,
            int pageSize = 10)
        {
            return await PagedList<T>.CreateAsync(GetQuery(filter, orderBy, includeProperties), pageNumber, pageSize);
        }

         public async Task<T> GetSingleByCondition(Expression<Func<T, bool>> filter = null,
            string includeProperties = "")
        {
            return await GetQuery(filter, null, includeProperties).FirstOrDefaultAsync();
        } 

        public void Create(T entity)
        {
            this.dbSet.Add(entity);
        } 

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        } 

        public void Delete(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public void Delete(int id)
        {
            T entity = dbSet.Find(id);
            Delete(entity);
        }

        private IQueryable<T> GetQuery(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }
    }
}