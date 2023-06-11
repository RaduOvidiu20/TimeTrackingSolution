using Core.Contracts;
using Core.Entities;
using Infrastructure.AplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
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
            int deletedRows = await _db.SaveChangesAsync();
            return deletedRows > 0;

        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _db.Employees.Include(t => t.EmployeeId).ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(Guid employeeId)
        {
            return await _db.Employees.FindAsync(employeeId);
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            Employee matchingEmployee = await _db.Employees.FirstOrDefaultAsync(t => t.EmployeeId == employee.EmployeeId);
            if (matchingEmployee != null)
            {
                return employee;
            }
            matchingEmployee.Name = employee.Name;
            matchingEmployee.Age = employee.Age;
            matchingEmployee.Phone = employee.Phone;

            return matchingEmployee;
        }
    }
}
