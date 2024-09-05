using PotifolioASB.Domain.Entities;
using System.Linq.Expressions;

namespace PotifolioASB.Infra.Interfaces
{
    public interface IBaseRepository<T> where T : Base
    {
        Task<T> CreateAsync(T obj);
        Task<T> UpdateAsync(T obj);
        Task RemoveAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<T> GetAsync(Expression<Func<T, bool>> expression, bool asNoTracking = true);
        Task<IList<T>> SearchAsync(Expression<Func<T, bool>> expression, bool asNoTracking = true);
    }
}
