using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class TimeTracking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TimeTrackingId { get; set; }


        [Required]
        [ForeignKey("Customers")]
        public virtual Customer? Customer { get; set; }


        [Required]
        [ForeignKey("Employees")]
        public virtual Employee? Employee { get; set; }


        [Required]
        [ForeignKey("ProjectNames")]
        public virtual ProjectName? ProjectName { get; set; }


        [Required]
        [ForeignKey("ProjectOwners")]
        public virtual ProjectOwner? ProjectOwner { get; set; }

        [Required]
        [ForeignKey("TaskTypes")]
        public virtual TaskType? TaskType { get; set; }

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
            return $"Id: {TimeTrackingId}, CustomerId: {Customer},EmployeeId: {Employee}, ProjectNameID: {ProjectName}, ProjectOwnerId: {ProjectOwner}, " +
                $"TaskTypeId: {TaskType}, WorkedHours: {WorkedHours}, StartDate: {StartDate}, EndDate: {EndDate}, Comment: {Comment}, RecordStatus: {RecordStatus}";
        }
    }
}
