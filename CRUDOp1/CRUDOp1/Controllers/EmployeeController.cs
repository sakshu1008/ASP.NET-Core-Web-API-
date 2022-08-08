using CRUDOp1.Data;
using CRUDOp1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDOp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeAPIDbContext _context;

        public EmployeeController(EmployeeAPIDbContext dbContext)
        {
            this._context = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            return Ok(await _context.employees.ToListAsync());
        }


        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {
            var emp = await _context.employees.FindAsync(id);
            if(emp != null)
            {
                return Ok(emp);
            }
            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEmployeeRequest addEmployeeRequest)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                FullName = addEmployeeRequest.FullName,
                Email = addEmployeeRequest.Email,
                Address = addEmployeeRequest.Address,
                Gender = addEmployeeRequest.Gender
            };
             await _context.employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return Ok(employee);
        }


        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id,UpdateEmployeeRequest updateEmployeeRequest)
        {
            var emp = await _context.employees.FindAsync(id);
            if(emp != null)
            {
                emp.FullName = updateEmployeeRequest.FullName;
                emp.Gender = updateEmployeeRequest.Gender;
                emp.Email = updateEmployeeRequest.Email;
                emp.Address = updateEmployeeRequest.Address;

                await _context.SaveChangesAsync();
                return Ok(emp);
            }
            return NotFound();
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var emp = await _context.employees.FindAsync(id);
            if(emp != null)
            {
                _context.employees.Remove(emp);
                await _context.SaveChangesAsync();
                return Ok(emp);
            }
            return NotFound();
        }
    }
}
