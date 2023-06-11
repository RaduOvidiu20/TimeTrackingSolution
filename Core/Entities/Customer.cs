using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Customer
    {
        [Key]
        public Guid CustomerId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public override string ToString()
        {
            return $"Id: {CustomerId}, Name: {Name}, Email: {Email}, Phone: {Phone}";
        }

    }
}
