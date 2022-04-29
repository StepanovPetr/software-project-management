using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _45Club.app.Models.Entities
{

    [Table("works")]
    public class Work
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Display(Name = "Дата работ")]
        [Column("date_of_work")]
        public DateTime DateOfWork { get; set; }

        [Display(Name = "Стоимость")]
        [Column("price")]
        public int Price { get; set; }

        [Display(Name = "Описание работ")]
        [Column("text")]
        public string Text { get; set; }

        [Display(Name = "id транспорта")]
        [Column("transport_id")]
        public int TransportId { get; set; }

        public virtual Transport Transport { get; set; }
    }
}
