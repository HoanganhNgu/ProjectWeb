
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

using project.Data;
using project.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace project.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext context;

        public AccountController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var accounts = context.Accounts.ToList();
            return View(accounts);
        }
        
        [Authorize(Roles = "Admin")]
        public IActionResult Remove(int id)
        {
            var account = context.Accounts.Find(id);
            context.Accounts.Remove(account);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var account = context.Accounts.Find(id);
            return View(account);
        }

        [HttpPost]
        public IActionResult Edit(Account account)
        {
            if (ModelState.IsValid)
            {
                context.Accounts.Update(account);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(account);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var account = context.Accounts;
                                    //.Include(a => a.Books)
                                    //.FirstOrDefault(a => a.Id == id);
            return View(account);
        }

    }
}