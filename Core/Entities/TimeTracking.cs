using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class TimeTracking
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid TimeTrackingId { get; set; }


    [Required(ErrorMessage = "Record must have a customer")]
    [ForeignKey("Customer")]
    public Guid Customers { get; set; }

    public virtual Customer? Customer { get; set; }


    [Required(ErrorMessage = "Record must have a employee ")]
    [ForeignKey("Employee")]
    public Guid Employees { get; set; }

    public Employee? Employee { get; set; }


    [Required(ErrorMessage = "Record must have a project name")]
    [ForeignKey("ProjectName")]
    public Guid ProjectNames { get; set; }

    public ProjectName? ProjectName { get; set; }


    [Required(ErrorMessage = "Record must have a project owner")]
    [ForeignKey("ProjectOwner")]
    public Guid ProjectOwners { get; set; }

    public ProjectOwner? ProjectOwner { get; set; }

    [Required(ErrorMessage = "Record must have a task")]
    [ForeignKey("TaskType")]
    public Guid TaskTypes { get; set; }

    public TaskType? TaskType { get; set; }

    [Required(ErrorMessage = "Record must have a number of worked hours")]
    public int WorkedHours { get; set; }

    [Required(ErrorMessage = "Record must have a starting date")]
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }


    public string Comment { get; set; } = string.Empty;

    [Required(ErrorMessage = "Record must have a status")]
    public string RecordStatus { get; set; } = string.Empty;


    public override string ToString()
    {
        return
            $"Id: {TimeTrackingId}, CustomerId: {Customer},EmployeeId: {Employee}, ProjectNameID: {ProjectName}, ProjectOwnerId: {ProjectOwner}, " +
            $"TaskTypeId: {TaskType}, WorkedHours: {WorkedHours}, StartDate: {StartDate}, EndDate: {EndDate}, Comment: {Comment}, RecordStatus: {RecordStatus}";
    }
}