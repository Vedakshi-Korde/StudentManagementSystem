////using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using StudentManagementSystem.Data;
//using StudentManagementSystem.Models;

//namespace StudentManagementSystem.Controllers
//{
//    [ApiController]
//    //[Route("api/[controller]")]
//    [Route("api/[controller]")]
//   // [Authorize]
//    public class StudentController : ControllerBase
//    {
//        private readonly AppDbContext _context;

//        public StudentController(AppDbContext context)
//        {
//            _context = context;
//        }

//        // GET ALL STUDENTS
//        [HttpGet]
//        public IActionResult GetStudents()
//        {
//            var students = _context.Students.ToList();

//            return Ok(students);
//        }

//        // ADD STUDENT
//        [HttpPost]

//        public IActionResult AddStudent(Student student)
//        {
//            student.CreatedDate = DateTime.Now;

//            _context.Students.Add(student);
//            _context.SaveChanges();

//            return Ok(student);
//        }

//        // UPDATE STUDENT
//        [HttpPut("{id}")]
//        public IActionResult UpdateStudent(int id, Student updatedStudent)
//        {
//            var student = _context.Students.Find(id);

//            if (student == null)
//            {
//                return NotFound();
//            }

//            student.Name = updatedStudent.Name;
//            student.Email = updatedStudent.Email;
//            student.Age = updatedStudent.Age;
//            student.Course = updatedStudent.Course;

//            _context.SaveChanges();

//            return Ok(student);
//        }

//        // DELETE STUDENT
//        [HttpDelete("{id}")]
//        public IActionResult DeleteStudent(int id)
//        {
//            var student = _context.Students.Find(id);

//            if (student == null)
//            {
//                return NotFound();
//            }

//            _context.Students.Remove(student);
//            _context.SaveChanges();

//            return Ok("Student Deleted");
//        }
//    }
//}
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.DTOs;
using StudentManagementSystem.Models;
using StudentManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;



namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _service;

        public StudentController(StudentService service)
        {
            _service = service;
        }
      

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }

        //[HttpPost]
        //public async Task<IActionResult> Add(Student student)
        //{
        //    await _service.Add(student);
        //    return Ok();
        //}
     
        [HttpPost]
        public async Task<IActionResult> Add(StudentCreateDto dto)
        {
            var student = new Student
            {
                Name = dto.Name,
                Email = dto.Email,
                Age = dto.Age,
                Course = dto.Course,
                CreatedDate = DateTime.Now
            };

            await _service.Add(student);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(Student student)
        {
            await _service.Update(student);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}