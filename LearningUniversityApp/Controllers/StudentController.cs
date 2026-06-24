using Microsoft.AspNetCore.Mvc;
using LearningUniversityApp.Data;
using LearningUniversityApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using LearningUniversityApp.ViewModels;

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
            return RedirectToAction("GetAll");
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
            return RedirectToAction("GetAll");
        }

        public IActionResult Delete(int id) {
            Student student = _context.students.First(s => s.Id == id);
            _context.students.Remove(student);
            _context.SaveChanges(); 
            return RedirectToAction("GetAll");
        }
    
    }
}
