using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _45Club.app.Models.Entities
{

    [Table("persons")]
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Display(Name = "Фамилия")]
        [Column("last_name")]
        public string LastName { get; set; }

        [Display(Name = "Имя")]
        [Column("first_name")]
        public string FirstName { get; set; }

        [Display(Name = "Телефон")]
        [Column("phone")]
        public string Phone { get; set; }
    }
}
