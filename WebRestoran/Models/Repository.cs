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
            //var options = new QueryOptions<T>(); // Create a default QueryOptions object
            //var entity = await GetByIdAsync(id, options);
            //T entity = await _dbSet.FindAsync(id);
            //if (entity != null)
            //{
            //    _dbSet.Remove(entity);
            //    await _context.SaveChangesAsync();
            //}


            //var entity = await _dbSet
            //    .Include(i => _context.Set<FoodIngredient>().Where(fi => fi.IngredientId == id))
            //    .FirstOrDefaultAsync(i => i.IngredientId == id);

            //if (entity != null)
            //{
            //    _context.Set<FoodIngredient>().RemoveRange(entity.FoodIngredients); // Remove references
            //    _dbSet.Remove(entity); // Remove ingredient
            //    await _context.SaveChangesAsync();
            //}

            //test za brisanje sastojka
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                // Ensure related FoodIngredient records are deleted first
                var foodIngredients = await _context.Set<FoodIngredient>()
                                                    .Where(fi => fi.IngredientId == id)
                                                    .ToListAsync(); // Executes the query immediately

                _context.Set<FoodIngredient>().RemoveRange(foodIngredients); // Safely remove related records
                _dbSet.Remove(entity); // Remove the ingredient
                await _context.SaveChangesAsync(); // Commit changes to database
            }

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id, QueryOptions<T> options)
        {
            IQueryable<T> query = _dbSet;

            //if (options.HasWhere)
            //{
            //    query = query.Where(options.Where);   //compiler ne zna da je options.Where Expression<Func<T, bool>>, pa se mora koristiti lambda
            //}

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
                query = query.Include(include);
            }

            var key = _context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.FirstOrDefault();
            string primaryKeyName = key?.Name;
            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, primaryKeyName) == id);
        }
    }
}
