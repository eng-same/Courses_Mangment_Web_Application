using Courses_Mangment_Web_Application.Models;
using System.Collections;

namespace Courses_Mangment_Web_Application.ViewModels
{
    public class CourseCategoryViewModel
    {
        public ICollection<Course> Courses { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
