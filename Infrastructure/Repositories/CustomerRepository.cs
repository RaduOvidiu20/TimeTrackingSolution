using Core.Contracts;
using Core.Entities;
using Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

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
        var deletedRows = await _db.SaveChangesAsync();
        return deletedRows > 0;
    }

    public async Task<List<Customer>> GetAllCustomers()
    {
        return await _db.Customers.ToListAsync();
    }

    public async Task<Customer> GetCustomerById(Guid customerId)
    {
        return await _db.Customers.FindAsync(customerId) ??
               throw new Exception($"Customer with id{customerId} could not be found.");
    }

    public async Task<Customer> UpdateCustomer(Customer customer)
    {
        var matchingCustomer =
            await _db.Customers.FirstOrDefaultAsync(t => t.CustomerId == customer.CustomerId);
        if (matchingCustomer == null)
            return customer;

        matchingCustomer.Name = customer.Name;
        matchingCustomer.Email = customer.Email;
        matchingCustomer.Phone = customer.Phone;
        await _db.SaveChangesAsync();
        return matchingCustomer;
    }
}