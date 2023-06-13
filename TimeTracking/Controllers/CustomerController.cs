﻿using Core.Contracts;
using Core.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TimeTracking.Web.Controllers
{
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomer _customer;


        public CustomerController(ICustomer customer)
        {
            _customer = customer;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Customer> customers = await _customer.GetAllCustomers();
            ViewBag.Customers = await _customer.GetAllCustomers();
            return View(customers);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<Customer> customers = await _customer.GetAllCustomers();
            ViewBag.Customers = customers.Select(c => new SelectListItem()
                { Text = c.Name, Value = c.CustomerId.ToString() });
            return View();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            Customer newCustomer = await _customer.AddCustomer(customer);

            return RedirectToAction("GetAll", "Customer");
        }

        [Route("[action]/{customerId}")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid customerId)
        {
            Customer? customer = await _customer.GetCustomerById(customerId);
            if (customer == null)
            {
                RedirectToAction("GetAll");
            }

            List<Customer> customers = await _customer.GetAllCustomers();
            ViewBag.Customers = customers.Select(c => new SelectListItem()
                { Text = c.Name, Value = c.CustomerId.ToString() });
            return View(customer);
        }

        [Route("[action]/{customerId}")]
        [HttpPost]
        public async Task<IActionResult> Edit(Customer customer)
        {
            Customer? customerModel = await _customer.GetCustomerById(customer.CustomerId);
            if (customerModel == null)
            {
                RedirectToAction("GetAll");
            }

            Customer updatedCustomer = await _customer.UpdateCustomer(customer);
            return RedirectToAction("GetAll");
        }

        [Route("[action]/{customerId}")]
        [HttpGet]
        public async Task<IActionResult> Delete(Guid customerId)
        {
            Customer? customer = await _customer.GetCustomerById(customerId);
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
            Customer? customerModel = await _customer.GetCustomerById(customer.CustomerId);
            if (customerModel == null)
            {
                RedirectToAction("GetAll");
            }

            await _customer.DeleteCustomer(customer.CustomerId);
            return RedirectToAction("GetAll");
        }
    }
}