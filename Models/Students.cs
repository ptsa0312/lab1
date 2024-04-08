using System.ComponentModel.DataAnnotations;

namespace lab1.Models
{
    public class Students
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        /*public ICollection<StudentCourses> StudentCourses { get; set; }*/
    }
}
