namespace Warehouse.Infarstructure.Interfaces
{
    public interface IGenericeInterface<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}