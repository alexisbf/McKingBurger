using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.ValidationAttributes
{
    public class PositiveNumber : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int number = Convert.ToInt32(value);

            if (number < 0)
            {
                return new ValidationResult("Le stock ne peut pas être négatif !!!");
            }

            return ValidationResult.Success;
        }
    }
}
