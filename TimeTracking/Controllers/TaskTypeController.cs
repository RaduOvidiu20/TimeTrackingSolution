using Core.Contracts;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TimeTracking.Web.Controllers;

[Route("[controller]")]
public class TaskTypeController : Controller
{
    private readonly ITaskType _taskTypeRepository;

    public TaskTypeController(ITaskType taskTypeRepository)
    {
        _taskTypeRepository = taskTypeRepository;
    }

    [HttpGet]
    [Route("[controller]")]
    public async Task<IActionResult> GetAll()
    {
        var taskTypes = await _taskTypeRepository.GetAllTaskTypes();
        
        ViewBag.Tasks = await _taskTypeRepository.GetAllTaskTypes();
        
        return View(taskTypes);
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> Create()
    {
        var taskTypes = await _taskTypeRepository.GetAllTaskTypes();
        
        ViewBag.Tasks = taskTypes.Select(t => new SelectListItem { Text = t.Name, Value = t.TaskTypeId.ToString() });
        
        return PartialView("_Create");
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Create(TaskType taskType)
    {
        var newTaskType = await _taskTypeRepository.AddTaskType(taskType);
        
        return RedirectToAction("GetAll", "TaskType");
    }

    [HttpGet]
    [Route("[action]/{taskId}")]
    public async Task<IActionResult> Edit(Guid taskId)
    {
        var newTaskType = await _taskTypeRepository.GetTaskTypeById(taskId);
        
        if (newTaskType == null)
            RedirectToAction("GetAll");

        var taskTypes = await _taskTypeRepository.GetAllTaskTypes();
        
        ViewBag.Tasks = taskTypes.Select(t => new SelectListItem { Text = t.Name, Value = t.TaskTypeId.ToString() });

        var updatedTaskType = await _taskTypeRepository.UpdateTaskType(newTaskType);
        
        return PartialView("_Edit", updatedTaskType);
    }

    [HttpPost]
    [Route("[action]/{taskId}")]
    public async Task<IActionResult> Edit(TaskType taskType)
    {
        var newTaskType = await _taskTypeRepository.GetTaskTypeById(taskType.TaskTypeId);
        
        if (newTaskType == null) 
            RedirectToAction("GetAll");

        var updatedTaskType = await _taskTypeRepository.UpdateTaskType(taskType);
        
        return RedirectToAction("GetAll");
    }

    [HttpGet]
    [Route("[action]/{taskId}")]
    public async Task<IActionResult> Delete(Guid taskId)
    {
        var taskType = await _taskTypeRepository.GetTaskTypeById(taskId);
        
        if (taskType == null)
            RedirectToAction("GetAll");

        await _taskTypeRepository.DeleteTask(taskId);
        
        return PartialView("_Delete", taskType);
    }

    [HttpPost]
    [Route("[action]/{taskId}")]
    public async Task<IActionResult> Delete(TaskType taskType)
    {
        var newTaskType = await _taskTypeRepository.GetTaskTypeById(taskType.TaskTypeId);
        
        if (newTaskType == null)
            RedirectToAction("GetAll");

        await _taskTypeRepository.DeleteTask(taskType.TaskTypeId);
        
        return RedirectToAction("GetAll");
    }
}