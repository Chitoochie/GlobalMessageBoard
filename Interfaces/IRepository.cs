using GlobalMessageBoard.Models.Data;

namespace GlobalMessageBoard.Interfaces
{
    public interface IRepository<T> where T : Base
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();

    }
}
