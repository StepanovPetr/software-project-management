using System.ComponentModel.DataAnnotations.Schema;

namespace Example.Domain.Entities
{
    public class Student
    {
        [Column("student_id")]
        public int Id { get; set; }

        [Column("group_id")]
        public int GroupId { get; set; }

        [Column("fio")]
        public string Fio { get; set; }

        public virtual Group Group { get; set; }
    }
}