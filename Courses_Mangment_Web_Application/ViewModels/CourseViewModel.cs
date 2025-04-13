using Courses_Mangment_Web_Application.Models;

namespace Courses_Mangment_Web_Application.ViewModels
{
    public class CourseViewModel
    {
        public string CourseName { get; set; }
        public string InstructorName { get; set; }
        public string CategoryName { get; set; }

        public string Description { get; set; }
        public int NumberOfStudents { get; set; }
        public decimal Price { get; set; }
        public decimal Hours { get; set; }
        public decimal Evaluation { get; set; }


        public ICollection<string> feedback { get; set; } = new List<string>();
        public ICollection<Student> Students { get; set; } = new List<Student>();

    }
}
