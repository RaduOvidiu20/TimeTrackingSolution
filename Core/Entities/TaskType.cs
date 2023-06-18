using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class TaskType
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid TaskTypeId { get; set; }
    [Required(ErrorMessage = "Task must have a name.")]
    public string Name { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"Id: {TaskTypeId}, Name: {Name}";
    }
}