using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using locker_reading.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace locker_reading.Controllers
{
    [Authorize]
    public class ForestController : Controller
    {
        ApplicationDbContext context;
        protected UserManager<ApplicationUser> UserManager { get; set; }

        public ForestController()
        {
            context = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        }
        // GET: Forest
        public async Task<ActionResult> Index()
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            var entradas = context.Lectures.Where(x => x.ApplicationUser.Id.Equals(user.Id)).ToList();
            if (entradas.Count != 0)
            {
                var result = context.Lectures.Where(x => x.ApplicationUser.Id.Equals(user.Id)).Sum(x => x.NumAdvance);
                ViewBag.Arboles = result / 100;
            }
            else
            {
                ViewBag.Arboles = 0;
            }

            return View();
        }
    }
}