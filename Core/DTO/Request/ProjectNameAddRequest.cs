using Core.Entities;

namespace Core.DTO.Request
{
    public class ProjectNameAddRequest

    {
        public string? Name { get; set; }
        public ProjectName ToProjectName()
        {
            return new ProjectName() { Name = Name };
        }

    }
}
