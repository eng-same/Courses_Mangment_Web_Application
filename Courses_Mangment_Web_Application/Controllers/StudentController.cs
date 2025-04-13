using Courses_Mangment_Web_Application.Models;
using Courses_Mangment_Web_Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Courses_Mangment_Web_Application.Controllers
{
    public class StudentController : Controller
    {
        private readonly IRepository<Student> _studentrepo;
        public StudentController(IRepository<Student> studentrepo) {
            _studentrepo = studentrepo;
        }
        public async Task<IActionResult> Index() { 
            var students = await _studentrepo.GetAllWithincludeAsync(s=> s.Enrollments);

            return View(students); }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create( Student model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _studentrepo.AddAsync(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int Id) 
        { 
            var student= await _studentrepo.GetByIdAsync(Id);
            if (student == null) 
            { 
                return NotFound(); 
            }
            return View(student); 
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit( int Id, Student model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _studentrepo.UpdateAsync(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int Id) 
        {
            var student = await _studentrepo.GetByIdAsync(Id);
            if (student == null)
            {
                return NotFound();
            }
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> DeleteConfirmed(int id) {
            var course = await _studentrepo.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            await _studentrepo.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
