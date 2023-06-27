using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities;
using Core.Enums;
using Microsoft.AspNetCore.Authentication;

namespace Core.IdentityEntities;

public class RegisterDto
{
    [Required(ErrorMessage = "Must select a employee")]
    [ForeignKey("EmployeeId")]
    public Guid UserEmployee { get; set; }

    

    [Required(ErrorMessage = "UserName can't be blank")]
    public string? UserName { get; set; }

    [Required(ErrorMessage = "Password can't be blank")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }


    [Required(ErrorMessage = "Confirm Password can't be blank")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Password and confirm password do not match")]
    public string? ConfirmPassword { get; set; }

    public UserType UserType { get; set; } = UserType.User;
    
}