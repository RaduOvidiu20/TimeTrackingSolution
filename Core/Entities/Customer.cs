using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CustomerId { get; set; }
        [Required(ErrorMessage ="Name cannot be null")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Email cannot be null")]
        [EmailAddress(ErrorMessage = "Add a proper email address ")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Phone number cannot be null")]
        [Phone(ErrorMessage = "Enter a proper phone number")]
        public string Phone { get; set; }

        public override string ToString()
        {
            return $"Id: {CustomerId}, Name: {Name}, Email: {Email}, Phone: {Phone}";
        }

    }
}
