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
    public class LectureController : Controller
    {
        ApplicationDbContext context;
        protected UserManager<ApplicationUser> UserManager { get; set; }

        public LectureController()
        {
            context = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        }
        // GET: Lecture
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Create()
        {
            Lecture model = new Lecture();
            //ViewBag.Books = new SelectList(context.Books, "Id", "BookName");
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            //ViewBag.Books = new SelectList(context.Books.Where(g => g.ApplicationUser.Id.Equals(user.Id)), "Id", "BookName");
            model.UserBooks = context.Books.Where(g => g.ApplicationUser.Id.Equals(user.Id) && g.Finished == false).ToList<Book>();
            //ViewBag.Books = context.Books.Where(x => x.ApplicationUser == user);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Lecture model)
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            var bookId = model.SelectedBookId;
            //model.UserBooks = context.Books.Where(g => g.ApplicationUser.Id.Equals(user.Id)).ToList<Book>();
            model.ApplicationUser = user;
            //var bookId = model.SelectedBookId;
            model.Book = context.Books.Find(bookId);
            var resultado = context.Lectures.Where(x => x.Book.Id.Equals(bookId)).ToList();
            if (resultado.Count != 0)
            {
                var result = context.Lectures.Where(x => x.ApplicationUser.Id.Equals(user.Id) && x.Book.Id.Equals(bookId)).Sum(x => x.NumAdvance);
                if (result >= model.Book.Pages)
                {
                    model.Finished = true;
                    model.Book.Finished = true;
                    model.NumAdvance = model.Book.Pages - result;
                }
            }

            if (model.NumAdvance >= model.Book.Pages)
            {
                model.Finished = true;
                model.Book.Finished = true;
                model.NumAdvance = model.Book.Pages;
            }
            //ViewBag.Books = new SelectList(context.Books.Where(g => g.ApplicationUser.Id.Equals(user.Id)), "Id", "BookName");
            //int SelectedBook = model.SelectedBook;

            if (ModelState.IsValid)
            {
                context.Lectures.Add(model);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors);

            return View(model);
        }
    }
}