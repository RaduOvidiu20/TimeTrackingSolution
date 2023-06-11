namespace Core.DTO.Response
{
    public class ProjectNameResponse
    {
        public Guid ProjectNameId { get; set; }
        public string? Name { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(ProjectNameResponse)) return false;

            ProjectNameResponse other = (ProjectNameResponse)obj;
            return ProjectNameId == other.ProjectNameId && Name == other.Name;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    public static class ProjectNameExtension
    {
        public static ProjectNameResponse ToProjectNameResponse(this ProjectNameResponse projectNameResponse)
        {
            return new ProjectNameResponse()
            {
                ProjectNameId = projectNameResponse.ProjectNameId,
                Name = projectNameResponse.Name
            };
        }
    }
}
