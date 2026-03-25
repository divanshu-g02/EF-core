using EF_core.Model;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EF_core.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }

        public IQueryable<Employee> GetAllEmployees()
        {
            return _context.Employees.OrderBy(e => e.FirstName);
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
        }

        public async Task<Employee> AddNewEmployee(Employee newEmployee)
        {
            _context.Employees.Add(newEmployee);
            await _context.SaveChangesAsync();
            return newEmployee; 
        }

        public async Task<bool> DeleteEmployeeById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if(employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Employee> UpdateEmployeeInfo(int id, Employee UpdateEmployee)
        {
            var existingEmployee = await _context.Employees.FindAsync(UpdateEmployee.EmployeeId);
            if(existingEmployee != null)
            {
                existingEmployee.FirstName = UpdateEmployee.FirstName;
                existingEmployee.LastName = UpdateEmployee.LastName;
                existingEmployee.Email = UpdateEmployee.Email;
                existingEmployee.Address = UpdateEmployee.Address;
                existingEmployee.PhoneNo = UpdateEmployee.PhoneNo;
            }

            await _context.SaveChangesAsync();
            return existingEmployee;
        }

    }
}
