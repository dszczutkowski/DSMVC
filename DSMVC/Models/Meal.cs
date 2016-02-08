using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DSMVC.Models
{
    public class Meal
    {
        [Key]
        public int MealID { get; set; }
        [Display(Name = "Nazwa"), Required(ErrorMessage = "Proszę wprowadzić nazwę dania"), StringLength(50, MinimumLength = 2, ErrorMessage = "Liczba znaków powinna mieścić się w zakresie 2-50")]
        public string Name { get; set; }
        [Display(Name = "Cena"), Required(ErrorMessage = "Proszę wprowadzić cenę dania"), DataType(DataType.Currency)]
        public double Price { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}