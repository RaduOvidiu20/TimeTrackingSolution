using Core.Entities;

namespace Core.Contracts;

public interface IProjectName
{
    Task<ProjectName> GetProjectNameById(Guid projectId);
    Task<List<ProjectName>> GetAllProjectNames();
    Task<ProjectName> AddProject(ProjectName request);
    Task<ProjectName> UpdateProject(ProjectName projectName);
    Task<bool> DeleteProject(Guid projectId);
}