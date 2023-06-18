using Core.Entities;

namespace Core.Contracts;

public interface IEmployee
{
    Task<Employee> GetEmployeeById(Guid employeeId);
    Task<List<Employee>> GetAllEmployees();
    Task<Employee> AddEmployee(Employee employee);
    Task<Employee> UpdateEmployee(Employee employee);
    Task<bool> DeleteEmployee(Guid employeeId);
}