using locker_reading.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace locker_reading.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        ApplicationDbContext context;
        protected UserManager<ApplicationUser> UserManager { get; set; }

        public BookController()
        {
            context = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        }
        // GET: Contact
        public async Task<ActionResult> Index()
        {
            Lecture model = new Lecture();
            var bookId = model.SelectedBookId;
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            return View(context.Books.Where(g => g.ApplicationUser.Id.Equals(user.Id)));
        }
        public ActionResult Create()
        {
            return View(new Book());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Book model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                model.ApplicationUser = user;
                context.Books.Add(model);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}