using Core.Contracts;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TimeTracking.Web.Controllers;

[Route("[controller]")]
public class ProjectNameController : Controller
{
    private readonly IProjectName _projectNameRepository;

    public ProjectNameController(IProjectName projectNameRepository)
    {
        _projectNameRepository = projectNameRepository;
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetAll()
    {
        var projectNames = await _projectNameRepository.GetAllProjectNames();
        
        ViewBag.Projects = await _projectNameRepository.GetAllProjectNames();
        
        return View(projectNames);
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> Create()
    {
        var projectNames = await _projectNameRepository.GetAllProjectNames();
        
        ViewBag.Projects = projectNames.Select(pn => new SelectListItem
            { Text = pn.Name, Value = pn.ProjectNameId.ToString() });
        
        return PartialView("_Create");
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Create(ProjectName projectName)
    {
        var newProjectName = await _projectNameRepository.AddProject(projectName);
        
        return RedirectToAction("GetAll", "ProjectName");
    }

    [HttpGet]
    [Route("[action]/{projectId}")]
    public async Task<IActionResult> Edit(Guid projectId)
    {
        var projectName = await _projectNameRepository.GetProjectNameById(projectId);
        
        if (projectName == null) 
            RedirectToAction("GetAll");

        var projectNames = await _projectNameRepository.GetAllProjectNames();
        
        ViewBag.Projects = projectNames.Select(pn => new SelectListItem
            { Text = pn.Name, Value = pn.ProjectNameId.ToString() });

        var updatedProject = await _projectNameRepository.UpdateProject(projectName);

        return PartialView("_Edit", updatedProject);
    }

    [HttpPost]
    [Route("[action]/{projectId}")]
    public async Task<IActionResult> Edit(ProjectName project)
    {
        var newProject = await _projectNameRepository.GetProjectNameById(project.ProjectNameId);
        
        if (newProject == null) 
            RedirectToAction("GetAll");

        var updatedProject = await _projectNameRepository.UpdateProject(project);

        return RedirectToAction("GetAll");
    }

    [Route("[action]/{projectId}")]
    [HttpGet]
    public async Task<IActionResult> Delete(Guid projectId)
    {
        var projectName = await _projectNameRepository.GetProjectNameById(projectId);
        
        if (projectName == null)
            RedirectToAction("GetAll");

        await _projectNameRepository.DeleteProject(projectId);
        
        return PartialView("_Delete", projectName);
    }

    [Route("[action]/{projectId}")]
    [HttpPost]
    public async Task<IActionResult> Delete(ProjectName projectName)
    {
        var newProjectName = await _projectNameRepository.GetProjectNameById(projectName.ProjectNameId);
        
        if (newProjectName == null) 
            RedirectToAction("GetAll");

        await _projectNameRepository.DeleteProject(projectName.ProjectNameId);
        
        return RedirectToAction("GetAll");
    }
}