using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Data.Concrete;
using Data.Concrete.Context;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBuilder.Business.Abstract.DataServices;
using WebBuilder.Business.Concrete;
using WebBuilder.UserUI.Models;

namespace WebBuilder.UserUI.Controllers
{
    public class HomeController : Controller
    {
        UiDataService uiDataService;
        public HomeController(UiDataService uiDataService)
        {
            this.uiDataService = uiDataService;
        }
        public IActionResult Index()
        {
            return View(uiDataService);
        }
        public IActionResult AboutUs()
        {
            return View(uiDataService);
        }
        public IActionResult ContactUs()
        {
            return View(uiDataService);
        }
        public IActionResult Project()
        {
            return View(uiDataService);
        }
        public IActionResult Services()
        {
            return View(uiDataService);
        }
        public IActionResult Product()
        {
            return View(uiDataService);
        }
        [Route("/Home/ConfigureLanguage/{newLanguage}")]
        public IActionResult ConfigureLanguage(string newLanguage)
        {
            HttpContext.Session.SetString("Language", newLanguage);
            return RedirectToAction("Index");
        }
        [Route("/Error/SayfaBulunamadi")]
        public IActionResult ErrorPage(string oldLanguage)
        {
            return View("../Error/SayfaBulunamadi");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}