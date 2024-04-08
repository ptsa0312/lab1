using System.ComponentModel.DataAnnotations;

namespace lab1.Models.DTO
{
    public class StudentsDto
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
