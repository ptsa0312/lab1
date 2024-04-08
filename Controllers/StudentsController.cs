using lab1.Data;
using lab1.Models;
using lab1.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace lab1.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly DataContext dbContext;
        public StudentsController(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var student = dbContext.Students.ToList();

            var studentdto = new List<StudentsDto>();
            foreach(var stude in student)
            {
                studentdto.Add(new StudentsDto()
                {
                    Id = stude.Id,
                    Name = stude.Name,
                });
            }
            return Ok(studentdto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetbyId([FromRoute]Guid id)
        {
            var stuId = dbContext.Students.Find(id);
            if(stuId == null)
            {
                return NotFound();
            }

            var stuDto = new StudentsDto
            {
                Id = stuId.Id,
                Name = stuId.Name,
            };

            return Ok(stuDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddStudentsRequestDto addStudentsRequestDto)
        {
            var stu = new Students
            {
                Id = Guid.NewGuid(),
                Name = addStudentsRequestDto.Name,
            };

            await dbContext.Students.AddAsync(stu);
            await dbContext.SaveChangesAsync();

            var studeDto = new StudentsDto
            {
                Id = stu.Id,
                Name = stu.Name,
            };
            return CreatedAtAction(nameof(GetbyId), new {id = studeDto.Id}, studeDto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdataStudent([FromRoute] Guid id, UpdataStudentRequestDto updataStudentRequestDto)
        {
            var student = await dbContext.Students.FindAsync(id);
            if(student != null)
            {
                student.Name = updataStudentRequestDto.Name;

                await dbContext.SaveChangesAsync();

                return Ok(student);
            }
             
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteStuden([FromRoute] Guid id)
        {
            var delstu = await dbContext.Students.FindAsync(id);

            if(delstu != null)
            {
                dbContext.Remove(delstu);
                await dbContext.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }
    }
}
