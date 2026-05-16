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
          


             IEnumerable<IGrouping<DayList, Schedule>> schedules = _context.schedules
                .Include(s=>s.Teacher)
                .Include(s=>s.Subject)
                .Include(s=>s.Group)
                .AsEnumerable()
                .GroupBy(s=>s.Day)
                .ToList(); 
            return View(schedules);
        }

        public IActionResult Create() 
        {
            List<SelectListItem> DaySelectListItems = new List<SelectListItem>();
            for (int i = 0; i < 5; i++)
            {
                SelectListItem DaySelectListItem = new SelectListItem(Enum.GetValues<DayList>()[i].ToString(), i.ToString());
                DaySelectListItems.Add(DaySelectListItem);
            }

            List<SelectListItem> LessonNumberSelectListItems = new List<SelectListItem>();
            for (int i = 1; i <= 7; i++)
            {
                SelectListItem LessonNumberSelectListItem = new SelectListItem(i.ToString(), i.ToString());
                LessonNumberSelectListItems.Add(LessonNumberSelectListItem);
            }

            ScheduleCreateViewModel model = new ScheduleCreateViewModel();
            model.Groups = _context.groups.Select(s => new SelectListItem(s.Title, s.Id.ToString())).ToList();
            model.Teachers = _context.teachers.Select(t => new SelectListItem(t.Surname, t.Id.ToString())).ToList();
            model.Subjects = _context.subjects.Select(g => new SelectListItem(g.Title, g.Id.ToString())).ToList();
            model.Days = DaySelectListItems;
            model.LessonNumbers = LessonNumberSelectListItems;
            return View(model);
        }

        [HttpPost]
        public IActionResult CreatePost(ScheduleCreateViewModel model) 
        {
            Schedule schedules = _context.schedules.FirstOrDefault(s => (s.TeacherId == model.TeacherId && s.Day == model.Day && s.LessonNumber == model.LessonNumber) || (s.GroupId == model.GroupId && s.Day == model.Day && s.LessonNumber == model.LessonNumber));
            if (schedules == null)
            {
                Schedule schedule = new Schedule();

                schedule.SubjectId = model.SubjectId;
                schedule.TeacherId = model.TeacherId;
                schedule.GroupId = model.GroupId;
                schedule.Day = model.Day;
                schedule.LessonNumber = model.LessonNumber;

                _context.schedules.Add(schedule);
                _context.SaveChanges();
                return RedirectToAction("Show");
            }
            else
            {
                //ViewData["Error"] = "Цей викладач вже зайнятий у вибраний день!";
                return RedirectToAction("Create");
            }
            //modelBuilder.Entity<Schedule>()
            //.HasIndex(s => new { s.TeacherId, s.Day })
            //.IsUnique();

            //model.Days = Enum.GetValues<DayList>()
            //.Select((d, index) => new SelectListItem(d.ToString(), index.ToString()))
            //.Take(5) // Берем первые 5 дней как в твоем цикле
            //.ToList();






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

            model.Id = id;
            return View(model);
        }

        [HttpPost]
        public IActionResult EditPost(ScheduleCreateViewModel model) 
        {
            Schedule newschedule = _context.schedules.FirstOrDefault(s => s.Id == model.Id);
            newschedule.TeacherId = model.TeacherId;
            newschedule.SubjectId = model.SubjectId;
            newschedule.GroupId = model.GroupId;
            newschedule.Day = model.Day;
            _context.schedules.Update(newschedule);
            _context.SaveChanges();
            return RedirectToAction("Show");
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
