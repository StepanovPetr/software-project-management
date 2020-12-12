using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Example.Domain.Entities
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("department_id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("head_of_department")] 
        public string Head { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
