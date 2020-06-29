using HP_StockDataCollector.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace HP_StockDataCollector.Calculation
{
    public enum OperationExpression
    {
        Equals,
        NotEquals,
        Minor,
        MinorEquals,
        Mayor,
        MayorEquals,
        Like,
        Contains,
        Any
    }


    public class CalculationSample
    {



        public CalculationSample()
        {

        }

        public void TestingLinq()
        {
            // in-memory collection
            // A query which will be executed at some point against a data source.
            //Both have an almost identical set of LINQ extensions, except the IENumberable<T> extensions accept Func<T> and ...
            //Func<T> is just a pointer to an ordinary delegate that has been compiled down to intermediate language just like any other C# code that you write.
        }
        public void ExpressionTesting<T>()
        {
            QuoteData quote = new QuoteData();
            Expression<Func<QuoteData>> quoteExpr = () => quote;
            Expression<Func<QuoteData, bool>> quoteExprChecking = s => s.Ask > 30.00 && s.Ask < 50.00;
            Func<QuoteData, bool> IsQuoteValid = quoteExprChecking.Compile();


            Expression<Func<QuoteData, bool>> IsQuote;
            Expression.Lambda<Func<QuoteData, bool>>(
                Expression.AndAlso(
                    Expression.GreaterThan(Expression.Property(quoteExpr, "Ask"), Expression.Constant(12, typeof(double))),
                    Expression.LessThan(Expression.Property(quoteExpr, "Bid"), Expression.Constant(20, typeof(double)))),
                            new[] { quoteExpr });



            var param = Expression.Parameter(typeof(QuoteData), "C");
            var propName = Expression.Property(param, "Name");
            var constP = Expression.Constant("P");
            var nameStartsWIth = Expression.Call(propName, typeof(string).GetMethod("StartsWith", new[] { typeof(string) }), constP);
            var exprName = Expression.Lambda<Func<QuoteData, bool>>(nameStartsWIth, param);

        }
        
    }

    //https://michael-mckenna.com/func-t-vs-expression-func-t-in-linq/
    //Source : https://www.codementor.io/@juliandambrosio/how-to-use-expression-trees-to-build-dynamic-queries-c-xyk1l2l82
    public static class ExpressionHelper
    {
        public static Expression<Func<T, bool>> GetCriteriaWhere<T>(Expression<Func<T, object>> e, OperationExpression selectedOperator, object fieldValue)
        {
            string name = GetOperand<T>(e);
            return GetCriteriaWhere<T>(name, selectedOperator, fieldValue);
        }
        public static Expression<Func<T, bool>> GetCriteriaWhere<T, T2>(Expression<Func<T, object>> e, OperationExpression selectedOperator, object fieldValue)
        {
            string name = GetOperand<T>(e);
            return GetCriteriaWhere<T, T2>(name, selectedOperator, fieldValue);
        }
        public static Expression<Func<T, bool>> GetCriteriaWhere<T, T2>(string fieldName, OperationExpression selectedOperator, object fieldValue)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            PropertyDescriptor prop = GetProperty(props, fieldName, true);

            var parameter = Expression.Parameter(typeof(T));
            var expressionParameter = GetMemberExpression<T>(parameter, fieldName);

            if (prop != null && fieldValue != null)
            {
                switch (selectedOperator)
                {
                    case OperationExpression.Any:
                        return Any<T, T2>(fieldValue, parameter, expressionParameter);

                    default:
                        throw new Exception("Not implement Operation");
                }
            }
            else
            {
                Expression<Func<T, bool>> filter = x => true;
                return filter;
            }
        }

        // Swap Visitor?... allows you to replace the parameters of the concatenated expressions with the parameter of one of them?...
        // ExpressionHelper allows you to create all the necessary expressions and concatenate them with an and/or...
        public static Expression<Func<T, bool>> GetCriteriaWhere<T>(string fieldName, OperationExpression selectedOperator, object fieldValue)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            PropertyDescriptor prop = GetProperty(props, fieldName, true);
            var parameter = Expression.Parameter(typeof(T));
            var expressionParameter = GetMemberExpression<T>(parameter, fieldName);

            if (prop != null && fieldValue != null)
            {

                BinaryExpression body = null;

                switch (selectedOperator)
                {
                    case OperationExpression.Equals:
                        body = Expression.Equal(expressionParameter, Expression.Constant(fieldValue, prop.PropertyType));
                        return Expression.Lambda<Func<T, bool>>(body, parameter);
                    case OperationExpression.NotEquals:
                        body = Expression.NotEqual(expressionParameter, Expression.Constant(fieldValue, prop.PropertyType));
                        return Expression.Lambda<Func<T, bool>>(body, parameter);
                    case OperationExpression.Minor:
                        body = Expression.LessThan(expressionParameter, Expression.Constant(fieldValue, prop.PropertyType));
                        return Expression.Lambda<Func<T, bool>>(body, parameter);
                    case OperationExpression.MinorEquals:
                        body = Expression.LessThanOrEqual(expressionParameter, Expression.Constant(fieldValue, prop.PropertyType));
                        return Expression.Lambda<Func<T, bool>>(body, parameter);
                    case OperationExpression.Mayor:
                        body = Expression.GreaterThan(expressionParameter, Expression.Constant(fieldValue, prop.PropertyType));
                        return Expression.Lambda<Func<T, bool>>(body, parameter);
                    case OperationExpression.MayorEquals:
                        body = Expression.GreaterThanOrEqual(expressionParameter, Expression.Constant(fieldValue, prop.PropertyType));
                        return Expression.Lambda<Func<T, bool>>(body, parameter);
                    case OperationExpression.Like:
                        MethodInfo contains = typeof(string).GetMethod("Contains");
                        var bodyLike = Expression.Call(expressionParameter, contains, Expression.Constant(fieldValue, prop.PropertyType));
                        return Expression.Lambda<Func<T, bool>>(bodyLike, parameter);
                    case OperationExpression.Contains:
                        return Contains<T>(fieldValue, parameter, expressionParameter);


                    default:
                        throw new Exception("Not implement Operation");
                }
            }
            else
            {
                Expression<Func<T, bool>> filter = x => true;
                return filter;
            }
        }
        private static Expression<Func<T, bool>> Contains<T>(object fieldValue, ParameterExpression parameterExpression, MemberExpression memberExpression)
        {
            var list = (List<long>)fieldValue;

            if (list == null || list.Count == 0) return x => true;

            MethodInfo containsInList = typeof(List<long>).GetMethod("Contains", new Type[] { typeof(long) });
            var bodyContains = Expression.Call(Expression.Constant(fieldValue), containsInList, memberExpression);

            return Expression.Lambda<Func<T, bool>>(bodyContains, parameterExpression);
        }
        private static Expression<Func<T, bool>> Any<T, T2>(object fieldValue, ParameterExpression parameterExpression, MemberExpression memberExpression)
        {
            var lambda = (Expression<Func<T2, bool>>)fieldValue;
            MethodInfo anyMethod = typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
            .First(m => m.Name == "Any" && m.GetParameters().Count() == 2).MakeGenericMethod(typeof(T2));

            var body = Expression.Call(anyMethod, memberExpression, lambda);

            return Expression.Lambda<Func<T, bool>>(body, parameterExpression);
        }
        private static MemberExpression GetMemberExpression<T>(ParameterExpression parameter, string propName)
        {
            if (string.IsNullOrEmpty(propName)) return null;
            var propertiesName = propName.Split('.');
            if (propertiesName.Count() == 2)
                return Expression.Property(Expression.Property(parameter, propertiesName[0]), propertiesName[1]);
            return Expression.Property(parameter, propName);
        }
        private static string GetOperand<T>(Expression<Func<T, object>> expr)
        {
            MemberExpression body = expr.Body as MemberExpression;
            if (body == null)
            {
                UnaryExpression ubody = (UnaryExpression)expr.Body;
                body = ubody.Operand as MemberExpression;
            }
            var operand = body.ToString();
            return operand.Substring(2);
        }
        private static PropertyDescriptor GetProperty(PropertyDescriptorCollection props, string fieldName, bool ignoreCase)
        {
            if (!fieldName.Contains('.'))
                return props.Find(fieldName, ignoreCase);

            var fieldNameProperty = fieldName.Split('.');
            return props.Find(fieldNameProperty[0], ignoreCase).GetChildProperties().Find(fieldNameProperty[1], ignoreCase);

        }

    }
}
