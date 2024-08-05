using Contexts;
using Microsoft.EntityFrameworkCore;
using Services.Abstraction.IRepositoryServices;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public abstract class RepositoryBase<T>(QLNSDbContext repositoryContext) : IRepositoryBase<T> where T : class
    {
        protected QLNSDbContext qlnsDbContext = repositoryContext;

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ?
            qlnsDbContext.Set<T>().AsNoTracking() :
            qlnsDbContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ?
            qlnsDbContext.Set<T>().Where(expression).AsNoTracking() :
            qlnsDbContext.Set<T>().Where(expression);

        public void Create(T entity) => qlnsDbContext.Set<T>().Add(entity);

        public void Update(T entity) => qlnsDbContext.Set<T>().Update(entity);

        public void Delete(T entity) => qlnsDbContext.Set<T>().Remove(entity);
    }
}
