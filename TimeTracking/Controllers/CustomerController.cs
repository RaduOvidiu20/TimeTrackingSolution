﻿using Core.Contracts;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TimeTracking.Web.Controllers;

[Route("[controller]")]
[Authorize(Roles = "Admin")]
public class CustomerController : Controller
{
    private readonly ICustomer _customer;
    private readonly ILogger<CustomerController> _logger;

    public CustomerController(ICustomer customer, ILogger<CustomerController> logger)
    {
        _customer = customer;
        _logger = logger;
    }

    [Route("[action]")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customers = await _customer.GetAllCustomers();

        ViewBag.Customers = await _customer.GetAllCustomers();

        return View(customers);
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> Create()
    {
        var customers = await _customer.GetAllCustomers();

        ViewBag.Customers = customers.Select(c => new SelectListItem
            { Text = c.Name, Value = c.CustomerId.ToString() });

        return PartialView("_Create");
    }

    [Route("[action]")]
    [HttpPost]
    public async Task<IActionResult> Create(Customer customer)
    {
        var newCustomer = await _customer.AddCustomer(customer);
        _logger.LogInformation("Create action method of  CustomersController");
        return RedirectToAction("GetAll", "Customer");
    }

    [Route("[action]/{customerId}")]
    [HttpGet]
    public async Task<IActionResult> Edit(Guid customerId)
    {
        var customers = await _customer.GetAllCustomers();

        ViewBag.Customers = customers.Select(c => new SelectListItem
            { Text = c.Name, Value = c.CustomerId.ToString() });

        var customer = await _customer.GetCustomerById(customerId);

        if (customer == null)
            RedirectToAction("GetAll");

        return PartialView("_Edit", customer);
    }

    [Route("[action]/{customerId}")]
    [HttpPost]
    public async Task<IActionResult> Edit(Customer customer)
    {
        var customerModel = await _customer.GetCustomerById(customer.CustomerId);

        if (customerModel == null)
            RedirectToAction("GetAll");

        await _customer.UpdateCustomer(customer);
        _logger.LogInformation("Edit action method of  CustomersController");
        return RedirectToAction("GetAll");
    }


    [Route("[action]/{customerId}")]
    [HttpGet]
    public async Task<IActionResult> Delete(Guid customerId)
    {
        var customer = await _customer.GetCustomerById(customerId);

        if (customer == null)
            RedirectToAction("GetAll");

        return PartialView("_Delete", customer);
    }

    [Route("[action]/{customerId}")]
    [HttpPost]
    public async Task<IActionResult> Delete(Customer customer)
    {
        var customerModel = await _customer.GetCustomerById(customer.CustomerId);

        if (customerModel == null)
            RedirectToAction("GetAll");

        await _customer.DeleteCustomer(customer.CustomerId);
        _logger.LogInformation("Delete action method of  CustomersController");
        return RedirectToAction("GetAll");
    }
}