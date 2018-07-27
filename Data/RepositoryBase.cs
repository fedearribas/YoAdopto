using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
 
        public IEnumerable<T> FindAll()
        {
            return this.context.Set<T>();
        }
 
        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.context.Set<T>().Where(expression);
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
 
        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}