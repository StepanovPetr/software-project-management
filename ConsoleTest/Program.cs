using System;
using System.Collections.Generic;
using Example.Domain;
using Example.Domain.Entities;

namespace ConsoleTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using (var context = new ExampleContext())
            {
                context.Database.CanConnect();

                var department = new Department {Name = "fdfdf", Head = "Вася"};

                department.Groups ??= new List<Group>();
                department.Groups.Add(new Group {Name = "ИВТ-1"});
                department.Groups.Add(new Group {Name = "ИВТ-2"});
                department.Groups.Add(new Group {Name = "ИВТ-3"});

                context.Departments.Add(department);

                context.SaveChanges();
            }
        }
    }
}