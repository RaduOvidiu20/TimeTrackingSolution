using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public sealed class TimeTracking
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid TimeTrackingId { get; set; }


    [Required(ErrorMessage = "Record must have a customer")]
    [ForeignKey("Customers")]
    public Customer? Customer { get; set; }


    [Required(ErrorMessage = "Record must have a employee ")]
    [ForeignKey("Employees")]
    public Employee? Employee { get; set; }


    [Required(ErrorMessage = "Record must have a project name")]
    [ForeignKey("ProjectNames")]
    public ProjectName? ProjectName { get; set; }


    [Required(ErrorMessage = "Record must have a project owner")]
    [ForeignKey("ProjectOwners")]
    public ProjectOwner? ProjectOwner { get; set; }

    [Required(ErrorMessage = "Record must have a task")]
    [ForeignKey("TaskTypes")]
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