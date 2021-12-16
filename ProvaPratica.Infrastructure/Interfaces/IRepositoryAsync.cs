namespace ProvaPratica.Infrastructure.Interfaces
{
    public interface IRepositoryAsync<T>
    {
        Task Add(T entity);

        Task<List<T>> GetAll();

        Task<List<T>> GetActive();

        Task<T> GetById(Guid id);

        Task Update(T entity);
    }
}
