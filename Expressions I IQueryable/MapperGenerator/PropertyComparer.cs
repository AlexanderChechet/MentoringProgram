using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MapperGenerator
{
    public class PropertyComparer : IEqualityComparer<PropertyInfo>
    {
        public bool Equals(PropertyInfo x, PropertyInfo y)
        {
            if (x == null && y == null)
                return true;
            else if (x == null | y == null)
                return false;
            else if (x.Name == y.Name && x.PropertyType == y.PropertyType)
                return true;
            else
                return false;
        }

        public int GetHashCode(PropertyInfo obj)
        {
            return obj.GetHashCode();
        }
    }
}
