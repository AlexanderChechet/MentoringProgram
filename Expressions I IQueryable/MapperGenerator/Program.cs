using System;

namespace MapperGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new MapperGenerator();
            var mapper = generator.Generate<User, UserDto>();
            var user = new User();
            user.Name = "TestName";
            user.Surname = "TestSurname";
            user.Age = 1;
            user.Id = 1;
            user.Cash = 100.50;
            var result = mapper.Map(user);
            Console.ReadKey();
        }
    }

    public class User
    {
        public double Cash;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
    public class UserDto
    {
        public double Cash;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int Age1 { get; set; }
    }
}
