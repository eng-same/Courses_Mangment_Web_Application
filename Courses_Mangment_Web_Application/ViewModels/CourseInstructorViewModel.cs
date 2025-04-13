using Courses_Mangment_Web_Application.Models;
namespace Courses_Mangment_Web_Application.ViewModels
{
    public class CourseInstructorViewModel
    {
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Instructor> Instructors { get; set; }
    }
}
