namespace Courses_Mangment_Web_Application.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Email { get; set; }

        //Navigation Property
        public ICollection<Course> Courses { get; set; } //one to many

    }
}
