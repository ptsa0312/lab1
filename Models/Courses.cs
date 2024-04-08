using System.ComponentModel.DataAnnotations;

namespace lab1.Models
{
    public class Courses
    {
        [Key]
        public Guid Id { get; set; }
        public string CoursesName { get; set; }
        public int Description { get; set; }

        /*public ICollection<StudentCourses> StudentCourses { get; set; }*/
    }
}
