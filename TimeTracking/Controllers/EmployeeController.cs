using Core.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TimeTracking.Web.Controllers;

[Route("[controller]")]
public class EmployeeController : Controller
{
    private readonly EmployeeRepository _employeeRepository;

    public EmployeeController(EmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetAll()
    {
        List<Employee> employees = await _employeeRepository.GetAllEmployees();
        ViewBag.Employees = employees.Select(e => new SelectListItem()
            { Text = e.Name, Value = e.EmployeeId.ToString() });
        return View(employees);
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> Create()
    {
        List<Employee> employees = await _employeeRepository.GetAllEmployees();
        ViewBag.Employees = employees.Select(e => new SelectListItem()
            { Text = e.Name, Value = e.EmployeeId.ToString() });
        return View();
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Create(Employee employee)
    {
        Employee newEmployee = await _employeeRepository.AddEmployee(employee);
        return RedirectToAction("GetAll", "Employee");
    }

    [HttpGet]
    [Route("[action]/{employeeId}")]
    public async Task<IActionResult> Edit(Guid employeeId)
    {
        Employee employee = await _employeeRepository.GetEmployeeById(employeeId);
        if (employee == null)
        {
            RedirectToAction("GetAll");
        }

        List<Employee> employees = await _employeeRepository.GetAllEmployees();
        ViewBag.Employees = employees.Select(e => new SelectListItem()
            { Text = e.Name, Value = e.EmployeeId.ToString() });
        Employee updatedEmployee = await _employeeRepository.UpdateEmployee(employee);

        return View(updatedEmployee);
    }

    [HttpPost]
    [Route("[action]/{employeeId}")]
    public async Task<IActionResult> Edit(Employee employee)
    {
        Employee newEmployee = await _employeeRepository.GetEmployeeById(employee.EmployeeId);
        if (employee == null)
        {
            RedirectToAction("GetAll");
        }

        Employee updatedEmployee = await _employeeRepository.UpdateEmployee(employee);
        return RedirectToAction("GetAll");
    }

    [HttpGet]
    [Route("[action]/{employeeId}")]
    public async Task<IActionResult> Delete(Guid employeeId)
    {
        Employee employee = await _employeeRepository.GetEmployeeById(employeeId);
        if (employee == null)
        {
            RedirectToAction("GetAll");
        }

        Employee updatedEmployee = await _employeeRepository.UpdateEmployee(employee);

        return View(updatedEmployee);
    }

    [HttpPost]
    [Route("[action]/{employeeId}")]
    public async Task<IActionResult> Delete(Employee employeeId)
    {
        Employee employee = await _employeeRepository.GetEmployeeById(employeeId.EmployeeId);
        if (employee == null)
        {
            RedirectToAction("GetAll");
        }

        await _employeeRepository.DeleteEmployee(employee.EmployeeId);
        return RedirectToAction("GetAll");
    }
}