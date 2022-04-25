using Example.Domain.Entities;
using Example.Services;
using Microsoft.AspNetCore.Mvc;

namespace Example.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _repo;

        public DepartmentController(IDepartmentService repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public Department Get(int id)
        {
            return _repo.GetDepartmentById(id);
        }
    }
}