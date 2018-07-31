using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YoAdopto.API.Contracts;

namespace YoAdopto.API.Data
{
   public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DataContext context { get; set; }
 
        public RepositoryBase(DataContext context)
        {
            this.context = context;
        }
 
        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await this.context.Set<T>().ToListAsync();
        }
 
        public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await this.context.Set<T>().Where(expression).ToListAsync();
        }
 
        public void Create(T entity)
        {
            this.context.Set<T>().Add(entity);
        }
 
        public void Update(T entity)
        {
            this.context.Set<T>().Update(entity);
        }
 
        public void Delete(T entity)
        {
            this.context.Set<T>().Remove(entity);
        }
 
        public async Task SaveAsync()
        {
           await  this.context.SaveChangesAsync();
        }
    }
}