using Core.Entities;

namespace Core.Contracts;

public interface IProjectOwner
{
    Task<ProjectOwner> GetProjectOwnerById(Guid projectOwnerId);
    Task<List<ProjectOwner>> GetAllProjectOwners();
    Task<ProjectOwner> AddProjectOwner(ProjectOwner request);
    Task<ProjectOwner> UpdateProjectOwner(ProjectOwner projectOwner);
    Task<bool> DeleteProjectOwner(Guid projectOwnerId);
}