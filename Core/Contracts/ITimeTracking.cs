using Core.Entities;

namespace Core.Contracts
{
    public interface ITimeTracking
    {
        Task<TimeTracking> GetTimeTrackingById(Guid timeTrackingId);
        Task<List<TimeTracking>> GetAllTimeTrackings();
        Task<TimeTracking> AddTimeTracking(TimeTracking request);
        Task<TimeTracking> UpdateTimeTracking(TimeTracking timeTracking);
        Task<bool> DeleteTimeTracking(Guid timeTrackingId);
    }
}
