using System.ComponentModel.DataAnnotations;

namespace lab1.Models.DTO
{
    public class CoursesDto
    {
        [Key]
        public Guid Id { get; set; }
        public string CoursesName { get; set; }
        public int Description { get; set; }
    }
}
