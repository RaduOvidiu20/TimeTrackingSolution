using Core.Contracts;
using Core.Entities;
using Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories;

public class ProjectNameRepository : IProjectName
{
    private readonly ApplicationDbContext _db;
    private readonly ILogger<ProjectNameRepository> _logger;

    public ProjectNameRepository(ApplicationDbContext db, ILogger<ProjectNameRepository> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<ProjectName> AddProject(ProjectName request)
    {
        _db.ProjectNames.Add(request);
        await _db.SaveChangesAsync();
        _logger.LogDebug("AddProject method has been called for the project {Project}", request.Name);
        return request;
    }

    public async Task<bool> DeleteProject(Guid projectId)
    {
        _db.RemoveRange(_db.ProjectNames.Where(t => t.ProjectNameId == projectId));
        var deletedRows = await _db.SaveChangesAsync();
        _logger.LogDebug("DeleteProject method has been called for project with id {Id}", projectId);
        return deletedRows > 0;
    }

    public async Task<List<ProjectName>> GetAllProjectNames()
    {
        _logger.LogDebug("GetAllProjectNames method has been called");
        return await _db.ProjectNames.OrderBy(t => t.Name).ToListAsync();
    }

    public async Task<ProjectName> GetProjectNameById(Guid projectId)
    {
        return await _db.ProjectNames.FindAsync(projectId) ??
               throw new Exception($"Project with id {projectId} could not be found.");
    }

    public async Task<ProjectName> UpdateProject(ProjectName projectName)
    {
        var matchingProjectName =
            await _db.ProjectNames.FirstOrDefaultAsync(t => t.ProjectNameId == projectName.ProjectNameId);
        if (matchingProjectName == null) 
            return projectName;
        matchingProjectName.Name = projectName.Name;
        await _db.SaveChangesAsync();
        _logger.LogDebug("UpdateProject method has been called for project {Name}", projectName.Name);
        return matchingProjectName;
    }
}