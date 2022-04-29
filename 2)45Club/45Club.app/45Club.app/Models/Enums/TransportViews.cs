using System.ComponentModel.DataAnnotations;

namespace _45Club.app.Models.Enums
{
    public enum TransportViews
    {
        [Display(Name = "Мотоцикл")]
        Motorbike = 1,

        [Display(Name = "Мопед")]
        Moped = 2,

        [Display(Name = "Велосипед")]
        Bike = 3,

        [Display(Name = "Квадроцикл")]
        Atv = 4,

        [Display(Name = "Снегоход")]
        Snowmobile = 5,
    }
}