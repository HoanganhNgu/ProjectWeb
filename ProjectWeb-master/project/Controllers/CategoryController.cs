
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

using project.Data;
using project.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace project.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext context;

        public CategoryController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [Authorize(Roles ="StoreOwner")]
        public IActionResult StoreOwnerIndex()
        {
            var categories = context.Categories.ToList();
            return View(categories);
        }
        //[Authorize(Roles ="Customer")]
        public IActionResult CustomerIndex()
        {
            var categories = context.Categories.ToList();
            return View(categories);
        }
        [Authorize(Roles = "StoreOwner")]
        public IActionResult Remove(int id)
        {
            var category = context.Categories.Find(id);
            context.Categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction("StoreOwnerIndex");
        }
        [Authorize(Roles = "StoreOwner")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Add(category);
                context.SaveChanges();
                return RedirectToAction("StoreOwnerIndex");
            }
            return View(category);
        }
        [Authorize(Roles = "StoreOwner")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = context.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Update(category);
                context.SaveChanges();
                return RedirectToAction("StoreOwnerIndex");
            }
            return View(category);
        }
        [Authorize(Roles ="StoreOwner")]
        public IActionResult StoreOwnerDetail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = context.Categories
                                    .Include(c => c.Books)
                                    .FirstOrDefault(c => c.Id == id);
            return View(category);
        }
        [Authorize(Roles = "Customer")]
        public IActionResult CustomerDetail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = context.Categories
                                    .Include(c => c.Books)
                                    .FirstOrDefault(c => c.Id == id);
            return View(category);
        }
    }
}