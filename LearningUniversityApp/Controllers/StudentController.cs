using LearningUniversityApp.Data;
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

        public StudentController(ApplicationContext context)
        {
            this._context = context;
        }


        public IActionResult Menu()
        {
            return View();
        }

        public IActionResult Show(StudentFilterViewModel studentFilterViewModel)
        {
            var students = _context.students.OrderBy(g => g.Name).AsQueryable();

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
            Student new_student = new Student();
            new_student.Name = studentCreateViewModel.Name;
            new_student.Surname = studentCreateViewModel.Surname;
            new_student.DateOfBirth = studentCreateViewModel.DateOfBirth;
            new_student.GroupId = studentCreateViewModel.GroupId;
            _context.students.Add(new_student);
            _context.SaveChanges();
            return RedirectToAction("Show");
        }

        public IActionResult Edit(int id)
        {
            Student student = _context.students.First(s => s.Id == id);
            return View(student);
        }

        [HttpPost]
        public IActionResult EditPost(Student student)
        {
            Student existed_student = _context.students.First(s => s.Name == student.Name);
            existed_student.Name = student.Name;
            existed_student.Surname = student.Surname;
            existed_student.DateOfBirth = student.DateOfBirth;

            _context.SaveChanges();
            return RedirectToAction("Show");
        }

        public IActionResult Delete(int id) {
            Student student = _context.students.First(s => s.Id == id);
            _context.students.Remove(student);
            _context.SaveChanges(); 
            return RedirectToAction("Show");
        }
    
    }
}
