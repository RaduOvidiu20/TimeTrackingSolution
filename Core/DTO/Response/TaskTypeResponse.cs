namespace Core.DTO.Response
{
    public class TaskTypeResponse
    {
        public Guid TaskTypeId { get; set; }
        public string? Name { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(TaskTypeResponse)) return false;

            TaskTypeResponse other = (TaskTypeResponse)obj;
            return TaskTypeId == other.TaskTypeId && Name == other.Name;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    public static class TaskTypeResponseExtensions
    {
        public static TaskTypeResponse ToTaskTypeResponse(this TaskTypeResponse response)
        {
            return new TaskTypeResponse()
            {
                TaskTypeId = response.TaskTypeId,
                Name = response.Name,
            };
        }
    }
}
