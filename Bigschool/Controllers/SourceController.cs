using Bigschool.Models;
using Bigschool.ViewModels;
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
        public ActionResult Create()
        {
            var viewModel = new SourceViewModel
            {
                Categories = _dbContext.Categories.ToList()
            };
            return View(viewModel);
        }
    }
}