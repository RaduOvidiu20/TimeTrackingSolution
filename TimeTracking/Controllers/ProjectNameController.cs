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
        List<ProjectName> projectNames = await _projectNameRepository.GetAllProjectNames();
        ViewBag.Projects = await _projectNameRepository.GetAllProjectNames();
        return View(projectNames);
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> Create()
    {
        List<ProjectName> projectNames = await _projectNameRepository.GetAllProjectNames();
        ViewBag.Projects = projectNames.Select(pn => new SelectListItem()
            { Text = pn.Name, Value = pn.ProjectNameId.ToString() });
        return View();
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Create(ProjectName projectName)
    {
        ProjectName newProjectName = await _projectNameRepository.AddProject(projectName);
        return RedirectToAction("GetAll", "ProjectName");
    }

    [HttpGet]
    [Route("[action]/{projectId}")]
    public async Task<IActionResult> Edit(Guid projectId)
    {
        ProjectName projectName = await _projectNameRepository.GetProjectNameById(projectId);
        if (projectName == null)
        {
            RedirectToAction("GetAll");
        }

        List<ProjectName> projectNames = await _projectNameRepository.GetAllProjectNames();
        ViewBag.Projects = projectNames.Select(pn => new SelectListItem()
            { Text = pn.Name, Value = pn.ProjectNameId.ToString() });
        ProjectName updatedProject = await _projectNameRepository.UpdateProject(projectName);
        return View(updatedProject);
    }

    [HttpPost]
    [Route("[action]/{projectId}")]
    public async Task<IActionResult> Edit(ProjectName projectName)
    {
        ProjectName newProject = await _projectNameRepository.GetProjectNameById(projectName.ProjectNameId);
        if (newProject == null)
        {
            RedirectToAction("GetAll");
        }

        ProjectName updatedProject = await _projectNameRepository.UpdateProject(projectName);
        return RedirectToAction("GetAll");
    }

    [HttpGet]
    [Route("[action]/{projectId}")]
    public async Task<IActionResult> Delete(Guid projectId)
    {
        ProjectName projectName = await _projectNameRepository.GetProjectNameById(projectId);
        if (projectName == null)
        {
            RedirectToAction("GetAll");
        }

        await _projectNameRepository.DeleteProject(projectId);
        return View(projectName);
    }

    [HttpPost]
    [Route("[action]/{projectId}")]
    public async Task<IActionResult> Delete(ProjectName projectName)
    {
        ProjectName newProjectName = await _projectNameRepository.GetProjectNameById(projectName.ProjectNameId);
        if (projectName == null)
        {
            RedirectToAction("GetAll");
        }

        await _projectNameRepository.DeleteProject(projectName.ProjectNameId);
        return View(projectName);
    }
}