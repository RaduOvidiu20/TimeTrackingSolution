using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class TaskType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TaskTypeId { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"Id: {TaskTypeId}, Name: {Name}";
        }
    }
}
