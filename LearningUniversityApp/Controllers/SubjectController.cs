using LearningUniversityApp.Data;
using LearningUniversityApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearningUniversityApp.Controllers
{
    
    public class SubjectController : Controller
    {
        private ApplicationContext _context;

        public SubjectController(ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult ReturnToMenu() {
            return RedirectToAction("Menu", "Student");
        }

        

        public IActionResult Show() {
            List<Subject> subjects = _context.subjects.ToList();
            return View(subjects);
        }
        [HttpGet]
        public IActionResult Add() {
            return View();
        }
        [HttpPost]
        public IActionResult AddPost(Subject subject) {
            _context.subjects.Add(subject);
            _context.SaveChanges();
            return RedirectToAction("Show");
        }

        [HttpGet]
        public IActionResult Edit(int id) {
            Subject subject = _context.subjects.FirstOrDefault(x => x.Id == id);
            return View(subject);

        }

        [HttpPost]
        public IActionResult EditPost(Subject subject)
        {
            Subject newSubject = _context.subjects.FirstOrDefault(x => x.Id == subject.Id);
            newSubject.Title = subject.Title;
            _context.subjects.Update(newSubject);
            _context.SaveChanges();
            return RedirectToAction("Show");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Subject subject = _context.subjects.FirstOrDefault(x => x.Id == id);
            _context.subjects.Remove(subject);
            _context.SaveChanges();
            return RedirectToAction("Show");
        }
    }
}
