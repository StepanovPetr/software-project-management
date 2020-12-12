using System.Collections.Generic;
using System.Linq;
using Example.Domain;
using Example.Domain.Entities;
using Example.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Example.Services
{
    public class DepartmentService : IDepartmentService
    {
        public void Add(Department department)
        {
            using (var context = new ExampleContext())
            {
                context.Departments.Add(department);
                context.SaveChanges();
            }
        }

        public IEnumerable<Department> GetDepartments()
        {
            using (var context = new ExampleContext())
            {
                return context.Departments.Include( d=>d.Groups)
                    .ToList();
            }
        }

        public Department GetDepartmentById(int id)
        {
            using (var context = new ExampleContext())
            {
                var department = context.Departments.Single(d => d.Id == id);

                if (department == null)
                {
                    throw new DepartmentNotFound($"Department Not Found for {id}");
                }

                return department;
            }
        }

        void UpdateDepartment(Department department)
        {
            using (var context = new ExampleContext())
            {
                context.Departments.Update(department);
                context.SaveChanges();
            }
        }

        public void DeleteDepartmentById(int id)
        {
            using (var context = new ExampleContext())
            {
                var department = context.Departments.Single(d => d.Id == id);

                if (department == null)
                {
                    throw new DepartmentNotFound($"Department Not Found for id - {id}");
                }

                context.Departments.Remove(department);
                context.SaveChanges();
            }
        }

        public void DeleteDepartmentsByNameAndHead(string name, string head)
        {
            using (var context = new ExampleContext())
            {
                var departments = context.Departments.Where(d => d.Name == name && d.Head == head);

                if (departments.Any())
                {
                    context.Departments.RemoveRange(departments);
                    context.SaveChanges();
                }
            }
        }
    }
}
