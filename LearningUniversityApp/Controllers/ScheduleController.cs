using LearningUniversityApp.Data;
using LearningUniversityApp.Models;
using LearningUniversityApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LearningUniversityApp.Controllers
{
    public class ScheduleController : Controller
    {
        private ApplicationContext _context;

        public ScheduleController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult ReturnToMenu()
        {
            return RedirectToAction("Menu", "Student");
        }


        public IActionResult Show() {
            List<Schedule> schedules = _context.schedules.ToList(); //todo
            return View(schedules);
        }

        public IActionResult Create() {
            ScheduleCreateViewModel model = new ScheduleCreateViewModel();
            model.Groups = _context.groups.Select(s => new SelectListItem(s.Title, s.Id.ToString())).ToList();
            model.Teachers = _context.teachers.Select(t => new SelectListItem(t.Surname, t.Id.ToString())).ToList();
            model.Subjects = _context.subjects.Select(g => new SelectListItem(g.Title, g.Id.ToString())).ToList();
            //model.Days = .Cast() - что это
            return View(model);

        }

        [HttpPost]
        public IActionResult CreatePost(ScheduleCreateViewModel model) {
            Schedule schedule = new Schedule();
            schedule.SubjectId = model.SubjectId;
            schedule.TeacherId = model.TeacherId;
            schedule.GroupId = model.GroupId;
            schedule.Day = model.Day;
            //
            _context.schedules.Add(schedule);
            _context.SaveChanges();
            return RedirectToAction("Show");
        }
        [HttpGet]
        public IActionResult Edit(int id) {
            Schedule schedule = _context.schedules.FirstOrDefault(s => s.Id == id);
            ScheduleCreateViewModel model = new ScheduleCreateViewModel();
            model.Groups = _context.groups.Select(s => new SelectListItem(s.Title, s.Id.ToString())).ToList();
            model.Teachers = _context.teachers.Select(t => new SelectListItem(t.Surname, t.Id.ToString())).ToList();
            model.Subjects = _context.subjects.Select(g => new SelectListItem(g.Title, g.Id.ToString())).ToList();
            model.schedule = schedule;

            return View(schedule);
        }

        [HttpPost]
        public IActionResult EditPost(ScheduleCreateViewModel model) {
            Schedule newschedule = _context.schedules.FirstOrDefault(s => s.Id == model.schedule.Id);
            newschedule.TeacherId = model.schedule.TeacherId;
            newschedule.SubjectId = model.schedule.SubjectId;
            newschedule.GroupId = model.schedule.GroupId;
            newschedule.Day = model.schedule.Day;
            _context.schedules.Update(newschedule);
            _context.SaveChanges();
            return View("Show");
        }



        [HttpPost]
        public IActionResult Delete(int id) {
            Schedule schedule = _context.schedules.FirstOrDefault(s => s.Id == id);
            _context.schedules.Remove(schedule);
            _context.SaveChanges();
            return RedirectToAction("Show");
        }


    }
}
