namespace Core.DTO.Response
{
    public class EmployeeResponse
    {
        public Guid EmployeeId { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Phone { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(EmployeeResponse)) return false;

            EmployeeResponse other = (EmployeeResponse)obj;
            return EmployeeId == other.EmployeeId && Name == other.Name && Age == other.Age && Phone == other.Phone;

        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    public static class EmployeeExtension
    {
        public static EmployeeResponse ToEmployeeResponse(this EmployeeResponse employeeResponse)
        {
            return new EmployeeResponse()
            {
                EmployeeId = employeeResponse.EmployeeId,
                Name = employeeResponse.Name,
                Age = employeeResponse.Age,
                Phone = employeeResponse.Phone
            };
        }
    }
}
