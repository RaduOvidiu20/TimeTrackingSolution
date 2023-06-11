namespace Core.DTO.Response
{
    public class TimeTrackingResponse
    {
        public Guid TimeTrackingId { get; set; }
        public virtual Guid CustomerId { get; set; }
        public virtual Guid EmployeeId { get; set; }
        public virtual Guid ProjectNameId { get; set; }
        public virtual Guid ProjectOwnerId { get; set; }
        public virtual Guid TaskTypeId { get; set; }
        public int? WorkedHours { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Comment { get; set; }
        public string? RecordStatus { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(TimeTrackingResponse)) return false;

            TimeTrackingResponse other = (TimeTrackingResponse)obj;

            return TimeTrackingId == other.TimeTrackingId && CustomerId == other.CustomerId &&
                EmployeeId == other.EmployeeId && ProjectNameId == other.ProjectNameId &&
                ProjectOwnerId == other.ProjectOwnerId && WorkedHours == other.WorkedHours &&
                StartDate == other.StartDate && EndDate == other.EndDate && Comment == other.Comment &&
                RecordStatus == other.RecordStatus;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    public static class TimeTrackingExtension
    {
        public static TimeTrackingResponse ToTimeTracking(this TimeTrackingResponse timeTrackingResponse)
        {
            return new TimeTrackingResponse()
            {
                TimeTrackingId = timeTrackingResponse.TimeTrackingId,
                CustomerId = timeTrackingResponse.CustomerId,
                EmployeeId = timeTrackingResponse.EmployeeId,
                ProjectNameId = timeTrackingResponse.ProjectNameId,
                ProjectOwnerId = timeTrackingResponse.ProjectOwnerId,
                WorkedHours = timeTrackingResponse.WorkedHours,
                StartDate = timeTrackingResponse.StartDate,
                EndDate = timeTrackingResponse.EndDate,


            };
        }
    }
}
