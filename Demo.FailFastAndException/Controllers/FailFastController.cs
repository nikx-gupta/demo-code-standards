using Demo.FailFastAndException.Business;
using Demo.FailFastAndException.Logging;
using Demo.FailFastAndException.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.FailFastAndException.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FailFastController : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly EmployeeService _employeeService;

        public FailFastController(ILogService logService, EmployeeService employeeService)
        {
            _logService = logService;
            _employeeService = employeeService;
        }

        [HttpPost]
        [ProducesResponseType(404)]
        public ActionResult TestFail([FromBody] EmployeeInfo employeeInfo)
        {
            
        }
    }
}