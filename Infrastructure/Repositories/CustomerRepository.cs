using Core.Contracts;
using Core.Entities;
using Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories;

public class CustomerRepository : ICustomer
{
    private readonly ApplicationDbContext _db;
    private readonly ILogger<CustomerRepository> _logger;

    public CustomerRepository(ApplicationDbContext db, ILogger<CustomerRepository> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<Customer> AddCustomer(Customer customer)
    {
        _db.Customers.Add(customer);
        await _db.SaveChangesAsync();

        _logger.LogDebug("AddCustomer method has been called for customer {Name}", customer.Name);

        return customer;
    }

    public async Task<bool> DeleteCustomer(Guid customerId)
    {
        _db.Customers.RemoveRange(_db.Customers.Where(temp => temp.CustomerId == customerId));
        var deletedRows = await _db.SaveChangesAsync();
        _logger.LogDebug("Delete method for customer with id {Id} has been called", customerId);
        return deletedRows > 0;
    }

    public async Task<List<Customer>> GetAllCustomers()
    {
        _logger.LogDebug("GetAll method has been called");
        return await _db.Customers.ToListAsync();
    }

    public async Task<Customer> GetCustomerById(Guid customerId)
    {
        _logger.LogDebug("GetCustomerById method for customer with id {Id} has been called", customerId);
        return await _db.Customers.FindAsync(customerId) ??
               throw new Exception($"Customer with id {customerId} could not be found.");
        
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
        _logger.LogDebug("UpdateCustomer method for customer {Name} has been called", customer.Name);
        return matchingCustomer;
    }
}