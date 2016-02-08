using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSMVC.Validators
{
    public class SeatValidator : ValidationAttribute
    {
        public string Name { get; set; }

        public SeatValidator() {
            Name = null;
        }
    
        public SeatValidator(string name)
        {
            Name = name;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string errorMessage;
            string seatNumber;

            if (validationContext.DisplayName == null)
                errorMessage = "Podany numer jest niepoprawny!";
            else
                errorMessage = FormatErrorMessage(validationContext.DisplayName);

            if (value == null)
                return ValidationResult.Success;
            
            seatNumber = value.ToString();
            
            if (seatNumber.Length != 5)
                return new ValidationResult(errorMessage);

            int trzeciaLiczba = Convert.ToInt32(seatNumber[2].ToString());
            int czwartaLiczba = Convert.ToInt32(seatNumber[3].ToString());
            int piataLiczba = Convert.ToInt32(seatNumber[4].ToString());

            if (trzeciaLiczba == czwartaLiczba || czwartaLiczba == piataLiczba)
                return new ValidationResult(errorMessage);
            
            int[] weight = { 4, 1, 8, 4, 2 };

            if (weight.Distinct().Count() != 4)
                return new ValidationResult("zle wartosci!");
            
            int s = 0;
            
            for (int i = 0; i < seatNumber.Length; i++)
            {
                int temp;

                if (!Int32.TryParse(seatNumber[i].ToString(), out temp))
                    return new ValidationResult(errorMessage);

                if (i + 1 == seatNumber.Length)
                {
                    if ((10 - s % 10) % 10 != temp)
                        return new ValidationResult(errorMessage);
                    else
                        s += temp * weight[i];
                }
            }


            return ValidationResult.Success; //base.IsValid(value, validationContext);  
        }
    }
}