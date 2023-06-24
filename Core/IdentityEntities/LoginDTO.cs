using System.ComponentModel.DataAnnotations;

namespace Core.IdentityEntities;

public class LoginDto
{
    [Required(ErrorMessage = "UserName can't be blank")]
    public string? UserName { get; set; }


    [Required(ErrorMessage = "Password can't be blank")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
}