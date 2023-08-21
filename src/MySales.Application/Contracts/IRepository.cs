using System.Linq.Expressions;

namespace MySales.Application.Contracts;

public interface IRepository<TEntity> where TEntity : class
{
    TEntity GetById(int id);
    IQueryable<TEntity> GetAll();
    IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    Task SaveChangesAsync();
}