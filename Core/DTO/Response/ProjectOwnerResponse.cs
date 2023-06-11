namespace Core.DTO.Response
{
    public class ProjectOwnerResponse
    {
        public Guid ProjectOwnerId { get; set; }
        public string? Name { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(ProjectOwnerResponse)) return false;

            ProjectOwnerResponse other = (ProjectOwnerResponse)obj;
            return ProjectOwnerId == other.ProjectOwnerId && Name == other.Name;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    public static class ProjectOwnerExtension
    {
        public static ProjectOwnerResponse ToProjectOwnerResponse(this ProjectOwnerResponse projectOwnerResponse)
        {
            return new ProjectOwnerResponse
            {
                ProjectOwnerId = projectOwnerResponse.ProjectOwnerId,
                Name = projectOwnerResponse.Name
            };
        }
    }
}
