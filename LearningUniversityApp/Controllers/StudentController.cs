using Microsoft.AspNetCore.Mvc;
using LearningUniversityApp.Data;
using LearningUniversityApp.Models;

namespace LearningUniversityApp.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationContext _context;

        public StudentController(ApplicationContext context) { 
            this._context = context;
        }
        
        
        public IActionResult Index()
        {


            var Student = new Student() { Name = "Alex" , Surname = "Dmytro"}; 
            _context.students.Add(Student);
            _context.SaveChanges();
            var firstStudent = _context.students.First();
            return View(firstStudent);  
         }
        //DTO Data transfer object

    }
}
