using Microsoft.AspNetCore.Mvc;
using Furniture.Models;
using Microsoft.EntityFrameworkCore;

namespace Furniture.Controllers
{
    public class AdminController : Controller
    {
        FurnitureContext db = new FurnitureContext();
        //FurnitureCategory
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FurnitureCategory()
        {
            ViewBag.FurnCat = db.FurnitureCategories.ToList();
            return View();
        }
        public IActionResult NewFurnitureCategory()
        {

            return View();
        }
        [HttpPost]
        public IActionResult NewFurnitureCategory(FurnitureCategory c)
        {
            db.FurnitureCategories.Add(c);
            db.SaveChanges();
            return RedirectToAction("FurnitureCategory");
        }
        public IActionResult DelFurnitureCategory(int id)
        {
            FurnitureCategory f = db.FurnitureCategories.SingleOrDefault(x => x.CategoryId == id);
            db.FurnitureCategories.Remove(f);
            db.SaveChanges();
            return RedirectToAction("FurnitureCategory");
        }
        public IActionResult EditFurnitureCategory(int id)
        {
            ViewBag.edit_f = db.FurnitureCategories.SingleOrDefault(x => x.CategoryId == id);

            return View();
        }
        public IActionResult UpdateFurnitureCategory(int id, FurnitureCategory new_f)
        {
            FurnitureCategory old_f = db.FurnitureCategories.SingleOrDefault(x => x.CategoryId == id);
            old_f.CategoryName = new_f.CategoryName;
            db.SaveChanges();
            return RedirectToAction("FurnitureCategory");
        }

        //Furniture
        public IActionResult Furniture()
        {
            ViewBag.Furn = db.Furnitures.Include(x => x.Category).ToList();
            return View();
        }

        public IActionResult NewFurniture()
        {
            ViewBag.Categories = db.FurnitureCategories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult NewFurniture(Furniture.Models.Furniture f, IFormFile FurnitureImgUrl)
        {
            string filename = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + Path.GetExtension(FurnitureImgUrl.FileName);
            using (Stream stream = new FileStream("wwwroot/home_assets/images/" + filename, FileMode.Create))
            {
                FurnitureImgUrl.CopyTo(stream);
            }

            f.FurnitureImgUrl = filename;


            db.Furnitures.Add(f);
            db.SaveChanges();
            return RedirectToAction("Furniture");
        }
        public IActionResult EditFurniture(int id)
        {
            ViewBag.Categories = db.FurnitureCategories.ToList();
            ViewBag.edit_furn = db.Furnitures.SingleOrDefault(x => x.FurnitureId == id);
            return View();
        }
        [HttpPost]
        public IActionResult UpdateFurniture(int id, Furniture.Models.Furniture new_f, IFormFile FurnitureImgUrl)
        {
            Furniture.Models.Furniture old_f = db.Furnitures.SingleOrDefault(x => x.FurnitureId == id);
            if (FurnitureImgUrl != null)
            {

                string filename = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + Path.GetExtension(FurnitureImgUrl.FileName);
                using (Stream stream = new FileStream("wwwroot/home_assets/images/" + filename, FileMode.Create))
                {
                    FurnitureImgUrl.CopyTo(stream);
                }

                new_f.FurnitureImgUrl = filename;
            }

            old_f.FurnitureName = new_f.FurnitureName;
            old_f.FurniturePrice = new_f.FurniturePrice;
            old_f.FurnitureImgUrl = new_f.FurnitureImgUrl;
            old_f.CategoryId = new_f.CategoryId;


            db.SaveChanges();
            return RedirectToAction("Furniture");
        }

        public IActionResult Blog()
        {
            ViewBag.Blogs = db.Blogs.ToList();

            return View();
        }
        public IActionResult InsertBlog()
        {
            return View();
        }

        public IActionResult InsertNewBlog(Blog b, IFormFile BlogImgUrl)
        {

            if (BlogImgUrl != null)
            {

                string filename = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + Path.GetExtension(BlogImgUrl.FileName);
                using (Stream stream = new FileStream("wwwroot/home_assets/images/" + filename, FileMode.Create))
                {
                    BlogImgUrl.CopyTo(stream);
                }
                b.BlogImgUrl = filename;

            }
            db.Blogs.Add(b);
            db.SaveChanges();

            return RedirectToAction("Blog");
        }
        public IActionResult EditBlog()
        {


            return View();
        }
        public IActionResult DeleteBlog()
        {


            return View();
        }
    }
}
