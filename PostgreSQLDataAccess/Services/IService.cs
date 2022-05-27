namespace PostgreSQLDAL.Services;

public interface IService<T>
{
    Task<IEnumerable<T>> GetAll();
    Task<T?> Get(Guid id);
    Task Insert(T entity);
    Task Update(T entity);
    Task Delete(Guid id);
}