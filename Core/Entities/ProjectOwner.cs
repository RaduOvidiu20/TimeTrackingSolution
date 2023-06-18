using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class ProjectOwner
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ProjectOwnerId { get; set; }

    [Required(ErrorMessage = "Owner must have a name.")]
    public string Name { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"Id: {ProjectOwnerId}, Name: {Name}";
    }
}