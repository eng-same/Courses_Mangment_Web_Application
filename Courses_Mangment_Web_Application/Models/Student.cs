namespace Courses_Mangment_Web_Application.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Email { get; set; }

        //Navigation Property
        public ICollection<StudentCourse> Enrollments { get; set; } //many to many

    }
}
