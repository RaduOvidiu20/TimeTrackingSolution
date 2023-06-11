using Core.DTO.Request;
using Core.DTO.Response;
using Core.Entities;

namespace Core.Contracts
{
    public interface ITimeTracking
    {
        Task<TimeTrackingResponse> GetTimeTrackingById(Guid timeTrackingId);
        Task<List<TimeTrackingResponse>> GetAllTimeTrackings();
        Task<TimeTrackingAddRequest> AddTimeTracking(TimeTrackingAddRequest request);
        Task<TimeTrackingResponse> UpdateTimeTracking(TimeTracking timeTracking);
        Task<bool> DeleteTimeTracking(Guid timeTrackingId);
    }
}
