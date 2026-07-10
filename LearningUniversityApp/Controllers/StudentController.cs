using LearningUniversityApp.Application.Interfaces;
using LearningUniversityApp.Infrastructure.Data;
using LearningUniversityApp.Models;
using LearningUniversityApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;

namespace LearningUniversityApp.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationContext _context;
        private readonly IStudentService _studentService;

        public StudentController(ApplicationContext context, IStudentService studentService)
        {
            _context = context;
            _studentService = studentService;
        }

        public IActionResult Menu()
        {
            return View();
        }

        public IActionResult Show(StudentFilterViewModel studentFilterViewModel)
        {
            Console.WriteLine("Викликано сервіс");
            var students = _studentService.GetAll().OrderBy(g => g.Name).AsQueryable();

            if (studentFilterViewModel.id_filter.HasValue)
            {
                students = students.Where(g => g.Id == studentFilterViewModel.id_filter);
            }

            switch (studentFilterViewModel.sortField)
            {
                case "Id":
                    students = studentFilterViewModel.sortOrder == SortOrder.Descending ? students.OrderByDescending(g => g.Id) : students.OrderBy(g => g.Id);
                    break;

                case "Name":
                    students = studentFilterViewModel.sortOrder == SortOrder.Descending ? students.OrderByDescending(g => g.Id) : students.OrderBy(g => g.Id);
                    break;
            }

            studentFilterViewModel.students = students.ToList();
            return View(studentFilterViewModel);
        }

        public IActionResult Add()
        {
            StudentCreateViewModel studentCreateViewModel = new StudentCreateViewModel();
            studentCreateViewModel.Groups = _context.groups.Select(g => new SelectListItem(g.Title, g.Id.ToString())).ToList();
            return View(studentCreateViewModel);
        }

        [HttpPost]
        public IActionResult AddPost(StudentCreateViewModel studentCreateViewModel)
        {
            _studentService.Create(studentCreateViewModel.Name, studentCreateViewModel.Surname, studentCreateViewModel.DateOfBirth, studentCreateViewModel.GroupId);
            // Студента створено
            return RedirectToAction("Show");
        }

        public IActionResult Edit(int id)
        {
            Student student = _studentService.GetById(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult EditPost(Student student)
        {
            _studentService.Edit(student);
            return RedirectToAction("Show");
        }

        public IActionResult Delete(int id) {
           
            _studentService.Delete(id);

            return RedirectToAction("Show");
        }
    }
}
