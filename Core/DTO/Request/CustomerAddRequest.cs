using Core.Entities;

namespace Core.DTO.Request
{
    public class CustomerAddRequest
    {
        public Guid CustomerId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public Customer ToCustomer()
        {
            return new Customer() { CustomerId = CustomerId, Name = Name, Email = Email, Phone = Phone };

        }
    }
}
