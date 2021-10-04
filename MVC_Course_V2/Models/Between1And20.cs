using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_Course_V2.Models
{
    public class Between1And20 : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            if (movie.NumberInStock<=0||movie.NumberInStock>20)
            {
                return new ValidationResult("Number in Stock must be between 1 and 20");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}