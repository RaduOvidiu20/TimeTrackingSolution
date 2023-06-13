using Core.Contracts;
using Core.Entities;
using Infrastructure.AplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TimeTrackingRepository : ITimeTracking
    {
        private readonly ApplicationDbContext _db;
        public TimeTrackingRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<TimeTracking> AddTimeTracking(TimeTracking request)
        {
            _db.TimeTrackings.AddAsync(request);
            await _db.SaveChangesAsync();
            return request;
        }

        public async Task<bool> DeleteTimeTracking(Guid timeTrackingId)
        {
            _db.RemoveRange(_db.TimeTrackings.Where(t => t.TimeTrackingId == timeTrackingId));
            int deletedRows = await _db.SaveChangesAsync();
            return deletedRows > 0;

        }

        public async Task<List<TimeTracking>> GetAllTimeTrackings()
        {
            return await _db.TimeTrackings.OrderBy(t => t.TimeTrackingId).ToListAsync();
        }

        public async Task<TimeTracking> GetTimeTrackingById(Guid timeTrackingId)
        {
            return await _db.TimeTrackings.FindAsync(timeTrackingId);
        }

        public async Task<TimeTracking> UpdateTimeTracking(TimeTracking timeTracking)
        {
            TimeTracking matchingTimeTracking = await _db.TimeTrackings.FirstOrDefaultAsync(t => t.TimeTrackingId == timeTracking.TimeTrackingId);
            if (matchingTimeTracking != null) { return timeTracking; }
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
            return matchingTimeTracking;
        }
    }
}
