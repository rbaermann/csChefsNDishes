using Microsoft.EntityFrameworkCore;

namespace chefsNDishes.Models
{
    public class ChefsNDishesContext : DbContext
    {
        public ChefsNDishesContext(DbContextOptions options) : base(options){}

        public DbSet<Chef> Chefs {get; set;}

        public DbSet<Dish> Dishes {get; set;}
    }
}