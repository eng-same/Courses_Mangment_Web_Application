namespace Courses_Mangment_Web_Application.Models
{
    public class StudentCourse
    {
        
        public int? evaluation {  get; set; }//added in the second  miagration

        public string? feedback { get; set; } ///added in the second  miagration



        //Composite Key
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        //Navigation Property
        public Student Student { get; set; }
        public Course Course { get; set; }

    }
}
