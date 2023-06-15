using Core.Contracts;
using Core.Entities;
using Infrastructure.AplicationDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : ICustomer
    {
        private readonly ApplicationDbContext _db;
        public CustomerRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Customer> AddCustomer(Customer customer)
        {
            _db.Customers.Add(customer);
            await _db.SaveChangesAsync();
            return customer;

        }

        public async Task<bool> DeleteCustomer(Guid customerId)
        {
            _db.Customers.RemoveRange(_db.Customers.Where(temp => temp.CustomerId == customerId));
            int deletedRows = await _db.SaveChangesAsync();
            return deletedRows > 0;

        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _db.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerById(Guid customerId)
        {
            return await _db.Customers.FindAsync(customerId);
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            Customer matchigCustomer = await _db.Customers.FirstOrDefaultAsync(t => t.CustomerId == customer.CustomerId);
            if (matchigCustomer == null)
            {
                return customer;
            }
            matchigCustomer.Name = customer.Name;
            matchigCustomer.Email = customer.Email;
            matchigCustomer.Phone = customer.Phone;
            await _db.SaveChangesAsync();
            return matchigCustomer;
        }
    }
}
