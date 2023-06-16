using Core.Contracts;
using Core.Entities;
using Infrastructure.AplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProjectNameRepository : IProjectName
    {
        private readonly ApplicationDbContext _db;
        public ProjectNameRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ProjectName> AddProject(ProjectName request)
        {
            _db.ProjectNames.AddAsync(request);
            await _db.SaveChangesAsync();
            return request;
        }

        public async Task<bool> DeleteProject(Guid projectId)
        {
            _db.RemoveRange(_db.ProjectNames.Where(t => t.ProjectNameId == projectId));
            int deletedRows = await _db.SaveChangesAsync();
            return deletedRows > 0;

        }

        public async Task<List<ProjectName>> GetAllProjectNames()
        {
            return await _db.ProjectNames.OrderBy(t => t.Name).ToListAsync();
        }

        public async Task<ProjectName> GetProjectNameById(Guid projectId)
        {
            return await _db.ProjectNames.FindAsync(projectId);
        }

        public async Task<ProjectName> UpdateProject(ProjectName projectName)
        {
            ProjectName matchingProjectName = await _db.ProjectNames.FirstOrDefaultAsync(t => t.ProjectNameId == projectName.ProjectNameId);
            if (matchingProjectName == null)
            {
                return projectName;
            }
            matchingProjectName.Name = projectName.Name;
            await _db.SaveChangesAsync();
            return matchingProjectName;
        }
    }
}
