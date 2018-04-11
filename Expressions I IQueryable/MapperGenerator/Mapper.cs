using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperGenerator
{
    public class Mapper<TSource, TDestination>
    {
        Func<TSource, TDestination> mapFunction;
        internal Mapper(Func<TSource, TDestination> function)
        {
            mapFunction = function;
        }

        public TDestination Map(TSource source)
        {
            return mapFunction(source);
        }
    }
}
