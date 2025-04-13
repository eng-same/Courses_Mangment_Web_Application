using Courses_Mangment_Web_Application.Interfaces;
using Courses_Mangment_Web_Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Courses_Mangment_Web_Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Courses_Mangment_Web_Application.Controllers
{
    public class CoursesController : Controller
    {
        private readonly IRepository<Course> _coursesRepo; 
        private readonly IRepository<Instructor> _instructorRepo; 
        private readonly IRepository<Category> _categoryRepo;
        private readonly IRepository<StudentCourse> _enrollmentRepo;

        public CoursesController(IRepository<Course> coursesRepo, IRepository<Instructor> instructorRepo, IRepository<Category> categoryRepo, IRepository<StudentCourse> enrollmentRepo)
        {
            _coursesRepo = coursesRepo;
            _instructorRepo = instructorRepo;
            _categoryRepo = categoryRepo;
            _enrollmentRepo = enrollmentRepo;
        }

        public async Task<IActionResult> Index()
        {
            var courses = await _coursesRepo.GetAllWithincludeAsync(c => c.Instructor, c => c.Enrollments);
            var categories = await _categoryRepo.GetAllWithincludeAsync(ca => ca.Courses);
            courses.ToList().ForEach(course =>
            {
                course.Evaluation = course.Enrollments?.Any() == true
                    ? (decimal)course.Enrollments.Average(e => (decimal?)e.evaluation ?? 0)
                    : 0;
            });
            var vm = new CourseCategoryViewModel()
            {
                Courses = courses.ToList(),
                Categories = categories.ToList()
            };

            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var course = await _coursesRepo.GetWithIncludeAsync(id, query =>
                query.Include(c => c.Instructor)
                     .Include(c => c.Category)
                     .Include(c => c.Enrollments)
                     .ThenInclude(e => e.Student) 
            );

            if (course == null)
            {
                return NotFound();
            }

            var vm = new CourseViewModel
            {
                CourseName = course.Title,
                InstructorName = course.Instructor?.Name ?? "N/A",
                CategoryName = course.Category?.Name ?? "N/A",
                Description = course.Description,
                Price = course.Price,
                Hours = course.Hours,
                NumberOfStudents = course.Enrollments?.Count ?? 0,
                Evaluation = course.Enrollments?.Any() == true
                    ? (decimal)course.Enrollments.Average(e => (decimal?)e.evaluation ?? 0)
                    : 0,
                feedback = course.Enrollments?
                    .Where(e => !string.IsNullOrEmpty(e.feedback))
                    .Select(e => e.feedback)
                    .ToList() ?? new List<string>(),
                Students = course.Enrollments?
                    .Select(e => e.Student)
                    .Where(s => s != null)
                    .ToList() ?? new List<Student>()
            };

            return View(vm);
        }


        public async Task<IActionResult> Create()
        {
            //var instructors = await _instructorRepo.GetAllAsync();
            //var categories = await _categoryRepo.GetAllAsync();

            //ViewBag.Instructors = new SelectList(instructors, "Id", "Name");
            //ViewBag.Categories = new SelectList(categories, "Id", "Name");
            PopulateViewBag();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Course model)
        {
            Course course = new Course
            {
                Title = model.Title,
                Description = model.Description,
                Price = model.Price,
                Hours = model.Hours,
                InstructorId = model.InstructorId,
                CategoryId = model.CategoryId
            };

            //if (ModelState.IsValid)
            //{
            //    await _coursesRepo.AddAsync(model); //i don't know why model state is not Valid ,but it's work.
            //    return RedirectToAction("Index");
            //}
            await _coursesRepo.AddAsync(course);
            return RedirectToAction("Index");
        }

        private async Task PopulateViewBag()
        {
            var instructors = await _instructorRepo.GetAllAsync();
            var categories = await _categoryRepo.GetAllAsync();

            ViewBag.Instructors = new SelectList(instructors, "Id", "Name");
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var course = await _coursesRepo.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Course model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _coursesRepo.UpdateAsync(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var course = await _coursesRepo.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _coursesRepo.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            await _coursesRepo.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Enroll(int id)
        {
            var course = await _coursesRepo.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            var vm = new EnrollViewModel
            {
                CourseId = course.Id,
                CourseTitle = course.Title
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Enroll(EnrollViewModel vm)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(vm);
            //}

            var course = await _coursesRepo.GetByIdAsync(vm.CourseId);
            if (course == null)
            {
                return NotFound();
            }

            var enrollment = new StudentCourse
            {
                StudentId = vm.StudentId,
                CourseId = vm.CourseId
            };

            await _enrollmentRepo.AddAsync(enrollment);

            TempData["SuccessMessage"] = "Student enrolled successfully!";
            return RedirectToAction("Index");
        }
    }

}
