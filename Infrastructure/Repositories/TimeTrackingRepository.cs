using Core.Contracts;
using Core.Entities;
using Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories;

public class TimeTrackingRepository : ITimeTracking
{
    private readonly ApplicationDbContext _db;
    private readonly ILogger<TimeTrackingRepository> _logger;

    public TimeTrackingRepository(ApplicationDbContext db, ILogger<TimeTrackingRepository> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<TimeTracking> AddTimeTracking(TimeTracking timeTracking)
    {
        _db.Add(timeTracking);
        await _db.SaveChangesAsync();
        _logger.LogDebug("AddTimeTracking method has been called for record with id {Id}", timeTracking.TimeTrackingId);
        return timeTracking;
    }

    public async Task<bool> DeleteTimeTracking(Guid timeTrackingId)
    {
        _db.RemoveRange(_db.TimeTracking.Where(t => t.TimeTrackingId == timeTrackingId));
        var deletedRows = await _db.SaveChangesAsync();
        _logger.LogDebug("DeleteTimeTracking method has been called for record with id {Id}", timeTrackingId);
        return deletedRows > 0;
    }

    public async Task<List<TimeTracking>> GetAllTimeTracking()
    {
        _logger.LogDebug("GetAllTimeTracking method has been called ");
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
        return await _db.TimeTracking.FindAsync(timeTrackingId) ??
               throw new Exception($"Record with id {timeTrackingId} could not be found.");
    }

    public async Task<TimeTracking> UpdateTimeTracking(TimeTracking timeTracking)
    {
        var matchingTimeTracking =
            await _db.TimeTracking.FirstOrDefaultAsync(t => t.TimeTrackingId == timeTracking.TimeTrackingId);
        if (matchingTimeTracking == null)
            return timeTracking;
        matchingTimeTracking.Customers = timeTracking.Customers;
        matchingTimeTracking.Employees = timeTracking.Employees;
        matchingTimeTracking.ProjectNames = timeTracking.ProjectNames;
        matchingTimeTracking.ProjectOwners = timeTracking.ProjectOwners;
        matchingTimeTracking.TaskTypes = timeTracking.TaskTypes;
        matchingTimeTracking.WorkedHours = timeTracking.WorkedHours;
        matchingTimeTracking.StartDate = timeTracking.StartDate;
        matchingTimeTracking.EndDate = timeTracking.EndDate;
        matchingTimeTracking.Comment = timeTracking.Comment;
        matchingTimeTracking.RecordStatus = timeTracking.RecordStatus;
        await _db.SaveChangesAsync();
        _logger.LogDebug("UpdateTimeTracking method has been called for record with id {Id}",
            timeTracking.TimeTrackingId);
        return matchingTimeTracking;
    }
}