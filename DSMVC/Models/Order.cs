using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DSMVC.Validators;

namespace DSMVC.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [Display(Name = "Danie"), Required(ErrorMessage = "Wybierz danie do zamówienia")]
        public int MealID { get; set; }
        public virtual Meal Meal { get; set; }

        //[SeatValidator()]
        [Display(Name = "Numer miejsca"), Required(ErrorMessage = "Prosze podac numer miejsca"), Range(1, 30, ErrorMessage = "Prosze podać liczbę z przedziału 1-30")]
        public int SeatNumber { get; set; }
        
        [Display(Name = "Forma płatności"), Required(ErrorMessage = "Proszę wybrać formę płatności")]
        public string PaymentMethod { get; set; }
        
    }
    
}