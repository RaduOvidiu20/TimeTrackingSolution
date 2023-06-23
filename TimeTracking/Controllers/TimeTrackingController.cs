using Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TimeTracking.Web.Controllers;

[Route("[controller]")]
public class TimeTrackingController : Controller
{
    private readonly ICustomer _customerRepository;
    private readonly IEmployee _employeeRepository;
    private readonly IProjectName _projectNameRepository;
    private readonly IProjectOwner _projectOwnerRepository;
    private readonly ITaskType _taskTypeRepository;
    private readonly ILogger<TimeTrackingController> _logger;
    private readonly ITimeTracking _timeTrackingRepository;

    public TimeTrackingController(
        ITimeTracking timeTrackingRepository,
        ICustomer customerRepository,
        IEmployee employeeRepository,
        IProjectName projectNameRepository,
        IProjectOwner projectOwnerRepository,
        ITaskType taskTypeRepository,
        ILogger<TimeTrackingController> logger
        )
    {
        _timeTrackingRepository = timeTrackingRepository;
        _projectNameRepository = projectNameRepository;
        _employeeRepository = employeeRepository;
        _projectOwnerRepository = projectOwnerRepository;
        _customerRepository = customerRepository;
        _taskTypeRepository = taskTypeRepository;
        _logger = logger;
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetAll()
    {
        var timeTracking = await _timeTrackingRepository.GetAllTimeTracking();

        ViewBag.TimeTracking = await _timeTrackingRepository.GetAllTimeTracking();
        _logger.LogInformation("GetAll action method of  TimeTrackingController");
        return View(timeTracking);
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> Create()
    {
        var customers = await _customerRepository.GetAllCustomers();
        var employees = await _employeeRepository.GetAllEmployees();
        var projectNames = await _projectNameRepository.GetAllProjectNames();
        var projectOwners = await _projectOwnerRepository.GetAllProjectOwners();
        var taskTypes = await _taskTypeRepository.GetAllTaskTypes();

        ViewBag.Customers = customers.Select(c => new SelectListItem
            { Text = c.Name, Value = c.CustomerId.ToString() }).ToList();
        ViewBag.Employees = employees.Select(e => new SelectListItem
            { Text = e.Name, Value = e.EmployeeId.ToString() }).ToList();
        ViewBag.ProjectNames = projectNames.Select(pn => new SelectListItem
            { Text = pn.Name, Value = pn.ProjectNameId.ToString() }).ToList();
        ViewBag.ProjectOwners = projectOwners.Select(po => new SelectListItem
            { Text = po.Name, Value = po.ProjectOwnerId.ToString() }).ToList();
        ViewBag.TaskTypes = taskTypes.Select(t => new SelectListItem
            { Text = t.Name, Value = t.TaskTypeId.ToString() }).ToList();

        return PartialView("_Create");
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Create(Core.Entities.TimeTracking timeTracking)
    {
        await _timeTrackingRepository.AddTimeTracking(timeTracking);
        _logger.LogInformation("Create action method of  TimeTrackingController");
        return RedirectToAction("GetAll", "TimeTracking");
    }

    [HttpGet]
    [Route("[action]/{timeTrackingId}")]
    public async Task<IActionResult> Edit(Guid timeTrackingId)
    {
        var customers = await _customerRepository.GetAllCustomers();
        var employees = await _employeeRepository.GetAllEmployees();
        var projectNames = await _projectNameRepository.GetAllProjectNames();
        var projectOwners = await _projectOwnerRepository.GetAllProjectOwners();
        var taskTypes = await _taskTypeRepository.GetAllTaskTypes();

        ViewBag.Customers = customers.Select(c => new SelectListItem
            { Text = c.Name, Value = c.CustomerId.ToString() }).ToList();
        ViewBag.Employees = employees.Select(e => new SelectListItem
            { Text = e.Name, Value = e.EmployeeId.ToString() }).ToList();
        ViewBag.ProjectNames = projectNames.Select(pn => new SelectListItem
            { Text = pn.Name, Value = pn.ProjectNameId.ToString() }).ToList();
        ViewBag.ProjectOwners = projectOwners.Select(po => new SelectListItem
            { Text = po.Name, Value = po.ProjectOwnerId.ToString() }).ToList();
        ViewBag.TaskTypes = taskTypes.Select(t => new SelectListItem
            { Text = t.Name, Value = t.TaskTypeId.ToString() }).ToList();

        var timeTracking = await _timeTrackingRepository.GetTimeTrackingById(timeTrackingId);

        if (timeTracking == null)
            RedirectToAction("GetAll");

       
        return PartialView("_Edit", timeTracking);
    }

    [HttpPost]
    [Route("[action]/{timeTrackingId}")]
    public async Task<IActionResult> Edit(Core.Entities.TimeTracking timeTracking)
    {
        var newTimeTracking =
            await _timeTrackingRepository.GetTimeTrackingById(timeTracking.TimeTrackingId);

        if (newTimeTracking == null)
            RedirectToAction("GetAll");

        var updatedTimeTracking = await _timeTrackingRepository.UpdateTimeTracking(timeTracking);
        _logger.LogInformation("Edit action method of  TimeTrackingController");
        return RedirectToAction("GetAll");
    }

    [HttpGet]
    [Route("[action]/{timeTrackingId}")]
    public async Task<IActionResult> Delete(Guid timeTrackingId)
    {
        var timeTracking = await _timeTrackingRepository.GetTimeTrackingById(timeTrackingId);

        if (timeTracking == null)
            RedirectToAction("GetAll");

        return PartialView("_Delete", timeTracking);
    }

    [HttpPost]
    [Route("[action]/{timeTrackingId}")]
    public async Task<IActionResult> Delete(Core.Entities.TimeTracking timeTracking)
    {
        var newTimeTracking =
            await _timeTrackingRepository.GetTimeTrackingById(timeTracking.TimeTrackingId);

        if (newTimeTracking == null)
            RedirectToAction("GetAll");

        await _timeTrackingRepository.DeleteTimeTracking(timeTracking.TimeTrackingId);
        _logger.LogInformation("Delete action method of  TimeTrackingController");
        return RedirectToAction("GetAll");
    }
}