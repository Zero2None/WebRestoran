using System.Linq.Expressions;

namespace WebRestoran.Models
{   
    public class QueryOptions<T> where T : class
    {
        public Expression<Func<T, bool>> Where { get; set; }
        public Expression<Func<T, object>> OrderBy { get; set; }
        public List<Expression<Func<T, object>>> IncludesExpressions { get; set; } = new List<Expression<Func<T, object>>>();//lista izraza-bolje od stringa

        private string[] includes = Array.Empty<string>();
        public string Includes { set { includes = value.Split(','); } }
        public string[] GetIncludes() => includes;

        public bool HasWhere => Where != null;
        public bool HasOrderBy => OrderBy != null;
    }
}