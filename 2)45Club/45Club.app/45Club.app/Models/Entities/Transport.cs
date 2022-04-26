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

        [Column("view")]
        public TransportViews View { get; set; } =  TransportViews.Motorbike;

        [Column("date_of_issue")]
        public DataType DateOfIssue { get; set; }

        [Column("model")]
        public string Model { get; set; }

        [Column("vin")]
        public string Vin { get; set; }

        [Column("state_sign")]
        public string StateSign { get; set; }
    }
}
