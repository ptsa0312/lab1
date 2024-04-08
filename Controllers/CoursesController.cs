using lab1.Data;
using lab1.Models.DTO;
using lab1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly DataContext dbContext;
        public CoursesController(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var courses = dbContext.courses.ToList();

            var coursesdto = new List<CoursesDto>();
            foreach (var cours in courses)
            {
                coursesdto.Add(new CoursesDto()
                {
                    Id = cours.Id,
                    CoursesName = cours.CoursesName,
                    Description = cours.Description,
                });
            }
            return Ok(coursesdto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetbyId([FromRoute] Guid id)
        {
            var courid = dbContext.courses.Find(id);
            if (courid == null)
            {
                return NotFound();
            }

            var courDto = new CoursesDto
            {
                Id = courid.Id,
                CoursesName = courid.CoursesName,
                Description= courid.Description,
            };

            return Ok(courDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddCoursesRequestDto addCoursesRequestDto)
        {
            var cour = new Courses
            {
                Id = Guid.NewGuid(),
                CoursesName = addCoursesRequestDto.CoursesName,
                Description = addCoursesRequestDto.Description,
            };

            await dbContext.courses.AddAsync(cour);
            await dbContext.SaveChangesAsync();

            var courDto = new CoursesDto
            {
                Id = cour.Id,
                CoursesName = cour.CoursesName,
                Description = cour.Description,
            };
            return CreatedAtAction(nameof(GetbyId), new { id = courDto.Id }, courDto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Updatacour([FromRoute] Guid id, UpdateCoursesRequestDto updateCoursesRequestDto)
        {
            var cour = await dbContext.courses.FindAsync(id);
            if (cour != null)
            {
                cour.CoursesName = updateCoursesRequestDto.CoursesName;
                cour.Description = updateCoursesRequestDto.Description;
                await dbContext.SaveChangesAsync();

                return Ok(cour);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCour([FromRoute] Guid id)
        {
            var delcour = await dbContext.courses.FindAsync(id);

            if (delcour != null)
            {
                dbContext.Remove(delcour);
                await dbContext.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }
    }
}
