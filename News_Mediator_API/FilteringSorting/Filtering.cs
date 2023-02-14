using System.Linq.Expressions;

namespace News_Mediator_API.FilteringSorting
{
    public class Filtering
    {
        public IQueryable<T> Filter<T>(string columnName, string value, IQueryable<T> _data) where T : class
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, columnName);
            var method = typeof(string).GetMethod("ToLower", System.Type.EmptyTypes);
            var toLower = Expression.Call(property, method);
            var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var containsExpression = Expression.Call(toLower, containsMethod, Expression.Constant(value.ToLower()));
            var lambda = Expression.Lambda<Func<T, bool>>(containsExpression, parameter);
            return _data.Where(lambda);
        }

        //public List<News> GetFiltering(string username, IQueryable<News> _data)
        //{
        //    var result = _data.Where(x => x.Aurthor.ToLower().Contains(username.ToLower()));
        //    return result.ToList();
        //}
    }
}
