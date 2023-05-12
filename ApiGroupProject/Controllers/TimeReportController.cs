using ApiGroupProject.Services;
using Library;
using Microsoft.AspNetCore.Mvc;

namespace ApiGroupProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeReportController : ControllerBase
    {

        private ITimeReportRepository _Time;

        public TimeReportController(ITimeReportRepository time)
        {
            _Time = time;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _Time.GetAll());
        }


        [HttpPut("UpdateTimeReport")]
        public async Task<IActionResult> UpdateTimeReport(int id, TimeReport emp)
        {
            var uTime = await _Time.UpdateTimeReport(id, emp);
            if (uTime != null)
            {
                return Ok(uTime);
            }
            return NotFound("not found");
        }

        [HttpPost("AddTimeReport")]
        public async Task<IActionResult> AddTimeReport(TimeReport emp)
        {
            var addTR = await _Time.AddTimeReport(emp);
            if (addTR != null)
            {
                return Ok(addTR);
            }
            return NotFound("not found");

        }

        [HttpDelete("DeleteTimeReport")]

        public async Task<IActionResult> Delete(int id)
        {
            var delete = await _Time.DeleteTimeReport(id);

            if (delete != null)
            {
                return Ok(delete);
            }

            return NotFound("not found");
        }
    }
}