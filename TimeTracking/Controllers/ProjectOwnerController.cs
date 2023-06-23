using Core.Contracts;
using Core.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TimeTracking.Web.Controllers;

[Route("[controller]")]
public class ProjectOwnerController : Controller
{
    private readonly IProjectOwner _projectOwnerRepository;
    private readonly ILogger<ProjectOwnerController> _logger;

    public ProjectOwnerController(IProjectOwner projectOwnerRepository, ILogger<ProjectOwnerController> logger)
    {
        _projectOwnerRepository = projectOwnerRepository;
        _logger = logger;
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetAll()
    {
        var projectOwners = await _projectOwnerRepository.GetAllProjectOwners();

        ViewBag.Owners = await _projectOwnerRepository.GetAllProjectOwners();
        _logger.LogInformation("GetAll action method of  ProjectOwnerController");
        return View(projectOwners);
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> Create()
    {
        var projectOwners = await _projectOwnerRepository.GetAllProjectOwners();

        ViewBag.Owners = projectOwners.Select(po => new SelectListItem
            { Text = po.Name, Value = po.ProjectOwnerId.ToString() });

        return PartialView("_Create");
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Create(ProjectOwner projectOwner)
    {
        var newProjectOwner = await _projectOwnerRepository.AddProjectOwner(projectOwner);
        _logger.LogInformation("Create action method of  ProjectOwnerController");
        return RedirectToAction("GetAll", "ProjectOwner");
    }

    [HttpGet]
    [Route("[action]/{ownerId}")]
    public async Task<IActionResult> Edit(Guid ownerId)
    {
        var projectOwners = await _projectOwnerRepository.GetAllProjectOwners();

        ViewBag.Owners = projectOwners.Select(po => new SelectListItem
            { Text = po.Name, Value = po.ProjectOwnerId.ToString() });

        var projectOwner = await _projectOwnerRepository.GetProjectOwnerById(ownerId);

        if (projectOwner == null)
            RedirectToAction("GetAll");
    
        return PartialView("_Edit",projectOwner);
    }

    [HttpPost]
    [Route("[action]/{ownerId}")]
    public async Task<IActionResult> Edit(ProjectOwner projectOwner)
    {
        var newProject = await _projectOwnerRepository.GetProjectOwnerById(projectOwner.ProjectOwnerId);

        if (newProject == null)
            RedirectToAction("GetAll");

        var updatedProject = await _projectOwnerRepository.UpdateProjectOwner(projectOwner);
        _logger.LogInformation("Edit action method of  ProjectOwnerController");
        return RedirectToAction("GetAll");
    }

    [HttpGet]
    [Route("[action]/{ownerId}")]
    public async Task<IActionResult> Delete(Guid ownerId)
    {
        var projectOwner = await _projectOwnerRepository.GetProjectOwnerById(ownerId);

        if (projectOwner == null)
            RedirectToAction("GetAll");

        return PartialView("_Delete", projectOwner);
    }

    [HttpPost]
    [Route("[action]/{ownerId}")]
    public async Task<IActionResult> Delete(ProjectOwner ownerId)
    {
        var newProjectName = await _projectOwnerRepository.GetProjectOwnerById(ownerId.ProjectOwnerId);

        if (newProjectName == null)
            RedirectToAction("GetAll");

        await _projectOwnerRepository.DeleteProjectOwner(ownerId.ProjectOwnerId);
        _logger.LogInformation("Delete action method of  ProjectOwnerController");
        return RedirectToAction("GetAll");
    }
}