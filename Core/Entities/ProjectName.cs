using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class ProjectName
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProjectNameId { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"Id: {ProjectNameId}, Name: {Name}";
        }
    }
}
