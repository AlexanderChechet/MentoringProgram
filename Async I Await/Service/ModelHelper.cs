using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class ModelHelper
    {
        public static bool IsValid(this User user)
        {
            if (user.Age <= 0)
                return false;
            if (string.IsNullOrWhiteSpace(user.Name))
                return false;
            if (string.IsNullOrWhiteSpace(user.Surname))
                return false;
            return true;
        }
    }
}
