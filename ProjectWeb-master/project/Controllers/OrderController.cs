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
        public IActionResult MakeOrder(int book, int stock, int price, string name)
        {
            var order = new Order();




            order.Customer = name;
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
    

            var orders = context.Orders.ToList();
            return View(orders);
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

                return RedirectToAction(nameof(Index));
            }
        }
    }
}
