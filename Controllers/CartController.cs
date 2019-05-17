using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecondStageExam.Data;
using SecondStageExam.Models;

namespace SecondStageExam.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        ApplicationDbContext context;
        UserManager<User> userManager;

        public CartController(ApplicationDbContext context, UserManager<User> userManager)
        {
            this.userManager = userManager;
            this.context = context;
        }

        public async Task<ActionResult> Index()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            if(context.Carts.Any(x => x.UserId == user.Id))
                return View(context.Carts.First(x => x.UserId == user.Id));
            return RedirectPermanent("~/home/index");
        }

        public async Task<ActionResult> Confirm()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var cart = context.Carts.First(x => x.UserId == user.Id);
            context.Orders.Add(new Orders { Start = DateTime.Now, UserId = user.Id, Vehicles = cart.Vehicles });
            return RedirectPermanent("~/home/index");
        }

       
        // GET: Cart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cart/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}