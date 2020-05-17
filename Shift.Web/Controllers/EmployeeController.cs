using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Shift.Services.Managers.Employee;

namespace Shift.Web.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeManager _employeeManager;

        public EmployeeController(IEmployeeManager manager)
        {
            this._employeeManager = manager;
        }

        [Route("undergraduates")]
        [HttpGet]
        public IActionResult GetUndergraduates([FromQuery] int userId)
        {
            var undergraduates = this._employeeManager.GetUndergraduates(userId).ToList();

            return Ok(new  { Undergraduates = undergraduates });
        }

        [Route("graduates")]
        [HttpGet]
        public IActionResult GetGraduates([FromQuery] int userId)
        {
            var graduates = this._employeeManager.GetGraduates(userId).ToList();

            return Ok(new { Graduates = graduates });
        }
    }
}