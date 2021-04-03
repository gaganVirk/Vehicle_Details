using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Vehicle_Details.Models;
using Vehicle_Details.ViewModels;

namespace Vehicle_Details.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHostEnvironment hostEnvironment;

        public HomeController(ILogger<HomeController> logger,
            IHostEnvironment hostEnvironment)
        {
            _logger = logger;
            this.hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(CategoryCreateViewModel model)
        {
            if(!ModelState.IsValid)
            {
                string uniqueFileName = null;
                if(model.ImageIcon != null)
                {
                    string uploadsFolder = Path.Combine(hostEnvironment.ContentRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageIcon.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.ImageIcon.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Category newCategory = new Category
                {
                    MinValue = model.MinValue,
                    MaxValue = model.MaxValue,
                    Icon = uniqueFileName,
                    Type = model.Type
                };
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
