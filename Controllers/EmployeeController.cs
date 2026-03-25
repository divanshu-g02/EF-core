using EF_core.Model;
using EF_core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace EF_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            return Ok(await _service.GetAllEmployeesAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var Employee = await _service.GetEmployeeByIdAsync(id);
            if(Employee == null)
            {
                return NotFound();
            }
            return Ok(Employee);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewEmployee(Employee employee)
        {
            try
            {
                var created = await _service.AddEmployeeAsync(employee);
                return CreatedAtAction(nameof(GetEmployeeById), new { id = created.EmployeeId }, created);    
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                var UpdateEmp = await _service.UpdateEmployeeAsync(id, employee);
                return Ok(employee);
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(ex.Message);

            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var emp = _service.DeleteEmployeeAsync(id);
                return Ok(emp);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);

            }
        }
    }
}
