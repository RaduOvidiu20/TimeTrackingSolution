namespace Core.Entities
{
    public class TaskType
    {
        public Guid TaskTypeId { get; set; }
        public string? Name { get; set; }
        public override string ToString()
        {
            return $"Id: {TaskTypeId}, Name: {Name}";
        }
    }
}
