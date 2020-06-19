using Bigschool.Models;
using Bigschool.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public ActionResult Create()
        {
            var viewModel = new SourceViewModel
            {
                Categories = _dbContext.Categories.ToList()
            };
            return View(viewModel);
        }
        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var sources = _dbContext.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Source)
                .Include(l => l.Lecturer)
                .Include(l => l.Category)
                .ToList();
            var viewModel = new SourcesViewModel
            {
                UpcomingSources = sources,
                ShowAction = User.Identity.IsAuthenticated
            };
            return View(viewModel);
        }
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var sources = _dbContext.sources
                .where(c => c.LecturerId == userId && c.DateTime > DateTime.Now)
                .Include(l => l.Lecturer)
                .Include(c => c.Category)
                .ToList();
            return View(sources);
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var source = _dbContext.sources.Single(c => c.Id == id && c.LecturerId == userId);
            var viewModel = new SourcesViewModel
            {
                Categories = _dbContext.Categories.ToList(),
                Date = source.DateTime.ToString("dd/M/yyyy"),
                Time = source.DateTime.ToString("HH:mm"),
                Category = source.CategoryId,
                Place = source.Place
            };
            return View("Create", viewModel);
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