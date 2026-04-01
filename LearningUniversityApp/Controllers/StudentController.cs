using Microsoft.AspNetCore.Mvc;

namespace LearningUniversityApp.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View(); // 
         }
    }
}
