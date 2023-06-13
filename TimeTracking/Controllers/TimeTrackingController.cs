using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace TimeTracking.Web.Controllers;

[Route("[controller]")]
public class TimeTrackingController : Controller
{
    private readonly TimeTrackingRepository _timeTrackingRepository;
    private readonly CustomerRepository _customerRepository;
    private readonly EmployeeRepository _employeeRepository;
    private readonly ProjectNameRepository _projectNameRepository;
    private readonly ProjectOwnerRepository _projectOwnerRepository;
    private readonly TaskTypeRepository _taskTypeRepository;

    public TimeTrackingController(
        TimeTrackingRepository timeTrackingRepository,
        CustomerRepository customerRepository,
        EmployeeRepository employeeRepository,
        ProjectNameRepository projectNameRepository,
        ProjectOwnerRepository projectOwnerRepository,
        TaskTypeRepository taskTypeRepository
    )
    {
        _timeTrackingRepository = timeTrackingRepository;
        _projectNameRepository = projectNameRepository;
        _employeeRepository = employeeRepository;
        _projectOwnerRepository = projectOwnerRepository;
        _customerRepository = customerRepository;
        _taskTypeRepository = taskTypeRepository;
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetAll()
    {
        List<Core.Entities.TimeTracking> timeTracking = await _timeTrackingRepository.GetAllTimeTrackings();
        return View(timeTracking);
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> Create()
    {
        List<Customer> customers = await _customerRepository.GetAllCustomers();
        List<Employee> employees = await _employeeRepository.GetAllEmployees();
        List<ProjectName> projectNames = await _projectNameRepository.GetAllProjectNames();
        List<ProjectOwner> projectOwners = await _projectOwnerRepository.GetAllProjectOwners();
        List<TaskType> taskTypes = await _taskTypeRepository.GetAllTaskTypes();

        ViewBag.Customers = customers.Select(c => new SelectListItem()
            { Text = c.Name, Value = c.CustomerId.ToString() });
        ViewBag.Employees = employees.Select(e => new SelectListItem()
            { Text = e.Name, Value = e.EmployeeId.ToString() });
        ViewBag.ProjectNames = projectNames.Select(pn => new SelectListItem()
            { Text = pn.Name, Value = pn.ProjectNameId.ToString() });
        ViewBag.ProjectOwners = projectOwners.Select(po => new SelectListItem()
            { Text = po.Name, Value = po.ProjectOwnerId.ToString() });
        ViewBag.TaskTypes = taskTypes.Select(t => new SelectListItem()
            { Text = t.Name, Value = t.TaskTypeId.ToString() });

        return View();
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Create(Core.Entities.TimeTracking timeTracking)
    {
        Core.Entities.TimeTracking newTimeTracking = await _timeTrackingRepository.AddTimeTracking(timeTracking);
        return RedirectToAction("GetAll", "TimeTracking");
    }

    [HttpGet]
    [Route("[action]/{timeTrackingId}")]
    public async Task<IActionResult> Edit(Guid timeTrackingId)
    {
        Core.Entities.TimeTracking timeTracking = await _timeTrackingRepository.GetTimeTrackingById(timeTrackingId);
        if (timeTracking == null)
        {
            RedirectToAction("GetAll");
        }
        List<Customer> customers = await _customerRepository.GetAllCustomers();
        List<Employee> employees = await _employeeRepository.GetAllEmployees();
        List<ProjectName> projectNames = await _projectNameRepository.GetAllProjectNames();
        List<ProjectOwner> projectOwners = await _projectOwnerRepository.GetAllProjectOwners();
        List<TaskType> taskTypes = await _taskTypeRepository.GetAllTaskTypes();

        ViewBag.Customers = customers.Select(c => new SelectListItem()
            { Text = c.Name, Value = c.CustomerId.ToString() });
        ViewBag.Employees = employees.Select(e => new SelectListItem()
            { Text = e.Name, Value = e.EmployeeId.ToString() });
        ViewBag.ProjectNames = projectNames.Select(pn => new SelectListItem()
            { Text = pn.Name, Value = pn.ProjectNameId.ToString() });
        ViewBag.ProjectOwners = projectOwners.Select(po => new SelectListItem()
            { Text = po.Name, Value = po.ProjectOwnerId.ToString() });
        ViewBag.TaskTypes = taskTypes.Select(t => new SelectListItem()
            { Text = t.Name, Value = t.TaskTypeId.ToString() });
        Core.Entities.TimeTracking updatedTimeTracking = await _timeTrackingRepository.UpdateTimeTracking(timeTracking);
        return View(updatedTimeTracking);
    }

    [HttpPost]
    [Route("[action]/{timeTrackingId}")]
    public async Task<IActionResult> Edit(Core.Entities.TimeTracking timeTracking)
    {
        Core.Entities.TimeTracking newTimeTracking =
            await _timeTrackingRepository.GetTimeTrackingById(timeTracking.TimeTrackingId);
        if (newTimeTracking == null)
        {
            RedirectToAction("GetAll");
        }

        Core.Entities.TimeTracking updatedTimeTracking = await _timeTrackingRepository.UpdateTimeTracking(timeTracking);
        return RedirectToAction("GetAll");

    }

    [HttpGet]
    [Route("[action]/{timeTrackingId}")]
    public async Task<IActionResult> Delete(Guid timeTrackingId)
    {
        Core.Entities.TimeTracking timeTracking = await _timeTrackingRepository.GetTimeTrackingById(timeTrackingId);
        if (timeTracking == null)
        {
            RedirectToAction("GetAll");
        }

        await _timeTrackingRepository.DeleteTimeTracking(timeTrackingId);
        return View(timeTracking);
    }

    [HttpPost]
    [Route("[action]/{timeTrackingId}")]
    public async Task<IActionResult> Delete(Core.Entities.TimeTracking timeTracking)
    {
        Core.Entities.TimeTracking newTimeTracking =
            await _timeTrackingRepository.GetTimeTrackingById(timeTracking.TimeTrackingId);
        if (newTimeTracking == null)
        {
            RedirectToAction("GetAll");
        }

        await _timeTrackingRepository.DeleteTimeTracking(timeTracking.TimeTrackingId);
        return View(timeTracking);
    }
}