using ApiGroupProject.Services;
using Library;
using Microsoft.AspNetCore.Mvc;

namespace ApiGroupProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private IEmployeeRepository __emprepo;

        public EmployeeController(IEmployeeRepository emprepo)
        {
            __emprepo = emprepo;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await __emprepo.GetAll());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmployeeTimeReport(int id)
        {
            try
            {
                var time = await __emprepo.GetTimeReportsOfEmployee(id);
                if (time.Any())
                {
                    return Ok(time);
                }
                return NotFound($"Person with {id} not found");
            }
            catch
            {
                return BadRequest("Invalid request!");
            }
        }
        [HttpGet("EmployeesWithAProject/{id:int}")]
        public async Task<IActionResult> GetAllEmployeesByPro(int id)
        {
            var project = await __emprepo.GetAllEmployeesByProject(id);
            if (project.Any())
            {
                return Ok(project);
            }

            return NotFound($"Project with {id} not found");
        }

        [HttpGet("GetHoursWorked")]
        public async Task<IActionResult> GetHours(int id, int week)
        {
            var worker = await __emprepo.GetHoursWorked(id, week);

            if (worker != null)
            {
                return Ok(worker);
            }
            return NotFound($"Not found");

        }

        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmp(int id, Employee emp)
        {
            var worker = await __emprepo.UpdateEmployee(id, emp);
            if (worker != null)
            {
                return Ok(worker);
            }
            return NotFound("not found");
        }

        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee(Employee emp)
        {
            var worker = await __emprepo.AddEmployee(emp);
            if (worker != null)
            {
                return Ok(worker);
            }
            return NotFound("not found");

        }

        [HttpDelete("DeleteEmployee")]

        public async Task<IActionResult> Delete(int id)
        {

            var delete = await __emprepo.DeleteEmployee(id);

            if (delete != null)
            {
                return Ok(delete);
            }

            return NotFound("not found");
        }

    }
}