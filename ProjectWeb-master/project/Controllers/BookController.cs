

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using project.Data;
using project.Models;

namespace project.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext context;

        public BookController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [Authorize(Roles = "StoreOwner")]
        public IActionResult StoreOwnerIndex()
        {
            return View(context.Books.ToList());
        }
        [Authorize(Roles = "Customer")]
        public IActionResult CustomerIndex()
        {
            return View(context.Books.ToList());
        }

        [Authorize(Roles = "StoreOwner")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {

                var book = context.Books.Find(id);

                context.Books.Remove(book);

                context.SaveChanges();


                TempData["Message"] = "Delete book successfully !";


                return RedirectToAction(nameof(StoreOwnerIndex));
            }
        }
        [Authorize(Roles = "StoreOwner")]
        public IActionResult StoreOwnerDetail(int id)
        {
            var book = context.Books
                                 .Include(b => b.Category)
                                 .FirstOrDefault(b => b.Id == id);
            return View(book);
        }
        [Authorize(Roles = "Customer")]
        public IActionResult CustomerDetail(int id)
        {
            var book = context.Books
                                 .Include(b => b.Category)
                                 .FirstOrDefault(b => b.Id == id);
            return View(book);
        }

        [Authorize(Roles = "StoreOwner")]
        [HttpGet]
        public IActionResult Add()
        {
            var categories = context.Categories.ToList();
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {
            if (ModelState.IsValid)
            {
                context.Books.Add(book);
                context.SaveChanges();
                TempData["Message"] = "Add book successfully !";
                return RedirectToAction("index");
            }
            else
            {
                ViewBag.Categories = context.Categories.ToList();
                return View(book);
            }
        }
        [Authorize(Roles = "StoreOwner")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var categories = context.Categories.ToList();
            ViewBag.Categories = categories;
            return View(context.Books.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                context.Books.Update(book);
                context.SaveChanges();
                TempData["Message"] = "Edit book successfully !";
                return RedirectToAction("index");
            }
            else
            {
                ViewBag.Categories = context.Categories.ToList();
                return View(book);
            }
        }

        public IActionResult SOSortNameAsc()
        {
            return View("StoreOwnerIndex", context.Books.OrderBy( b=> b.Name).ToList());
        }

        public IActionResult SOSortNameDesc()
        {
            return View("StoreOwnerIndex", context.Books.OrderByDescending(b => b.Name).ToList());
        }


        public IActionResult CUSSortNameAsc()
        {
            return View("CustomerIndex", context.Books.OrderBy(b => b.Name).ToList());
        }
        [Authorize(Roles = "Customer")]
        public IActionResult CUSSortNameDesc()
        {
            return View("CustomerIndex", context.Books.OrderByDescending(b => b.Name).ToList());
        }


        [HttpPost]
        public IActionResult Search(string keyword)
        {
            var books = context.Books.Where(b => b.Name.Contains(keyword)).ToList();
            if (books.Count == 0)
            {
                TempData["Message"] = "No book found";
            }
            return View("Index", books);
        }

    }
}
