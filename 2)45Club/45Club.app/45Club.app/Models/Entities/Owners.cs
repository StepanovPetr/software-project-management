using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _45Club.app.Models.Entities
{

    [Table("owners")]
    public class Owners
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Display(Name = "Id транспорта")]
        [Column("transport_id")]
        public int TransportId { get; set; }

        [Display(Name = "Id клиента")]
        [Column("person_id")]
        public int PersonId { get; set; }

        [Display(Name = "Активность")]
        [Column("is_active")]
        public bool IsActive { get; set; }

        public virtual Transport Transport { get; set; }

        public virtual Person Person { get; set; }
    }
}
