using Microsoft.Build.Locator;
using System.Linq.Expressions; //dodano za async

namespace WebRestoran.Models
{
    public interface IRepo<T> where T : class 
    {

        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id, QueryOptions<T> options);  //zbog include
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);

    }
}
