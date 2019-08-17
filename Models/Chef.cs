using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace chefsNDishes.Models
{
    public class Chef
    {
        [Required]
        public int ChefId {get; set;}

        [Required]
        [MinLength(2)]
        public string FirstName {get; set;}

        [Required]
        [MinLength(2)]
        public string LastName {get; set;}

        [Required]
        [ValidDate]
        public DateTime BirthDate {get; set;}

        public List<Dish> CreatedDishes {get; set;}

        public DateTime CreatedAt {get; set;} = DateTime.Now;

        public DateTime UpdatedAt {get; set;} = DateTime.Now;


        public class ValidDateAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if ((DateTime)value > DateTime.Today)
                    return new ValidationResult("Please Enter a Valid Date");
                return ValidationResult.Success;
            }
        }

        public int Age()
        {
            int years = DateTime.Now.Year - BirthDate.Year;

            if((BirthDate.Month > DateTime.Now.Month) || (BirthDate.Month == DateTime.Now.Month && BirthDate.Day > DateTime.Now.Day))
                years--;

            return years;
        }
    }
}