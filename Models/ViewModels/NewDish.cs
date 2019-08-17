using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace chefsNDishes.Models
{
    public class NewDishView
    {
        public List<Chef> Chefs {get; set;}
        public Dish newDish {get; set;}
    }
}