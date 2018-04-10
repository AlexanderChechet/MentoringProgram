
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
            var target = Expression.Variable(typeof(TDestination), "destination");
            var init = Expression.New(typeof(TDestination));
            var initTarget = Expression.Assign(target, init);
            var sourceFields = typeof(TSource).GetFields();
            var destinationFields = typeof(TDestination).GetFields();
            CompareFields(sourceFields, destinationFields);
            var sourceProperties = typeof(TSource).GetProperties();
            var destinationProperties = typeof(TDestination).GetProperties();
            CompareProperties(sourceProperties, destinationProperties);
            //TODO loop here
            var asign = AssignProperty<TSource, TDestination>(sourceParam, target, sourceProperties[0], destinationProperties[0]);
            var label = Expression.Label(typeof(TDestination));
            var ret = Expression.Label(label, target);
            return Expression.Block(new[] { target }, initTarget, asign, ret);
        }

        private void CompareFields(FieldInfo[] source, FieldInfo[] destination)
        {
            var comparer = new FieldComparer();
            for (int i = 0; i < source.Length; i++)
            {
                if (!destination.Contains(source[i], comparer))
                    throw new ArgumentException("Destination object doesn't has field " + source[i].Name);
            }
        }

        private void CompareProperties(PropertyInfo[] source, PropertyInfo[] destination)
        {
            var comparer = new PropertyComparer();
            for (int i = 0; i < source.Length; i++)
            {
                if (!destination.Contains(source[i], comparer))
                    throw new ArgumentException("Destination object doesn't has field " + source[i].Name);
            }
        }

        private Expression AssignProperty<TSource, TDestination>(Expression source, Expression destination, PropertyInfo sourceInfo, PropertyInfo destinationInfo)
        {
            var destinationProperty = Expression.Property(destination, destinationInfo);
            var sourceProperty = Expression.Property(source, sourceInfo);
            return Expression.Assign(destinationProperty, sourceProperty);
        }
    }
}
