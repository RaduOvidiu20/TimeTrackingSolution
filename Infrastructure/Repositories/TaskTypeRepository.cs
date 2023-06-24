using Core.Contracts;
using Core.Entities;
using Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories;

public class TaskTypeRepository : ITaskType
{
    private readonly ApplicationDbContext _db;
    private readonly ILogger<TaskTypeRepository> _logger;

    public TaskTypeRepository(ApplicationDbContext db, ILogger<TaskTypeRepository> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<TaskType> AddTaskType(TaskType request)
    {
        _db.TaskTypes.Add(request);
        await _db.SaveChangesAsync();
        _logger.LogDebug("AddTaskType method has been called for Task {Name}", request.Name);
        return request;
    }

    public async Task<bool> DeleteTask(Guid taskId)
    {
        _db.RemoveRange(_db.TaskTypes.Where(t => t.TaskTypeId == taskId));
        var deletedRows = await _db.SaveChangesAsync();
        _logger.LogDebug("DeleteTask method has been called for Task {Id}", taskId);
        return deletedRows > 0;
    }

    public async Task<List<TaskType>> GetAllTaskTypes()
    {
        _logger.LogDebug("GetAllTaskTypes method has been called");
        return await _db.TaskTypes.OrderBy(t => t.Name).ToListAsync();
    }

    public async Task<TaskType> GetTaskTypeById(Guid taskId)
    {
        return await _db.TaskTypes.FindAsync(taskId) ??
               throw new Exception($"Task with id {taskId} could not be found.");
    }

    public async Task<TaskType> UpdateTaskType(TaskType taskName)
    {
        var matchingTaskType =
            await _db.TaskTypes.FirstOrDefaultAsync(t => t.TaskTypeId == taskName.TaskTypeId);
        if (matchingTaskType == null)
            return taskName;
        matchingTaskType.Name = taskName.Name;
        await _db.SaveChangesAsync();
        _logger.LogDebug("UpdateTask method has been called for Task {Name}", taskName.Name);
        return matchingTaskType;
    }
}