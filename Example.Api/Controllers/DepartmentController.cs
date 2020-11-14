using Example.Domain.Entities;
using Example.Services;
using Microsoft.AspNetCore.Mvc;

namespace Example.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        [HttpGet]
        public Department Get(int id)
        {
            var repo = new DepartmentService();
            return repo.GetDepartmentById(id);
        }
    }
}