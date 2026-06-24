using LearningUniversityApp.Data;
using LearningUniversityApp.Models;
using LearningUniversityApp.ViewModels;
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

        public IActionResult Show(GroupFilterViewModel groupFilterViewModel) 
        {
            var groups = _context.groups.OrderBy(g => g.Title).AsQueryable();

            if (groupFilterViewModel.id_filter.HasValue)
            {
                groups = groups.Where(g => g.Id == groupFilterViewModel.id_filter);
            }
            
            switch (groupFilterViewModel.sortField)
            {
                case "Id":
                    groups = groupFilterViewModel.sortOrder == SortOrder.Descending ? groups.OrderByDescending(g => g.Id) : groups.OrderBy(g => g.Id);
                    break;

                case "Title":
                    groups = groupFilterViewModel.sortOrder == SortOrder.Descending ? groups.OrderByDescending(g => g.Id) : groups.OrderBy(g => g.Id);
                    break;
            }

            groupFilterViewModel.groups = groups.ToList(); 
            return View(groupFilterViewModel);
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
