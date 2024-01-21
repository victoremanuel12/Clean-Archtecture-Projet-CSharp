namespace CleanArchMvc.Domain.Intefaces
{
    public interface IRepository<T>
    {
        Task<T> GetByIdAsync(int id);
        Task<IQueryable<T>> GetAllAsync();
        Task<T> CreateAsync(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
