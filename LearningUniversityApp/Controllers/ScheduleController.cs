using LearningUniversityApp.Data;
using LearningUniversityApp.Models;
using LearningUniversityApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            List<Schedule> schedules = _context.schedules
                .Include(s=>s.Teacher)
                .Include(s=>s.Subject)
                .Include(s=>s.Group)
                .ToList(); 
            return View(schedules);
        }

        public IActionResult Create() 
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            for (int i = 0; i < 5; i++)
            {
                SelectListItem selectListItem = new SelectListItem(Enum.GetValues<DayList>()[i].ToString(), i.ToString());
                selectListItems.Add(selectListItem);
            }

            ScheduleCreateViewModel model = new ScheduleCreateViewModel();
            model.Groups = _context.groups.Select(s => new SelectListItem(s.Title, s.Id.ToString())).ToList();
            model.Teachers = _context.teachers.Select(t => new SelectListItem(t.Surname, t.Id.ToString())).ToList();
            model.Subjects = _context.subjects.Select(g => new SelectListItem(g.Title, g.Id.ToString())).ToList();
            model.Days = selectListItems;
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

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            for (int i = 0; i < 5; i++)
            {
                SelectListItem selectListItem = new SelectListItem(Enum.GetValues<DayList>()[i].ToString(), i.ToString());
                selectListItems.Add(selectListItem);
            }
            ScheduleCreateViewModel model = new ScheduleCreateViewModel();
            model.Groups = _context.groups.Select(s => new SelectListItem(s.Title, s.Id.ToString())).ToList();
            model.Teachers = _context.teachers.Select(t => new SelectListItem(t.Surname, t.Id.ToString())).ToList();
            model.Subjects = _context.subjects.Select(g => new SelectListItem(g.Title, g.Id.ToString())).ToList();
            model.Days = selectListItems;

            model.TeacherId = schedule.TeacherId;
            model.SubjectId = schedule.SubjectId;
            model.GroupId = schedule.GroupId;

            return View(model);
        }

        [HttpPost]
        public IActionResult EditPost(ScheduleCreateViewModel model) {
            Schedule newschedule = _context.schedules.FirstOrDefault(s => s.Id == model.Id);
            newschedule.TeacherId = model.TeacherId;
            newschedule.SubjectId = model.SubjectId;
            newschedule.GroupId = model.GroupId;
            newschedule.Day = model.Day;
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
