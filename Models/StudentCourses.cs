using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace lab1.Models
{
  
    public class StudentCourses
    {
        [Key]
        public Guid StudentId { get; set; }
        public Guid CoursesId { get; set; }

        public Students Students { get; set; }
        public Courses Courses { get; set;}
    }
}
