using Core.Entities;

namespace Core.Contracts;

public interface ICustomer
{/// <summary>
 /// Task used for getting customer by current id from the database
 /// </summary>
 /// <param name="customerId"></param>
 /// <returns>CustomerId</returns>
    Task<Customer> GetCustomerById(Guid customerId);
 
 /// <summary>
 /// Task used to get all customers from database
 /// </summary>
 /// <returns>List of customers</returns>
    Task<List<Customer>> GetAllCustomers();
 
 /// <summary>
 /// Task used to add new customer from the database based on the data provided by frontend
 /// </summary>
 /// <param name="customer"></param>
 /// <returns>Add new customer</returns>
    Task<Customer> AddCustomer(Customer customer);
 
 /// <summary>
 /// Task used to update the details for the selected customer
 /// </summary>
 /// <param name="customer"></param>
 /// <returns>Updated customer</returns>
    Task<Customer> UpdateCustomer(Customer customer);
 
 /// <summary>
 /// Task used to delete customer from the database based on selected CustomerId
 /// </summary>
 /// <param name="customerId"></param>
 /// <returns>Deleted CustomerId</returns>
    Task<bool> DeleteCustomer(Guid customerId);
}