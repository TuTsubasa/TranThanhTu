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
        public ActionResult Create(SourceViewModel viewModel)
        {
            var source = new Source

        {
            LecturerID = User.Identity.GetUserId(),
                Datetime = viewModel.GetDateTime(),
                CategoryId = viewModel.Category,
                Place=viewModel.Place
                
            };
            _dbContext.Source.Add(source);
            _dbContext.SaveChanges();
            return RedirectToAction("index","Home");
        }
    }
}