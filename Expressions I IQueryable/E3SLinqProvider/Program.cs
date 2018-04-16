using E3SLinqProvider.E3SClient;
using E3SLinqProvider.E3SClient.Entities;
using System;
using System.Configuration;
using System.Linq;

namespace E3SLinqProvider
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintEmployees();
            Console.ReadKey();
        }

        public static void PrintEmployees()
        {
            var employees = new E3SEntitySet<EmployeeEntity>(ConfigurationManager.AppSettings["user"], ConfigurationManager.AppSettings["password"]);

            foreach (var emp in employees.Where(e => e.workStation.StartsWith("EPBYMINW") && e.project.Contains("EARD")))
            {
                Console.WriteLine("{0} {1} {2} {3}", emp.nativeName, emp.workStation, emp.primarySkill, emp.project);
            }
        }
    }
}
