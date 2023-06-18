using Core.Entities;

namespace Core.Contracts;

public interface ICustomer
{
    Task<Customer> GetCustomerById(Guid customerId);
    Task<List<Customer>> GetAllCustomers();
    Task<Customer> AddCustomer(Customer customer);
    Task<Customer> UpdateCustomer(Customer customer);
    Task<bool> DeleteCustomer(Guid customerId);
}