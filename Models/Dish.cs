using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace chefsNDishes.Models
{
    public class Dish
    {
        [Required]
        public int DishId {get; set;}

        [Required]
        [MinLength(2)]
        public string Name {get; set;}

        [Required]
        
        public int Calories {get; set;}

        [Required]
        public string Description {get; set;}

        [Required]
        [Range(1, 5)]
        public int Tastiness {get; set;}

        [Required]
        public int ChefId {get; set;}

        public Chef Chef {get; set;}

        public DateTime CreatedAt {get; set;} = DateTime.Now;


        public DateTime UpdatedAt {get; set;} = DateTime.Now;
    }
}