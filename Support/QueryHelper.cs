using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Support
{
    public static class QueryHelper
    {
        public static IOrderedQueryable<T> OrderingHelper<T>(this IQueryable<T> source, string propertyName, bool descending, bool anotherLevel) // where T : Entity
        {
            ParameterExpression param = Expression.Parameter(typeof(T), string.Empty);
            MemberExpression property = Expression.PropertyOrField(param, propertyName);
            LambdaExpression sort = Expression.Lambda(property, param);
            MethodCallExpression call = Expression.Call(
                typeof(Queryable),
                (!anotherLevel ? "OrderBy" : "ThenBy") + (descending ? "Descending" : string.Empty),
                new[] { typeof(T), property.Type },
                source.Expression,
                Expression.Quote(sort));
            return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(call);
        }

        public static IQueryable<T> SearchHelper<T>(this IQueryable<T> source, string propertyName, string propertyValue) //where T : Entity
        {
            ParameterExpression parameter = Expression.Parameter(source.ElementType, string.Empty);
            MethodInfo contains = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            MemberExpression property = Expression.Property(parameter, propertyName);
            ConstantExpression termConstant = Expression.Constant(propertyValue, typeof(string));
            MethodCallExpression containsExpression = Expression.Call(property, contains, termConstant);
            LambdaExpression search = Expression.Lambda<Func<T, bool>>(containsExpression, parameter);

            MethodCallExpression call = Expression.Call(
                typeof(Queryable),
                "Where",
                new Type[] { source.ElementType },
                source.Expression,
                Expression.Quote(search));

            return source.Provider.CreateQuery<T>(call);
        }
    }
}
