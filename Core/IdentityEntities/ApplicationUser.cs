using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Core.IdentityEntities;

public class ApplicationUser : IdentityUser<Guid>
{
    public string? PersonName { get; set; }
    
    [ForeignKey("Employee")]
    public Guid Employee { get; set; }
    public virtual Employee? Employees { get; set; }
    }