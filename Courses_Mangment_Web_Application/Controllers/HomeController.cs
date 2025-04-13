using Courses_Mangment_Web_Application.Models;
using Courses_Mangment_Web_Application.Interfaces;
using Courses_Mangment_Web_Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Courses_Mangment_Web_Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IRepository<Course> _courserepo;

        private readonly IRepository<Instructor> _instructorepo;

        public HomeController(ILogger<HomeController> logger, IRepository<Instructor> instructorRepository, IRepository<Course> courseRepository)
        {
            _logger = logger;
            _instructorepo = instructorRepository;
            _courserepo = courseRepository;
        }

        public async Task< IActionResult> Index()
        {
            var courses = await _courserepo.GetAllWithincludeAsync(c => c.Enrollments); ;
            var instructors = await _instructorepo.GetAllWithincludeAsync(c => c.Courses); ;

            var viewModel = new CourseInstructorViewModel
            {
                Courses = courses,
                Instructors = instructors
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
