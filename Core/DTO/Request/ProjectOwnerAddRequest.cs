using Core.Entities;

namespace Core.DTO.Request
{
    public class ProjectOwnerAddRequest
    {
        public string? Name { get; set; }
        public ProjectOwner ToProjectOwner()
        {
            return new ProjectOwner() { Name = Name };
        }
    }
}

