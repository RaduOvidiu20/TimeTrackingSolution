using Core.Entities;

namespace Core.Contracts;

public interface ITaskType
{
    Task<TaskType> GetTaskTypeById(Guid taskId);
    Task<List<TaskType>> GetAllTaskTypes();
    Task<TaskType> AddTaskType(TaskType request);
    Task<TaskType> UpdateTaskType(TaskType taskName);
    Task<bool> DeleteTask(Guid taskId);
}