using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Employee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid EmployeeId { get; set; }

    [Required(ErrorMessage = "Name cannot be null.")]
    public string Name { get; set; } = string.Empty;

    public int Age { get; set; }
    public string Phone { get; set; }

    [Required(ErrorMessage = "Email cannot be null.")]
    [EmailAddress(ErrorMessage = "Chose a proper email address.")]
    public string Email { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"Id: {EmployeeId}, Name: {Name}, Age: {Age}, Phone: {Phone}, Email: {Email}";
    }
}