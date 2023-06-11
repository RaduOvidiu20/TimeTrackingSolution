using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class ProjectName
    {
        [Key]
        public Guid ProjectNameId { get; set; }
        public string? Name { get; set; }
        public override string ToString()
        {
            return $"Id: {ProjectNameId}, Name: {Name}";
        }
    }
}
