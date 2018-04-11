
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MapperGenerator
{
    public class MapperGenerator
    {
        public Mapper<TSource, TDestination> Generate<TSource, TDestination>()
        {
            var sourceParam = Expression.Parameter(typeof(TSource));
            var body = GetBody<TSource, TDestination>(sourceParam);
            var function = Expression.Lambda<Func<TSource, TDestination>>(body, sourceParam);
            return new Mapper<TSource, TDestination>(function.Compile());
        }

        private Expression GetBody<TSource, TDestination>(Expression sourceParam)
        {
            var bodyList = new List<Expression>();
            var destination = Expression.Variable(typeof(TDestination), "destination");
            var initDestination = Expression.Assign(destination, Expression.New(typeof(TDestination)));

            bodyList.Add(initDestination);
            bodyList.AddRange(CompareFields<TSource, TDestination>(sourceParam, destination));
            bodyList.AddRange(CompareProperties<TSource, TDestination>(sourceParam, destination));

            var destinationLabel = Expression.Label(typeof(TDestination));
            var returnLabel = Expression.Label(destinationLabel, destination);
            bodyList.Add(returnLabel);

            return Expression.Block(new[] { destination }, bodyList);
        }

        private List<Expression> CompareFields<TSource, TDestination>(Expression source, Expression destination)
        {
            var result = new List<Expression>();
            var sourceFields = typeof(TSource).GetFields();
            var destinationFields = typeof(TDestination).GetFields();
            var comparer = new FieldComparer();
            for (int i = 0; i < sourceFields.Length; i++)
            {
                if (!destinationFields.Contains(sourceFields[i], comparer))
                    throw new ArgumentException("Destination object doesn't has field " + sourceFields[i].Name);
                var destinationFieldInfo = destinationFields.First(x => comparer.Equals(x, sourceFields[i]));
                result.Add(Expression.Assign(
                    Expression.Field(destination, destinationFieldInfo),
                    Expression.Field(source, sourceFields[i])));
            }
            return result;
        }

        private List<Expression> CompareProperties<TSource, TDestination>(Expression source, Expression destination)
        {
            var result = new List<Expression>();
            var sourceProperties = typeof(TSource).GetProperties();
            var destinationProperties = typeof(TDestination).GetProperties();
            var comparer = new PropertyComparer();
            for (int i = 0; i < sourceProperties.Length; i++)
            {
                if (!destinationProperties.Contains(sourceProperties[i], comparer))
                    throw new ArgumentException("Destination object doesn't has field " + sourceProperties[i].Name);
                var destinationPropertyInfo = destinationProperties.First(x => comparer.Equals(x, sourceProperties[i]));
                result.Add(Expression.Assign(
                    Expression.Property(destination, destinationPropertyInfo),
                    Expression.Property(source, sourceProperties[i])));
            }
            return result;
        }
    }
}
