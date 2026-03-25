using EF_core.Model;

namespace EF_core.Repository
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> AddNewEmployee(Employee newEmployee);
        Task<bool> DeleteEmployeeById(int id);
        Task<Employee> UpdateEmployeeInfo(int id, Employee employee);
    }
}
