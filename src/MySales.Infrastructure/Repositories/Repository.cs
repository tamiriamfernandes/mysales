using Microsoft.EntityFrameworkCore;
using MySales.Application.Contracts.Repositories;
using MySales.Infrastructure.Contexts;
using System.Linq.Expressions;

namespace MySales.Infrastructure.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly DbContext _context;
    private readonly Lazy<DbSet<TEntity>> _dbSet;

    public Repository(MySalesContext? context)
    {
        if(context is null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        _context = context;
        _dbSet = new Lazy<DbSet<TEntity>>(() =>  context.Set<TEntity>());
    }

    public TEntity GetById(int id)
    {
        return _dbSet.Value.Find(id);
    }

    public IQueryable<TEntity> GetAll()
    {
        return _dbSet.Value;
    }

    public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbSet.Value.Where(predicate);
    }

    public void Add(TEntity entity)
    {
        _dbSet.Value.Add(entity);
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
        _dbSet.Value.AddRange(entities);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Value.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void Remove(TEntity entity)
    {
        _dbSet.Value.Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
