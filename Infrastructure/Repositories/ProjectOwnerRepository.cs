using Core.Contracts;
using Core.Entities;
using Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProjectOwnerRepository : IProjectOwner
{
    private readonly ApplicationDbContext _db;

    public ProjectOwnerRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<ProjectOwner> AddProjectOwner(ProjectOwner request)
    {
        _db.ProjectOwners.Add(request);
        await _db.SaveChangesAsync();
        return request;
    }

    public async Task<bool> DeleteProject(Guid projectOwnerId)
    {
        _db.RemoveRange(_db.ProjectOwners.Where(t => t.ProjectOwnerId == projectOwnerId));
        var deletedRows = await _db.SaveChangesAsync();
        return deletedRows > 0;
    }

    public async Task<List<ProjectOwner>> GetAllProjectOwners()
    {
        return await _db.ProjectOwners.OrderBy(t => t.Name).ToListAsync();
    }

    public async Task<ProjectOwner> GetProjectOwnerById(Guid projectOwnerId)
    {
        return await _db.ProjectOwners.FindAsync(projectOwnerId) ??
               throw new Exception($"Owner with id {projectOwnerId} could not be found.");
    }

    public async Task<ProjectOwner> UpdateProject(ProjectOwner projectOwner)
    {
        var matchingProjectOwner =
            await _db.ProjectOwners.FirstOrDefaultAsync(t => t.ProjectOwnerId == projectOwner.ProjectOwnerId);
        if (matchingProjectOwner == null) 
            return projectOwner;
        matchingProjectOwner.Name = projectOwner.Name;
        await _db.SaveChangesAsync();
        return matchingProjectOwner;
    }
}