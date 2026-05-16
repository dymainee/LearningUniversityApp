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

        public IActionResult ReturnToMenu()
        {
            return RedirectToAction("Menu", "Student");
        }

        public IActionResult Show()
        {
            List<Teacher> teachers = _context.teachers
                .Include(t=>t.SubjectTeachers)
                .ThenInclude(st=>st.Subject)
                .ToList();
            return View(teachers);
        }

        [HttpGet]
        public IActionResult Add() {
            List<Subject> subjects = _context.subjects.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AddPost(Teacher teacher)
        {
            _context.Add(teacher);
            _context.SaveChanges();
            return RedirectToAction("Show");
        }

        [HttpPost]
        public IActionResult Delete(int id) {
            Teacher teacher = _context.teachers.FirstOrDefault(s => s.Id == id);
            _context.Remove(teacher);
            _context.SaveChanges();
            return RedirectToAction("Show");
        }

        [HttpGet]
        public IActionResult Edit(int id) {
            Teacher teacher = _context.teachers.FirstOrDefault(s => s.Id == id);
            return View(teacher); 
        }

        [HttpPost]
        public IActionResult EditPost(Teacher teacher)
        {
            Teacher updatedTeacher = _context.teachers.FirstOrDefault(s => s.Id == teacher.Id);
            updatedTeacher.Name = teacher.Name;
            updatedTeacher.Surname = teacher.Surname;
            updatedTeacher.DateOfBirth = teacher.DateOfBirth;
            _context.SaveChanges();
            return RedirectToAction("Show");
        }

        [HttpGet]
        public IActionResult Schedule(int id) {
            List<Teacher> teachers = _context.teachers
                .Include(s => s.Schedules)
                    .ThenInclude(x => x.Group)
                .Include(s => s.Schedules)
                    .ThenInclude(x => x.Subject)
                .Where(x => x.Id == id)
                .ToList();
            return View(teachers);
        }
    }
}
