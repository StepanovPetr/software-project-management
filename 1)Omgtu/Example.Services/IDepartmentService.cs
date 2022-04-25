using Example.Domain.Entities;

namespace Example.Services
{
    public interface IDepartmentService
    {
        Department GetDepartmentById(int id);
    }
}