using EF_core.Model;
using EF_core.Repository;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace EF_core.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeService(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _repo.GetAllEmployees().ToListAsync();
        }
        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _repo.GetEmployeeById(id);
        }

        public async Task<Employee> AddEmployeeAsync(Employee newEmployee)
        {
            if (string.IsNullOrWhiteSpace(newEmployee.FirstName))
            {
                throw new ArgumentException("First name is required.");
            }
            if (string.IsNullOrWhiteSpace(newEmployee.Email))
            {
                throw new ArgumentException("Email is required.");
            }

            return await _repo.AddNewEmployee(newEmployee);
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var existingEmployee = await _repo.GetEmployeeById(id);

            if(existingEmployee == null)
            {
                throw new KeyNotFoundException($"Employee {id} not found.");
            }

            return await _repo.DeleteEmployeeById(id);
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, Employee employee)
        {
            var existing = await _repo.GetEmployeeById(id);

            if(existing == null)
            {
                throw new KeyNotFoundException($"Employee {id} not found");
            }
            employee.EmployeeId = id;
            return await _repo.UpdateEmployeeInfo(id, employee);
        }

        public async Task<Employee?> ValidateUser(string email, string password)
        {
            var employee = await _repo.GetAllEmployees().FirstOrDefaultAsync(m => m.Email == email && m.Password == password);
            return employee;
        }

    }
}
