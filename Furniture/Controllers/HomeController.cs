using System.Diagnostics;
using Furniture.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Furniture.Controllers
{
    public class HomeController : Controller
    {
        FurnitureContext db = new FurnitureContext();
        public IActionResult Index()
        {
            //ViewBag.Categories = db.FurnitureCategories.ToList();
            return View();
        }
        public IActionResult About()
        
        {
            //ViewBag.A = db.Furnitures.Include(x=>x.Category).ToList();
            return View();
        }
        public IActionResult Product()
        
        {
            return View();
        }
        public IActionResult Blog()
        
        {
            return View();
        }
        public IActionResult Client()
        
        {
            return View();
        }
        public IActionResult Contact()
        
        {
            return View();
        }

    }
}
