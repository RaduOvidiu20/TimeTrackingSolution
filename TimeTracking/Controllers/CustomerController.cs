using Core.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TimeTracking.Web.Controllers
{
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerController(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Customer> customers = await _customerRepository.GetAllCustomers();
            return View(customers);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<Customer> customers = await _customerRepository.GetAllCustomers();
            ViewBag.Customers = customers.Select(c => new SelectListItem()
                { Text = c.Name, Value = c.CustomerId.ToString() });
            return View();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            Customer newCustomer = await _customerRepository.AddCustomer(customer);

            return RedirectToAction("GetAll", "Customer");
        }

        [Route("[action]/{customerId}")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid customerId)
        {
            Customer? customer = await _customerRepository.GetCustomerById(customerId);
            if (customer == null)
            {
                RedirectToAction("GetAll");
            }

            List<Customer> customers = await _customerRepository.GetAllCustomers();
            ViewBag.Customers = customers.Select(c => new SelectListItem()
                { Text = c.Name, Value = c.CustomerId.ToString() });
            return View(customer);
        }

        [Route("[action]/{customerId}")]
        [HttpPost]
        public async Task<IActionResult> Edit(Customer customer)
        {
            Customer? customerModel = await _customerRepository.GetCustomerById(customer.CustomerId);
            if (customerModel == null)
            {
                RedirectToAction("GetAll");
            }

            Customer updatedCustomer = await _customerRepository.UpdateCustomer(customer);
            return RedirectToAction("GetAll");
        }

        [Route("[action]/{customerId}")]
        [HttpGet]
        public async Task<IActionResult> Delete(Guid customerId)
        {
            Customer? customer = await _customerRepository.GetCustomerById(customerId);
            if (customer == null)
            {
                RedirectToAction("GetAll");
            }

            return View(customer);
        }

        [Route("[action]/{customerId}")]
        [HttpPost]
        public async Task<IActionResult> Delete(Customer customer)
        {
            Customer? customerModel = await _customerRepository.GetCustomerById(customer.CustomerId);
            if (customerModel == null)
            {
                RedirectToAction("GetAll");
            }

            await _customerRepository.DeleteCustomer(customer.CustomerId);
            return RedirectToAction("GetAll");
        }
    }
}