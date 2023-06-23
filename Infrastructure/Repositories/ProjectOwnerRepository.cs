using Core.Contracts;
using Core.Entities;
using Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories;

public class ProjectOwnerRepository : IProjectOwner
{
    private readonly ApplicationDbContext _db;
    private readonly ILogger<ProjectOwnerRepository> _logger;

    public ProjectOwnerRepository(ApplicationDbContext db, ILogger<ProjectOwnerRepository> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<ProjectOwner> AddProjectOwner(ProjectOwner request)
    {
        _db.ProjectOwners.Add(request);
        await _db.SaveChangesAsync();
        _logger.LogDebug("AddProjectOwner method has been called for Owner {Name}", request.Name);
        return request;
    }

    public async Task<bool> DeleteProjectOwner(Guid projectOwnerId)
    {
        _db.RemoveRange(_db.ProjectOwners.Where(t => t.ProjectOwnerId == projectOwnerId));
        var deletedRows = await _db.SaveChangesAsync();
        _logger.LogDebug("DeleteProjectOwner method has been called for OwnerId {Id}", projectOwnerId);
        return deletedRows > 0;
    }

    public async Task<List<ProjectOwner>> GetAllProjectOwners()
    {
        _logger.LogDebug("GetAllProjectOwners method has been called");
        return await _db.ProjectOwners.OrderBy(t => t.Name).ToListAsync();
    }

    public async Task<ProjectOwner> GetProjectOwnerById(Guid projectOwnerId)
    {
        return await _db.ProjectOwners.FindAsync(projectOwnerId) ??
               throw new Exception($"Owner with id {projectOwnerId} could not be found.");
    }

    public async Task<ProjectOwner> UpdateProjectOwner(ProjectOwner projectOwner)
    {
        var matchingProjectOwner =
            await _db.ProjectOwners.FirstOrDefaultAsync(t => t.ProjectOwnerId == projectOwner.ProjectOwnerId);
        if (matchingProjectOwner == null)
            return projectOwner;
        matchingProjectOwner.Name = projectOwner.Name;
        await _db.SaveChangesAsync();
        _logger.LogDebug("UpdateProjectOwner method has been called for Owner {Name}", projectOwner.Name);
        return matchingProjectOwner;
    }
}