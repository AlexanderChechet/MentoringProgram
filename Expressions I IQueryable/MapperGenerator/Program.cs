using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapperGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new MapperGenerator();
            var mapper = generator.Generate<User, UserDto>();
            var user = new User();
            user.Name = "Test";
            user.Age = 1;
            var result = mapper.Map(user);
            Console.WriteLine(result.ToString());
            Console.ReadKey();
        }
    }

    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class UserDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
