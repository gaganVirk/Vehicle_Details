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
        /*private readonly ICategoryRepository _categoryRepositry;*/
        private readonly IHostEnvironment hostEnvironment;

        public HomeController(ILogger<HomeController> logger,
            /*ICategoryRepository categoryRepository,*/
            IHostEnvironment hostEnvironment)
        {
            _logger = logger;
            /*_categoryRepositry = categoryRepository;*/
            this.hostEnvironment = hostEnvironment;
        }

       /* public ViewResult Index()
        {
            var model = _categoryRepository.GetAllCategory();
            return View(model);
        }*/

        public IActionResult Index()
        {
            MainPageViewModel mainPageViewModel = new MainPageViewModel();
           
            return View(mainPageViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
       
        [HttpPost]
        public IActionResult Create(CategoryCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.ImageIcon != null)
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
                /*_categoryRepository.Add(newCategory);*/
                return RedirectToAction(nameof(Index));
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
