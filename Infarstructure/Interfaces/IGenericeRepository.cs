namespace Warehouse.Infarstructure.Interfaces
{
    public interface IGenericeRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
        Task<T> FindOrFailAsync(int id);
    }
}