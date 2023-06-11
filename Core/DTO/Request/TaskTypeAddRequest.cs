using Core.Entities;

namespace Core.DTO.Request
{
    public class TaskTypeAddRequest
    {
        public string? Name { get; set; }
        public TaskType ToTaskType()
        {
            return new TaskType { Name = Name };
        }
    }
}
