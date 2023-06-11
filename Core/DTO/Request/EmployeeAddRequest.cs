using Core.Entities;

namespace Core.DTO.Request
{
    public class EmployeeAddRequest
    {

        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Phone { get; set; }

        public Employee ToEmployee()
        {
            return new Employee() { Name = Name, Age = Age, Phone = Phone };
        }
    }
}
