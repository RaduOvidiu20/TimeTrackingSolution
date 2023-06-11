using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class TimeTracking
    {
        [Key]
        public Guid TimeTrackingId { get; set; }


        [Required]
        [ForeignKey(nameof(CustomerId))]
        public virtual Guid CustomerId { get; set; }


        [Required]
        [ForeignKey(nameof(EmployeeId))]
        public virtual Guid EmployeeId { get; set; }


        [Required]
        [ForeignKey(nameof(ProjectNameId))]
        public virtual Guid ProjectNameId { get; set; }


        [Required]
        [ForeignKey(nameof(ProjectOwnerId))]
        public virtual Guid ProjectOwnerId { get; set; }

        [Required]
        [ForeignKey(nameof(TaskTypeId))]
        public virtual Guid TaskTypeId { get; set; }

        [Required]
        public int? WorkedHours { get; set; }

        [Required]
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }


        public string? Comment { get; set; }

        [Required]
        public string? RecordStatus { get; set; }

        public override string ToString()
        {
            return $"Id: {TimeTrackingId}, CustomerId: {CustomerId},EmployeeId: {EmployeeId}, ProjectNameID: {ProjectNameId}, ProjectOwnerId: {ProjectOwnerId}, " +
                $"TaskTypeId: {TaskTypeId}, WorkedHours: {WorkedHours}, StartDate: {StartDate}, EndDate: {EndDate}, Comment: {Comment}, RecordStatus: {RecordStatus}";
        }
    }
}
