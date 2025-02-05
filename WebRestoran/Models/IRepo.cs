using Microsoft.Build.Locator;
using System.Linq.Expressions; //dodano za async

namespace WebRestoran.Models
{
    public interface IRepo<T> where T : class 
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(QueryOptions<T> options);

        //Task<IEnumerable<T>> GetAllByIdAsync<TKey>(TKey id, string propertyName, QueryOptions<T> options);    -test
        Task<T> GetByIdAsync(int id, QueryOptions<T> options);  //zbog include
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<Order>> GetAllOrdersWithItemsAsync();
    }
}
