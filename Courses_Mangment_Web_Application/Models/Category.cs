namespace Courses_Mangment_Web_Application.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }
        
        //Navgation property 
        public ICollection<Course> Courses { get; set; }
    }
}
