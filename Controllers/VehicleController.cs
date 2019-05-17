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
    public class VehicleController : Controller
    {
        ApplicationDbContext context;
        UserManager<User> userManager;

        public VehicleController(ApplicationDbContext context, UserManager<User> userManager)
        {
            this.userManager = userManager;
            this.context = context;
        }


        // GET: Vehicle
        public ActionResult Index()
        {
            return View(context.Vehicles.Where(x => !x.Taken));
        }
        [HttpPost]
        public async Task<ActionResult> Details(string id)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            if(context.Carts.Any(x => x.UserId == user.Id))
                context.Carts.Add(new Cart { UserId = user.Id });

            context.Carts.First(x => x.UserId == user.Id).Vehicles.Add(id);
            context.Vehicles.First(x => x.Id == id).Taken = true;
            await context.SaveChangesAsync();
            return View();
        }  
    }
}