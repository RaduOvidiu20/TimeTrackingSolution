using Core.Contracts;
using Core.Entities;
using Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class EmployeeRepository : IEmployee
{
    private readonly ApplicationDbContext _db;

    public EmployeeRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Employee> AddEmployee(Employee employee)
    {
        _db.Employees.Add(employee);
        await _db.SaveChangesAsync();
        return employee;
    }

    public async Task<bool> DeleteEmployee(Guid employeeId)
    {
        _db.Employees.RemoveRange(_db.Employees.Where(t => t.EmployeeId == employeeId));
        var deletedRows = await _db.SaveChangesAsync();
        return deletedRows > 0;
    }

    public async Task<List<Employee>> GetAllEmployees()
    {
        return await _db.Employees.OrderBy(t => t.Name).ToListAsync();
    }

    public async Task<Employee> GetEmployeeById(Guid employeeId)
    {
        return await _db.Employees.FindAsync(employeeId) ??
               throw new Exception($"Employee with id {employeeId} could not be found.");
    }

    public async Task<Employee> UpdateEmployee(Employee employee)
    {
        var matchingEmployee =
            await _db.Employees.FirstOrDefaultAsync(t => t.EmployeeId == employee.EmployeeId);
        if (matchingEmployee == null) 
            return employee;

        matchingEmployee.Name = employee.Name;
        matchingEmployee.Age = employee.Age;
        matchingEmployee.Phone = employee.Phone;
        await _db.SaveChangesAsync();
        return matchingEmployee;
    }
}