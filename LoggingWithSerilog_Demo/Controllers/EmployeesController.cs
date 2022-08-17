using LoggingWithSerilog_Demo.DataServices;
using Microsoft.AspNetCore.Mvc;

namespace LoggingWithSerilog_Demo.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class EmployeesController : Controller
    {
        private EmployeeServices _employeeServices;
        private ILogger<EmployeesController> _logger;

        public EmployeesController(EmployeeServices employeeServices,ILogger<EmployeesController> logger)
        {
            _employeeServices = employeeServices;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            //try
            //{
                _logger.LogInformation("fetching data  Of Employee Inside Index Method Line 23  ");
                var employee= _employeeServices.GetEmployee();
                if (employee == null)
                {
                    _logger.LogInformation("Employee table is Empty now");

                    return NotFound();
                }
                else
                {
                    throw new Exception("Somthing wrong { Just Use of custom  Middle ware}");
                   // _logger.LogInformation("Employee Data Successfully returned");
                    return Ok(employee);
                }

                

            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError($" {ex.Message} Internal server Error....");
            //    return StatusCode(500,$" {ex.Message} Internal server Error....");
            //}
        }
    }
}
