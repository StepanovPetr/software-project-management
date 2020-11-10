using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Example.Domain.Entities
{
    public class Department
    {
        [Column("department_id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("head_of_department")] 
        public string Head { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
