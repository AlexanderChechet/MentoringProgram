using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MapperGenerator
{
    public class FieldComparer : IEqualityComparer<FieldInfo>
    {
        public bool Equals(FieldInfo x, FieldInfo y)
        {
            if (x == null && y == null)
                return true;
            else if (x == null | y == null)
                return false;
            else if (x.Name == y.Name && x.FieldType == y.FieldType)
                return true;
            else
                return false;
        }

        public int GetHashCode(FieldInfo obj)
        {
            return obj.GetHashCode();
        }
    }
}
