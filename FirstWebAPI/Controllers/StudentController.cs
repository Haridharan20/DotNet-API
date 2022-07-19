using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstWebAPI.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly StudentDbContext _context;

        public StudentController(StudentDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Student/getStudents")]
        public async Task<ActionResult<List<Student>>> Get()
        {


            return Ok(await _context.Students.ToListAsync());
        }

        [HttpPost]
        [Route("Student/addStudent")]
        public async Task<ActionResult<List<Student>>> AddStudent([FromBody] Student stu)
        {
            _context.Students.Add(stu);
            await _context.SaveChangesAsync();  

            return Ok(await _context.Students.ToListAsync());
        }

        [HttpGet]
        [Route("Student/getStudent/{id}")]
        public async Task<ActionResult<Student>> getStudentById(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (student == null)
            {
                return NotFound("Student Not Found");
            }
            return Ok(student);
        }

        [HttpPut]
        [Route("Student/updateStudent/{id}")]
        public async Task<ActionResult<Student>> updateStudentById(int id, [FromBody] Student request)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (student == null)
            {
                return NotFound("Student Not Found");
            }
            student.Name = request.Name;
            student.Batch = request.Batch;
            student.Department = request.Department;

            await _context.SaveChangesAsync();
            return Ok(await _context.Students.ToListAsync());
        }

        [HttpDelete]
        [Route("Student/deleteStudent/{id}")]
        public async Task<ActionResult<Student>> deleteStudentById(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (student == null)
            {
                return NotFound("Student Not Found");
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return Ok("Student Deleted successfullly");
        }
    }
}
