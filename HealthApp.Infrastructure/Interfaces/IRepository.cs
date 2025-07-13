namespace HealthApp.Infrastructure.Interfaces;

public interface IRepository<TEntity, in TKey> where TEntity : class
{
    ValueTask<TEntity?> GetByIdAsync(TKey id, CancellationToken token = default);
    void Add(TEntity entity);
    void Remove(TEntity entity);
    void Update(TEntity entity);
}