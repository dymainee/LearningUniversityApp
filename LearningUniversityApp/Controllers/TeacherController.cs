using LearningUniversityApp.Data;
using LearningUniversityApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningUniversityApp.Controllers
{
    public class TeacherController : Controller
    {
        private ApplicationContext _context;

        public TeacherController(ApplicationContext context)
        {
            _context = context;
        }

        public ActionResult ReturnToMenu()
        {
            return RedirectToAction("Menu", "Student");
        }

        public IActionResult ShowTeacher()
        {
            List<Teacher> teachers = _context.teachers.ToList();
            return View(teachers);
        }

        [HttpGet]
        public IActionResult AddTeacher() { 
            return View();
        }

        [HttpPost]
        public IActionResult AddTeacherPost(Teacher teacher)
        {
            _context.Add(teacher);
            _context.SaveChanges();
            return RedirectToAction("ShowTeacher");
        }

        [HttpPost]
        public IActionResult DeleteTeacher(int id) {
            Teacher teacher = _context.teachers.FirstOrDefault(s => s.Id == id);
            _context.Remove(teacher);
            _context.SaveChanges();
            return RedirectToAction("ShowTeacher");
        }

        [HttpGet]
        public IActionResult EditTeacher(int id) {
            Teacher teacher = _context.teachers.FirstOrDefault(s => s.Id == id);
            return View(teacher); 
        }

        [HttpPost]
        public IActionResult EditTeacherPost(Teacher teacher)
        {
            Teacher updatedTeacher = _context.teachers.FirstOrDefault(s => s.Id == teacher.Id);
            updatedTeacher.Name = teacher.Name;
            updatedTeacher.Surname = teacher.Surname;
            updatedTeacher.DateOfBirth = teacher.DateOfBirth;
            _context.SaveChanges();
            return RedirectToAction("ShowTeacher");
        }
    }
}
