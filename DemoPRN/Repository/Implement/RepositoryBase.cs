using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DemoPRN.Repository.Implement
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private MyDbContext _repositoryContext;

        protected RepositoryBase(MyDbContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public void Create(T entity)
        {
            _repositoryContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _repositoryContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAll(bool trackChanges)
        {
            return trackChanges ? _repositoryContext.Set<T>() : _repositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges ? _repositoryContext.Set<T>().Where(expression) : _repositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            _repositoryContext.Set<T>().Update(entity);
        }
    }
}
