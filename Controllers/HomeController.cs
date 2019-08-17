using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using chefsNDishes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace chefsNDishes.Controllers
{
    public class HomeController : Controller
    {
        private ChefsNDishesContext dbContext;

        public HomeController(ChefsNDishesContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public ViewResult Index()
        {
            List<Chef> chefs = dbContext.Chefs.Include(c => c.CreatedDishes).OrderByDescending(c => c.UpdatedAt).ToList();
            System.Console.WriteLine();
            return View("Index", chefs);
        }

        [HttpGet("new")]
        public ViewResult NewChef()
        {
            return View("NewChef");
        }

        [HttpPost("create")]
        public IActionResult CreateChef(Chef newChef)
        {
            if(ModelState.IsValid)
            {
                if(newChef.Age() < 18)
                {
                    ModelState.AddModelError("BirthDate", "Must be 18 years of age");
                    return View("NewChef");
                }
                dbContext.Add(newChef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("NewChef");
        }

        [HttpGet("dishes")]
        public ViewResult AllDishes()
        {
            List<Dish> dishes = dbContext.Dishes.Include(d => d.Chef).OrderByDescending(d => d.CreatedAt).ToList();
            return View("Dishes", dishes);
        }

        [HttpGet("dishes/new")]
        public ViewResult NewDish()
        {
            NewDishView ViewModel = CreateNewDishView();
            return View("NewDish", ViewModel);
        }

        [HttpPost("dishes/create")]
        public RedirectToActionResult CreateDish(NewDishView newMeal)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(newMeal.newDish);
                dbContext.SaveChanges();
                return RedirectToAction("AllDishes");
            }
            return RedirectToAction("NewDish");
        }

        public NewDishView CreateNewDishView()
        {
            NewDishView NDV = new NewDishView();
            NDV.Chefs = dbContext.Chefs.ToList();
            return NDV;
        }
    }
}
