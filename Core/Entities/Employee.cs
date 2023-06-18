using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Employee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid EmployeeId { get; set; }

    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public int Phone { get; set; }

    public override string ToString()
    {
        return $"Id: {EmployeeId}, Name: {Name}, Age: {Age}, Phone: {Phone}";
    }
}