using Core.Contracts;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TimeTracking.Web.Controllers;

[Route("[controller]")]
[Authorize(Roles = "Admin")]
public class EmployeeController : Controller
{
    private readonly IEmployee _employeeRepository;
    private readonly ILogger<EmployeeController> _logger;

    public EmployeeController(IEmployee employee, ILogger<EmployeeController> logger)
    {
        _employeeRepository = employee;
        _logger = logger;
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetAll()
    {
        var employees = await _employeeRepository.GetAllEmployees();

        ViewBag.Employees = await _employeeRepository.GetAllEmployees();
        
        _logger.LogInformation("GetAll action method of  EmployeeController");
        return View();
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> Create()
    {
        var employees = await _employeeRepository.GetAllEmployees();

        ViewBag.Employees = employees.Select(e => new SelectListItem
            { Text = e.Name, Value = e.EmployeeId.ToString() });
        
        return PartialView("_Create");
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Create(Employee employee)
    {
        var newEmployee = await _employeeRepository.AddEmployee(employee);
        _logger.LogInformation("Create action method of  EmployeeController");
        return RedirectToAction("GetAll", "Employee");
    }

    [HttpGet]
    [Route("[action]/{employeeId}")]
    public async Task<IActionResult> Edit(Guid employeeId)
    {
        var employee = await _employeeRepository.GetEmployeeById(employeeId);

        if (employee == null)
            RedirectToAction("GetAll");

        var employees = await _employeeRepository.GetAllEmployees();

        ViewBag.Employees = employees.Select(e => new SelectListItem
            { Text = e.Name, Value = e.EmployeeId.ToString() });

        return PartialView("_Edit", employee);
    }

    [HttpPost]
    [Route("[action]/{employeeId}")]
    public async Task<IActionResult> Edit(Employee employee)
    {
        var newEmployee = await _employeeRepository.GetEmployeeById(employee.EmployeeId);

        if (newEmployee == null)
            RedirectToAction("GetAll");

        var updatedEmployee = await _employeeRepository.UpdateEmployee(employee);
        _logger.LogInformation("Edit action method of  EmployeeController");
        return RedirectToAction("GetAll");
    }

    [Route("[action]/{employeeId}")]
    [HttpGet]
    public async Task<IActionResult> Delete(Guid employeeId)
    {
        var employee = await _employeeRepository.GetEmployeeById(employeeId);

        if (employee == null)
            RedirectToAction("GetAll");

        return PartialView("_Delete", employee);
    }

    [Route("[action]/{employeeId}")]
    [HttpPost]
    public async Task<IActionResult> Delete(Employee employee)
    {
        var employeeModel = await _employeeRepository.GetEmployeeById(employee.EmployeeId);

        if (employeeModel == null)
            RedirectToAction("GetAll");

        await _employeeRepository.DeleteEmployee(employee.EmployeeId);
        _logger.LogInformation("Delete action method of  EmployeeController");
        return RedirectToAction("GetAll");
    }
}