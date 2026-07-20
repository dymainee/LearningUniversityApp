using LearningUniversityApp.Application.Interfaces;
using LearningUniversityApp.Application.Services;
using LearningUniversityApp.Infrastructure.Data;
using LearningUniversityApp.Models;
using LearningUniversityApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace LearningUniversityApp.Controllers
{
    public class GroupController : Controller
    {
        private ApplicationContext _context;
        private readonly IGroupService _groupService;

        public GroupController(ApplicationContext context, IGroupService groupService)
        {
            _context = context;
            _groupService = groupService;
        }
        public IActionResult ReturnToMenu() {
            return RedirectToAction("Menu", "Student");
        }

        public IActionResult Show(GroupComplexViewModel groupViewModel) 
        {
            var groups = _groupService.GetAll(groupViewModel.id_filter).OrderBy(g => g.Title).AsQueryable();

            if (groupViewModel.id_filter.HasValue) {
                groups = groups.Where(g => g.Id == groupViewModel.id_filter);
            }

            if (!string.IsNullOrEmpty(groupViewModel.title_filter))
            {
                groups = groups.Where(g => g.Title.Contains(groupViewModel.title_filter));
            }

            switch (groupViewModel.sortField)
            {
                case "Id":
                    groups = groupViewModel.sortOrder == SortOrder.Descending ? groups.OrderByDescending(g => g.Id) : groups.OrderBy(g => g.Id);
                    break;

                case "Title":
                    groups = groupViewModel.sortOrder == SortOrder.Descending ? groups.OrderByDescending(g => g.Title) : groups.OrderBy(g => g.Title);
                    break;
            }

            groupViewModel.TotalCount = groups.Count();

            groupViewModel.groups = groups.ToList();//Skip((groupViewModel.PageNumber - 1) * groupViewModel.PageSize)
            //                              .Take(groupViewModel.PageSize)
            //                              ;

            return View(groupViewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPost(Models.Group group) {

            _groupService.Create(group.Title, group.Description);
            return RedirectToAction("Menu", "Student");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _groupService.Delete(id);
            return RedirectToAction("Show");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Models.Group groups = _groupService.GetById(id);
            return View(groups);
        }

        [HttpPost]
        public IActionResult EditPost(Models.Group groups) {
            _groupService.Edit(groups);
            return RedirectToAction("Show");

        }



    }
}
