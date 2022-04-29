using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using _45Club.app.Models.Enums;

namespace _45Club.app.Models.Entities
{
    [Table("transports")]
    public class Transport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Display(Name = "Вид")]
        [Column("view")]
        public TransportViews View { get; set; } =  TransportViews.Motorbike;

        [Display(Name = "Дата выпуска")]
        [Column("date_of_issue")]
        public DateTime DateOfIssue { get; set; }

        [Display(Name = "Модель")]
        [Column("model")]
        public string Model { get; set; }

        [Display(Name = "Vin")]
        [Column("vin")]
        public string Vin { get; set; }

        [Display(Name = "Гос. номер")]
        [Column("state_sign")]
        public string StateSign { get; set; }

        public ICollection<Work> Works { get; set; }
    } 
}
