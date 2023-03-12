using System.Linq.Expressions;

namespace B3Test.Domain.Extensions
{
    public static class PredicateExtensions
    {
        public static Expression<Func<T, bool>> True<T>() { return p => true; }
        public static Expression<Func<T, bool>> False<T>() { return p => false; }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> exp1, Expression<Func<T, bool>> exp2)
        {
            var invokedExp = Expression.Invoke(exp2, exp1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>(Expression.OrElse(exp1.Body, invokedExp), exp1.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> exp1, Expression<Func<T, bool>> exp2)
        {
            var invokedExp = Expression.Invoke(exp2, exp1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(exp1.Body, invokedExp), exp1.Parameters);
        }
    }
}