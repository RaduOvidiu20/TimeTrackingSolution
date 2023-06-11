using Core.Entities;

namespace Core.DTO.Response
{
    public class CustomerResponse
    {
        public Guid CustomerId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj.GetType() != typeof(CustomerResponse))
            {
                return false;
            }
            CustomerResponse other = (CustomerResponse)obj;
            return CustomerId == other.CustomerId && Name == other.Name && Email == other.Email && Phone == other.Phone;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    public static class CustomerExtension
    {
        public static CustomerResponse ToCustomerResponse(this Customer customer)
        {
            return new CustomerResponse()
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone
            };
        }
    }
}
