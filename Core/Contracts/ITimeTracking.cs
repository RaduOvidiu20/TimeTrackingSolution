﻿using Core.Entities;

namespace Core.Contracts;

public interface ITimeTracking
{
    Task<TimeTracking> GetTimeTrackingById(Guid timeTrackingId);
    Task<List<TimeTracking>> GetAllTimeTracking();
    Task<TimeTracking> AddTimeTracking(TimeTracking timeTracking);
    Task<TimeTracking> UpdateTimeTracking(TimeTracking timeTracking);
    Task<bool> DeleteTimeTracking(Guid timeTrackingId);
}