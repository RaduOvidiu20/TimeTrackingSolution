using Core.Entities;

namespace Core.DTO.Request
{
    public class TimeTrackingAddRequest
    {
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
        public TimeTracking ToTimeTracking()
        {
            return new TimeTracking()
            {
                CustomerId = CustomerId,
                EmployeeId = EmployeeId,
                ProjectNameId = ProjectNameId,
                ProjectOwnerId = ProjectOwnerId,
                TaskTypeId = TaskTypeId,
                WorkedHours = WorkedHours,
                StartDate = StartDate,
                EndDate = EndDate,
                Comment = Comment,
                RecordStatus = RecordStatus
            };
        }
    }
}
