using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.BLL.Interfaces;
using Talabat.BLL.Specifications;
using Talabat.DAL.Entities;

namespace Talabat.Api.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class EmployeeController : ControllerBase
    //{
    //    public EmployeeController(IGenericRepository<Employee> employeeRepo)
    //    {
    //        _EmployeeRepo = employeeRepo;
    //    }

    //    public IGenericRepository<Employee> _EmployeeRepo { get; set; }

    //    [HttpGet]
    //    public async Task<ActionResult<IReadOnlyList<Employee> >> GetAll()
    //    {
    //        var EmpSpecs = new EmployeeWithDeptSpecification();
    //        var Employees = await _EmployeeRepo.GetAllWithSpecs(EmpSpecs);
    //        return Ok(Employees);
        
    //    }
    //}
}
