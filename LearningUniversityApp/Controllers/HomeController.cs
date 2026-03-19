using System.Diagnostics;
using LearningUniversityApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearningUniversityApp.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult About() 
        { 
            return View();
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
    }
}
