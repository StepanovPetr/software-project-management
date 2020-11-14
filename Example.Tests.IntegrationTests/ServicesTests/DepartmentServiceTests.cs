using System.Collections.Generic;
using System.Linq;
using Example.Domain.Entities;
using Example.Services;
using NUnit.Framework;

namespace Example.Tests.IntegrationTests.ServicesTests
{
    public class Tests
    {
        private const string DefaultName = "ÔÈÒèÊÑ";
        private const string DefaultHead = "Âàëåðèé Êèïåëîâ";
        private const string DefaultGroupName = "ÈÂÒ-666";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Remove();
        }

        [TearDown]
        public void TearDown()
        {
            Remove();
        }

        private void Remove()
        {
            var repo = new DepartmentService();
            repo.DeleteDepartmentsByNameAndHead(DefaultName, DefaultHead);
        }

        [Test]
        public void WhenAddNewDepartmentToEmptyCollection_ShouldCollectionIncludeOneElement()
        {
            // Arrange
            var repo = new DepartmentService();
            var startingDepartments = repo.GetDepartments().Where(d => d.Name == DefaultName && d.Head == DefaultHead);

            // Act
            repo.Add(new Department {Name = DefaultName, Head = DefaultHead});
            var departments = repo.GetDepartments().SingleOrDefault(d => d.Name == DefaultName && d.Head == DefaultHead);

            //Assert
            Assert.IsTrue(!startingDepartments.Any());
            Assert.IsNotNull(departments);
            Assert.AreEqual(DefaultName, departments.Name);
            Assert.AreEqual(DefaultHead, departments.Head);
        }


        [Test]
        public void WhenAddNewDepartmentWithGroupToEmptyCollection_ShouldCollectionIncludeOneElement()
        {
            // Arrange
            var repo = new DepartmentService();
            var startingDepartments = repo.GetDepartments().Where(d => d.Name == DefaultName && d.Head == DefaultHead);

            // Act
            var department = new Department { Name = DefaultName , Head = DefaultHead };
            department.Groups ??= new List<Group>();
            department.Groups.Add(new Group { Name = DefaultGroupName });

            repo.Add(department);
            var departments = repo.GetDepartments().SingleOrDefault(d => d.Name == DefaultName && d.Head == DefaultHead);

            //Assert
            Assert.IsTrue(!startingDepartments.Any());
            Assert.IsNotNull(departments);
            Assert.AreEqual(DefaultName, departments.Name);
            Assert.AreEqual(DefaultHead, departments.Head);
            Assert.AreEqual(1, departments.Groups.Count);
            Assert.AreEqual(DefaultGroupName, departments.Groups.SingleOrDefault().Name);
        }

        [Test]
        public void WhenAddNewDepartmentWithGroupsToEmptyCollection_ShouldCollectionIncludeOneElement()
        {
            // Arrange
            var repo = new DepartmentService();
            var startingDepartments = repo.GetDepartments().Where(d => d.Name == DefaultName && d.Head == DefaultHead);

            // Act
            var department = new Department { Name = DefaultName, Head = DefaultHead };
            department.Groups ??= new List<Group>();
            department.Groups.Add(new Group { Name = DefaultGroupName });
            department.Groups.Add(new Group { Name = DefaultGroupName });

            repo.Add(department);
            var departments = repo.GetDepartments().SingleOrDefault(d => d.Name == DefaultName && d.Head == DefaultHead);

            //Assert
            Assert.IsTrue(!startingDepartments.Any());
            Assert.IsNotNull(departments);
            Assert.AreEqual(DefaultName, departments.Name);
            Assert.AreEqual(DefaultHead, departments.Head);
            Assert.AreEqual(2, departments.Groups.Count);
            foreach (var departmentsGroup in departments.Groups)
            {
                Assert.AreEqual(DefaultGroupName, departmentsGroup.Name);
            }
            
        }
    }
}