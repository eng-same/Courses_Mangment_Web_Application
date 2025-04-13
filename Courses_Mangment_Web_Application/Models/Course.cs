using System.ComponentModel.DataAnnotations;

namespace Courses_Mangment_Web_Application.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(255, ErrorMessage = "Title cannot exceed 255 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Hours are required.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Hours must be greater than 0.")]
        public decimal Hours { get; set; }

        public decimal Evaluation { get; set; } = 0; //added in the miagration and haven't been tested yet!

        //Fk
        [Required(ErrorMessage = "Instructor is required.")] 
        public int InstructorId { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }

        //Navigation Property
        public Instructor Instructor { get; set; }
        
        public Category Category { get; set; }

        public ICollection<StudentCourse> Enrollments { get; set; }  //many to many
    }
}
