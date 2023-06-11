using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Employee
    {
        [Key]
        public Guid EmployeeId { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Phone { get; set; }
        public override string ToString()
        {
            return $"Id: {EmployeeId}, Name: {Name}, Age: {Age}, Phone: {Phone}";
        }
    }
}
