using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class ProjectOwner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProjectOwnerId { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Id: {ProjectOwnerId}, Name: {Name}";
        }
    }
}
