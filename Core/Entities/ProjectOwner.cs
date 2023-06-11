namespace Core.Entities
{
    public class ProjectOwner
    {
        public Guid ProjectOwnerId { get; set; }
        public string? Name { get; set; }

        public override string ToString()
        {
            return $"Id: {ProjectOwnerId}, Name: {Name}";
        }
    }
}
