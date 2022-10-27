using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using project.Data;
using project.Models;
using System;
using System.Data;
using System.Linq;
using System.Security.Claims;

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
        public IActionResult MakeOrder(int book, int stock, int price)
        {
            var order = new Order();
            

            
            

            order.OrderStock = stock;
            order.BookId = book;
            order.OrderDate = DateTime.Now;
            order.Total = price * stock;
            context.Orders.Add(order);
            context.SaveChanges();
            return View();
        }
        [Authorize(Roles = "StoreOwner")]
        public IActionResult Index()
        {
            ViewBag.User = context.Users.ToList();
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);


            string currentUserId = claims.Value;
            ViewBag.Hihi = currentUserId;

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
               
                return RedirectToAction("index");
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
