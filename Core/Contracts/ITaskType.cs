using Core.DTO.Request;
using Core.DTO.Response;
using Core.Entities;

namespace Core.Contracts
{
    public interface ITaskType
    {
        Task<TaskTypeResponse> GetTaskTypeById(Guid taskId);
        Task<List<TaskTypeResponse>> GetAllTaskTypes();
        Task<TaskTypeAddRequest> AddTaskType(TaskTypeAddRequest request);
        Task<TaskTypeResponse> UpdateTaskType(TaskType taskName);
        Task<bool> DeleteProject(Guid taskId);
    }

}
