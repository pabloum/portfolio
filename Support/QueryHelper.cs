using System;
using System.Collections.Generic;
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

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName)
        {
            return OrderingHelper(source, propertyName, false, false);
        }
        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string propertyName)
        {
            return OrderingHelper(source, propertyName, true, false);
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

        public static IQueryable<T> Has<T>(this IQueryable<T> source, string[] propertyNames, string keyword)
        {
            ParameterExpression parameter = null;
            MethodInfo CONTAINS_METHOD;
            MethodInfo TO_LOWER_METHOD;
            MethodCallExpression methodCallExpression = null;
            MethodCallExpression containsExpression = null;
            List<Expression> expressions = new List<Expression>();
            Expression combinedExpression = null;
            Expression<Func<T, bool>> predicate = null;
            IQueryable<T> returnValue = null;

            if (source == null || string.IsNullOrEmpty(keyword) == true)
                return source;
            keyword = keyword.ToLower();
            parameter = Expression.Parameter(source.ElementType, String.Empty);
            CONTAINS_METHOD = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            TO_LOWER_METHOD = typeof(string).GetMethod("ToLower", new Type[] { });
            foreach (string propertyItem in propertyNames)
            {
                var property = Expression.Property(parameter, propertyItem);
                var toLowerExpression = Expression.Call(property, TO_LOWER_METHOD);
                var termConstant = Expression.Constant(keyword, typeof(string));
                containsExpression = Expression.Call(toLowerExpression, CONTAINS_METHOD, termConstant);
                expressions.Add(containsExpression);
            }
            foreach (Expression expressionItem in expressions)
            {
                combinedExpression = expressions.Aggregate((l, r) => Expression.OrElse(l, r));
            }
            predicate = Expression.Lambda<Func<T, bool>>(combinedExpression, parameter);
            methodCallExpression = Expression.Call(typeof(Queryable), "Where",
                                        new Type[] { source.ElementType },
                                        source.Expression, Expression.Quote(predicate));
            returnValue = source.Provider.CreateQuery<T>(methodCallExpression);

            return returnValue;
        }
    }
}
