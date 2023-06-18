using Core.Contracts;
using Core.Entities;
using Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class TimeTrackingRepository : ITimeTracking
{
    private readonly ApplicationDbContext _db;

    public TimeTrackingRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<TimeTracking> AddTimeTracking(TimeTracking request)
    {
        _db.TimeTracking.Add(request);
        await _db.SaveChangesAsync();
        return request;
    }

    public async Task<bool> DeleteTimeTracking(Guid timeTrackingId)
    {
        _db.RemoveRange(_db.TimeTracking.Where(t => t.TimeTrackingId == timeTrackingId));
        var deletedRows = await _db.SaveChangesAsync();
        return deletedRows > 0;
    }

    public async Task<List<TimeTracking>> GetAllTimeTracking()
    {
        return await _db.TimeTracking
            .Include(t => t.Customer)
            .Include(t => t.Employee)
            .Include(t => t.ProjectName)
            .Include(t => t.ProjectOwner)
            .Include(t => t.TaskType)
            .ToListAsync();
    }

    public async Task<TimeTracking> GetTimeTrackingById(Guid timeTrackingId)
    {
        return await _db.TimeTracking.FindAsync(timeTrackingId) ?? throw new Exception($"Record with id {timeTrackingId} could not be found.");
    }

    public async Task<TimeTracking> UpdateTimeTracking(TimeTracking timeTracking)
    {
        var matchingTimeTracking =
            await _db.TimeTracking.FirstOrDefaultAsync(t => t.TimeTrackingId == timeTracking.TimeTrackingId);
        if (matchingTimeTracking == null) 
            return timeTracking;
        matchingTimeTracking.Customer = timeTracking.Customer;
        matchingTimeTracking.Employee = timeTracking.Employee;
        matchingTimeTracking.ProjectName = timeTracking.ProjectName;
        matchingTimeTracking.ProjectOwner = timeTracking.ProjectOwner;
        matchingTimeTracking.TaskType = timeTracking.TaskType;
        matchingTimeTracking.WorkedHours = timeTracking.WorkedHours;
        matchingTimeTracking.StartDate = timeTracking.StartDate;
        matchingTimeTracking.EndDate = timeTracking.EndDate;
        matchingTimeTracking.Comment = timeTracking.Comment;
        matchingTimeTracking.RecordStatus = timeTracking.RecordStatus;
        await _db.SaveChangesAsync();
        return matchingTimeTracking;
    }
}