using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;    //DbContext, DbSet
using WebRestoran.Data; //appDbContext

namespace WebRestoran.Models
{
    public class Repository<T> : IRepo<T> where T : class
    {

        protected ApplicationDbContext _context { get; set; }
        private DbSet<T> _dbSet { get; set; }

        public Repository(ApplicationDbContext context)
        {
            _context = context; //dependency injection konekcija sa bazom
            _dbSet = _context.Set<T>(); //s kojom tablicom radimo
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            T entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(QueryOptions<T> options = null)
        {
            IQueryable<T> query = _dbSet.AsQueryable();

            if (options?.IncludesExpressions != null)
            {
                foreach (var include in options.IncludesExpressions)
                {
                    query = query.Include(include);
                }
            }

            if (options?.Where != null)
            {
                if (options.Where is Expression<Func<T, bool>> whereExpression)
                {
                    query = query.Where(whereExpression);
                }
                else
                {
                    throw new InvalidOperationException("Invalid Where expression. Must return a boolean condition.");
                }
            }

            if (options?.OrderBy != null)
            {
                query = query.OrderBy(options.OrderBy);
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id, QueryOptions<T> options)
        {
            IQueryable<T> query = _dbSet;

            if (options.HasWhere)
            {
                var whereExpression = Expression.Lambda<Func<T, bool>>(options.Where.Body, options.Where.Parameters);
                query = query.Where(whereExpression);
            }

            if (options.HasOrderBy)
            {
                query = query.OrderBy(options.OrderBy);
            }

            foreach (string include in options.GetIncludes())
            {
                query = query.Include(include.Trim());
            }
                     
            var key = _context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.FirstOrDefault();
            string primaryKeyName = key?.Name;
            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, primaryKeyName) == id);
        }

        //test funkcija
        //public async Task<IEnumerable<T>> GetAllByIdAsync<TKey>(TKey id, string propertyName, QueryOptions<T> options)
        //{
        //    IQueryable<T> query = _dbSet;

        //    if (options.HasWhere)
        //    {
        //        //test
        //        //        if (options.Where != null)
        //        //        {
        //        //            var whereExpression = Expression.Lambda<Func<T, bool>>(options.Where.Body, options.Where.Parameters);
        //        //            query = query.Where(whereExpression);
        //        //        }
        //        query = query.Where(options.Where);
        //    }

        //    if (options.HasOrderBy)
        //    {
        //        query = query.OrderBy(options.OrderBy);
        //    }

        //    foreach (string include in options.GetIncludes())
        //    {
        //        query = query.Include(include);
        //    }
        //    query = query.Where(e => EF.Property<TKey>(e, propertyName).Equals(id));

        //    return await query.ToListAsync();
        //}
        public async Task<IEnumerable<Order>> GetAllOrdersWithItemsAsync()
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Food)
                .ToListAsync();
        }
    }
}
