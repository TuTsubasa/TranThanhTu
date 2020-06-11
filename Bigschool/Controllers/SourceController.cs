using Bigschool.Models;
using Bigschool.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bigschool.Controllers
{
    public class SourceController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        
        public SourceController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Source
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SourceViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                viewModel.Categories = _dbContext.Categories.ToList();
                return View("Create", viewModel);
            }
            var s = new Source();
            var source = new Source() {
                LectrurerId = User.Identity.GetUserId(),
                Datetime = viewModel.GetDateTime(),
                CategoryId = viewModel.Category,
                Place=viewModel.Place
                
            };
            _dbContext.Courses.Add(source);
            _dbContext.SaveChanges();

            return RedirectToAction("index","Home");
        }
    }
}