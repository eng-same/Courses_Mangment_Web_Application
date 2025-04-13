using Courses_Mangment_Web_Application.Interfaces;
using Courses_Mangment_Web_Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Courses_Mangment_Web_Application.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IRepository<StudentCourse> _enrollmentRepo;

        public EnrollmentController(IRepository<StudentCourse> enrollmentRepo)
        {
            _enrollmentRepo = enrollmentRepo;
        }

        public async Task<IActionResult> Index()
        {
            var enrollments = await _enrollmentRepo.GetAllWithincludeAsync(e => e.Course, e => e.Student);
            return View(enrollments);
        }

        public async Task<IActionResult> Details(int id)
        {
            var enrollment = await _enrollmentRepo.GetByIdAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            return View(enrollment);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(StudentCourse model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _enrollmentRepo.AddAsync(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var enrollment = await _enrollmentRepo.GetByIdAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            return View(enrollment);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, StudentCourse model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _enrollmentRepo.UpdateAsync(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var enrollment = await _enrollmentRepo.GetByIdAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            return View(enrollment);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrollment = await _enrollmentRepo.GetByIdAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }

            await _enrollmentRepo.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GiveFeedback(int studentId, int courseId)
        {
            var enrollment = await _enrollmentRepo.GetByCompositeKeyAsync(studentId, courseId);
            if (enrollment == null)
            {
                return NotFound();
            }
            return View(enrollment);
        }

        [HttpPost]
        public async Task<IActionResult> GiveFeedback(int studentId, int courseId, StudentCourse model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var enrollment = await _enrollmentRepo.GetByCompositeKeyAsync(studentId, courseId);
            if (enrollment == null)
            {
                return NotFound();
            }

            // Update feedback and evaluation
            enrollment.feedback = model.feedback;
            enrollment.evaluation = model.evaluation;

            await _enrollmentRepo.UpdateAsync(enrollment);
            return RedirectToAction("Index");
        }
    }
}
