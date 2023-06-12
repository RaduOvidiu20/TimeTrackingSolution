using Core.Entities;

namespace Core.DTO.Request
{
    public class TimeTrackingAddRequest
    {
        public virtual Customer? CustomerId { get; set; }
        public virtual Employee? EmployeeId { get; set; }
        public virtual ProjectName? ProjectNameId { get; set; }
        public virtual ProjectOwner? ProjectOwnerId { get; set; }
        public virtual TaskType? TaskTypeId { get; set; }
        public virtual int? WorkedHours { get; set; }
        public virtual DateTime? StartDate { get; set; }
        public virtual DateTime? EndDate { get; set; }
        public virtual string? Comment { get; set; }
        public virtual string? RecordStatus { get; set; }
        public TimeTracking ToTimeTracking()
        {
            return new TimeTracking()
            {
                Customer = CustomerId,
                Employee = EmployeeId,
                ProjectName = ProjectNameId,
                ProjectOwner = ProjectOwnerId,
                TaskType = TaskTypeId,
                WorkedHours = WorkedHours,
                StartDate = StartDate,
                EndDate = EndDate,
                Comment = Comment,
                RecordStatus = RecordStatus
            };
        }
    }
}
