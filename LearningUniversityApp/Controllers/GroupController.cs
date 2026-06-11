using LearningUniversityApp.Data;
using LearningUniversityApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace LearningUniversityApp.Controllers
{
    public class GroupController : Controller
    {

        private ApplicationContext _context;
        public GroupController(ApplicationContext context)
        {
            this._context = context;
        }
        public IActionResult ReturnToMenu() {
            return RedirectToAction("Menu", "Student");
        }

        public IActionResult Show(int? id_filter, string title_filter, string description_filter) 
        {
            var groups = _context.groups.OrderBy(g => g.Title).AsQueryable();

            if (id_filter.HasValue)
            {
                groups = groups.Where(g => g.Id == id_filter);
            }
         
            return View(groups.ToList());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPost(Models.Group group) {
            
            _context.groups.Add(group);
            _context.SaveChanges();
            return RedirectToAction("Menu", "Student");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Models.Group group = _context.groups.FirstOrDefault(s => s.Id == id);
            _context.groups.Remove(group);
            _context.SaveChanges();
            return RedirectToAction("GetAllGroups");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Models.Group groups = _context.groups.FirstOrDefault(s => s.Id == id);
            return View(groups);
        }

        [HttpPost]
        public IActionResult EditPost(Models.Group groups) {
            Models.Group NewGroup = _context.groups.FirstOrDefault(s => s.Id == groups.Id);
            NewGroup.Title = groups.Title;
            NewGroup.Description = groups.Description;
            _context.groups.Update(NewGroup);
            _context.SaveChanges();
            return RedirectToAction("GetAllGroups");

        }



    }
}
