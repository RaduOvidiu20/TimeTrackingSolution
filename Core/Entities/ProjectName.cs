using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class ProjectName
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ProjectNameId { get; set; }

    [Required(ErrorMessage = "Project must have a name")]
    public string Name { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"Id: {ProjectNameId}, Name: {Name}";
    }
}