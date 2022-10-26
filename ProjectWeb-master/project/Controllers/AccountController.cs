
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

using project.Data;
using project.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

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

            var users = context.Users.ToList();
            ViewBag.Role = context.Roles.ToList();
            ViewBag.UR = context.UserRoles.ToList();
            return View(users);
        }
        public IActionResult Edit()
        {
            string id = Request.Form["id"];
            string old_pass = Request.Form["oldpass"];
            string new_pass = Request.Form["newpass"];
            string confirm_pass = Request.Form["confirmpassword"];

            ViewData["OldPass"] = old_pass;
            ViewData["NewPass"] = new_pass;
            ViewData["ConfirmPassword"] = confirm_pass;

            var list_users = context.Users.ToList();
            var user = list_users.Find(p => p.Id == id);

            var passwordHasher = new PasswordHasher<Account>();

            var temp_user = new Account
            {
                Id = id,
                UserName = user.UserName,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
            };

            var result = passwordHasher.VerifyHashedPassword(temp_user, user.PasswordHash, old_pass);

            if (result == PasswordVerificationResult.Success)
            {
                if (new_pass == confirm_pass)
                {
                    var new_hash = passwordHasher.HashPassword(temp_user, new_pass);
                    user.PasswordHash = new_hash;
                    context.Users.Update(user);
                    context.SaveChanges();
                    return Redirect("/Admin/Reset");
                }
                else
                {
                    ViewBag.Error1 = "Confirm password is not match";
                    return View("Edit", user);
                }
            }
            else
            {
                ViewBag.Error2 = "Old password is not match";
                return View("Edit", user);
            }
        }
        public IActionResult Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {

                var account = context.Accounts.Find(id);

                context.Accounts.Remove(account);

                context.SaveChanges();


                TempData["Message"] = "Delete user successfully !";


                return RedirectToAction(nameof(Index));
            }
        }



    }
}