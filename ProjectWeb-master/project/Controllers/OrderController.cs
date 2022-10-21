using Microsoft.AspNetCore.Mvc;
using project.Data;
using project.Models;

namespace project.Controllers
{

    public class OrderController : Controller
    {
        protected ApplicationDbContext context;

        public OrderController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult MakeOrder(int book, int stock)
        {
            var order = new Order();
            order.OrderStock = book;
            order.BookId = book;
            context.Orders.Add(order);
            context.SaveChanges();
            return View();
        }
    }
}
