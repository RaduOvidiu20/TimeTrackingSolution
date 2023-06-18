using Core.Contracts;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TimeTracking.Web.Controllers;

[Route("[controller]")]
public class ProjectOwnerController : Controller
{
    private readonly IProjectOwner _projectOwnerRepository;

    public ProjectOwnerController(IProjectOwner projectOwnerRepository)
    {
        _projectOwnerRepository = projectOwnerRepository;
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetAll()
    {
        var projectOwners = await _projectOwnerRepository.GetAllProjectOwners();
        
        ViewBag.Owners = await _projectOwnerRepository.GetAllProjectOwners();
        
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
        
        return RedirectToAction("GetAll", "ProjectOwner");
    }

    [HttpGet]
    [Route("[action]/{ownerId}")]
    public async Task<IActionResult> Edit(Guid ownerId)
    {
        var projectOwner = await _projectOwnerRepository.GetProjectOwnerById(ownerId);
        
        if (projectOwner == null)
            RedirectToAction("GetAll");

        var projectOwners = await _projectOwnerRepository.GetAllProjectOwners();
        
        ViewBag.Owners = projectOwners.Select(po => new SelectListItem
            { Text = po.Name, Value = po.ProjectOwnerId.ToString() });
        
        var updatedProjectOwner = await _projectOwnerRepository.UpdateProject(projectOwner);
        
        return PartialView("_Edit", updatedProjectOwner);
    }

    [HttpPost]
    [Route("[action]/{ownerId}")]
    public async Task<IActionResult> Edit(ProjectOwner projectOwner)
    {
        var newProject = await _projectOwnerRepository.GetProjectOwnerById(projectOwner.ProjectOwnerId);
        
        if (newProject == null)
            RedirectToAction("GetAll");

        var updatedProject = await _projectOwnerRepository.UpdateProject(projectOwner);
        
        return RedirectToAction("GetAll");
    }

    [HttpGet]
    [Route("[action]/{ownerId}")]
    public async Task<IActionResult> Delete(Guid ownerId)
    {
        var projectOwner = await _projectOwnerRepository.GetProjectOwnerById(ownerId);
        
        if (projectOwner == null)
            RedirectToAction("GetAll");

        await _projectOwnerRepository.DeleteProject(ownerId);
        
        return PartialView("_Delete", projectOwner);
    }

    [HttpPost]
    [Route("[action]/{ownerId}")]
    public async Task<IActionResult> Delete(ProjectOwner ownerId)
    {
        var newProjectName = await _projectOwnerRepository.GetProjectOwnerById(ownerId.ProjectOwnerId);
        
        if (newProjectName == null) 
            RedirectToAction("GetAll");

        await _projectOwnerRepository.DeleteProject(ownerId.ProjectOwnerId);
        
        return RedirectToAction("GetAll");
    }
}