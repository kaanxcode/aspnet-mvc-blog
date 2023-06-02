using Blog.Web.Mvc.Data;
using Blog.Web.Mvc.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Blog.Web.Mvc.ViewComponents
{
    public class NavbarViewComponents : ViewComponent
    {
        private readonly BlogDbContext db;

        public NavbarViewComponents(BlogDbContext Db)
        {
            db = Db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //AppDbContext Db;
            //db = Db;

            return View(
                new Navbar
                {
                    categories = db.Categories.ToList(),
                    pages = db.Pages.ToList(),
                }
                );
            //return View();
        }
    }
}
