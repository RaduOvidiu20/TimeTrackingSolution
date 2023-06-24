using Microsoft.AspNetCore.Identity;

namespace Core.IdentityEntities;

public class ApplicationUser : IdentityUser<Guid>
{
    public string? PersonName { get; set; }
}