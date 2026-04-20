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

        public IActionResult GetAllGroups() {
            List<Models.Group> groups = _context.groups.ToList();

            return View(groups);
        }

        [HttpGet]
        public IActionResult CreateGroup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateGroupPost(Models.Group group) {
            if (string.IsNullOrEmpty(group.Id)) {
                group.Id = Guid.NewGuid().ToString();
            }
            _context.groups.Add(group);
            _context.SaveChanges();
            return RedirectToAction("Menu", "Student");
        }

        [HttpPost]
        public IActionResult DeleteGroup(string id)
        {
            Models.Group group = _context.groups.FirstOrDefault(s => s.Id == id);
            _context.groups.Remove(group);
            _context.SaveChanges();
            return RedirectToAction("GetAllGroups");
        }

        [HttpGet]
        public IActionResult EditGroup(string id)
        {
            Models.Group groups = _context.groups.FirstOrDefault(s => s.Id == id);
            return View(groups);
        }

        [HttpPost]
        public IActionResult EditGroupPost(Models.Group groups) {
            Models.Group NewGroup = _context.groups.FirstOrDefault(s => s.Id == groups.Id);
            NewGroup.Title = groups.Title;
            NewGroup.Description = groups.Description;
            _context.groups.Update(NewGroup);
            _context.SaveChanges();
            return RedirectToAction("GetAllGroups");

        }



    }
}
