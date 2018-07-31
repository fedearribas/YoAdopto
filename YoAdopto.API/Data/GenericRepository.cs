using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YoAdopto.API.Contracts;

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
 
        public async Task<IEnumerable<T>> Get( Expression<Func<T, bool>> filter = null,
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
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

         public async Task<T> GetById(int id)
        {
            return await this.dbSet.FindAsync(id);
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
    }
}