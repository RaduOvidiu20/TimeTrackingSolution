using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Customer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid CustomerId { get; set; }

    [Required(ErrorMessage = "Name cannot be null")]
    public string Name { get; set; } = string.Empty;

    [EmailAddress(ErrorMessage = "Add a proper email address ")]
    public string Email { get; set; } = string.Empty;

    [Phone(ErrorMessage = "Enter a proper phone number")]
    public int Phone { get; set; }

    public override string ToString()
    {
        return $"Id: {CustomerId}, Name: {Name}, Email: {Email}, Phone: {Phone}";
    }
}