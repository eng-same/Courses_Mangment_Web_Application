using System.Linq.Expressions;

namespace Courses_Mangment_Web_Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllWithincludeAsync(params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync(int id);
        Task<T> GetWithIncludeAsync(int id, params Expression<Func<T, object>>[] includes);
        Task<T> GetWithIncludeAsync(int id, Func<IQueryable<T>, IQueryable<T>> includeFunc);
        Task<T> GetByCompositeKeyAsync(int id, int id2);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
