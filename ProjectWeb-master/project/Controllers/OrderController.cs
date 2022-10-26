using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using project.Data;
using project.Models;
using System;
using System.Data;
using System.Linq;

namespace project.Controllers
{

    public class OrderController : Controller
    {
        protected ApplicationDbContext context;

        public OrderController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [Authorize(Roles = "Customer")]
        public IActionResult MakeOrder(int book, int stock)
        {
            var order = new Order();
            order.OrderStock = book;
            order.BookId = book;
            order.OrderDate = DateTime.Now;
            context.Orders.Add(order);
            context.SaveChanges();
            return View();
        }
        [Authorize(Roles = "StoreOwner")]
        public IActionResult Index()
        {
            var orders = context.Orders.ToList();
            return View(orders);
        }

        [Authorize(Roles = "StoreOwner")]
        [HttpGet]
        public IActionResult IsAccepted(int id)
        {
            var order = context.Orders.Find(id);
            return View(order);
        }

        [HttpPost]
        public IActionResult IsAccepted(Order order)
        {
            if (ModelState.IsValid)
            {
                context.Orders.Update(order);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
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

                var order = context.Orders.Find(id);

                context.Orders.Remove(order);

                context.SaveChanges();


                TempData["Message"] = "Delete order successfully !";


                return RedirectToAction(nameof(Index));
            }
        }
    }
}
