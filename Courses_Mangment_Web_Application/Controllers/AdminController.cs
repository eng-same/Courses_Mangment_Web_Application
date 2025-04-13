using Courses_Mangment_Web_Application.Interfaces;
using Courses_Mangment_Web_Application.Models;
using Courses_Mangment_Web_Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Courses_Mangment_Web_Application.Controllers
{
    public class AdminController : Controller
    {
        private readonly IRepository<Course> _coursesRepo;
        private readonly IRepository<Category> _categoriesRepo;

        public AdminController(IRepository<Course> coursesRepo, IRepository<Category> categoriesRepo)
        {
            _coursesRepo = coursesRepo;
            _categoriesRepo = categoriesRepo;
        }

        public IActionResult Dashboard() => View();

        public IActionResult ManageUsers() => View();

        public async Task<IActionResult> ManageCourses() {

            var courses = await _coursesRepo.GetAllWithincludeAsync(c => c.Instructor, c => c.Enrollments);
            var categories = await _categoriesRepo.GetAllWithincludeAsync(ca => ca.Courses);

            var vm = new CourseCategoryViewModel()
            {
                Courses = courses.ToList(),
                Categories = categories.ToList()
            };

            return View("~/Views/Courses/Index.cshtml", vm); 
        }

        public IActionResult ManageInstractors() => View();
    }
}
