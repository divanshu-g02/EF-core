
using EF_core.Model;

namespace EF_core.Service
{
    public interface IEmployeeService
    {
        public Task<List<Employee>> GetAllEmployeesAsync();
        public Task<Employee?> GetEmployeeByIdAsync(int id);
        public Task<Employee> AddEmployeeAsync(Employee newEmployee);
        public Task<bool> DeleteEmployeeAsync(int id);
        public Task<Employee> UpdateEmployeeAsync(int id, Employee employee);

        public Task<Employee?> ValidateUser(string Email, string Password);

    }
}
