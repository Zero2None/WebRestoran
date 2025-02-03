using System.Linq.Expressions;

namespace WebRestoran.Models
{
    public class QueryOptions<T> where T : class
    {
        public  Expression<Func<T, Object>> OrderBy { get; set; } = null!;  //null!- nema nullreferenceexception
        public Expression<Func<T, Object>> Where { get; set; } = null!;
        public List<Expression<Func<T, object>>> IncludesExpressions { get; set; } = new(); //lista izraza-bolje od stringa

        private string[] includes=Array.Empty<string>();    //kada jedan entitet ima vise entiteta, npr. food ima foodingredients, pa se koristi include
        public string Includes
        {
            set => includes = value.Replace(" ", "").Split(',');
        }
        
        public string[] GetIncludes() => includes?.Any() == true ? includes : Array.Empty<string>();    //ako nema nista vrati prazan niz, nema nullreferenceexception
        public bool HasWhere => Where != null;  //ako je where null, vrati false, inace true
        public bool HasOrderBy => OrderBy != null;  //ako je orderby null, vrati false, inace true

    }
}