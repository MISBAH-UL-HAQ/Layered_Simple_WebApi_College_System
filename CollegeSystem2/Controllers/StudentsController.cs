using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs;
using Domain.Entities;

namespace CollegeSystem2.Controllers
{
    /// <summary>
    /// API Controller for managing Student resources.
    /// </summary>
    

    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retrieves all students.
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<StudentDTO>> GetAll()
        {
            var students = _service.GetAll();
            return Ok(students);
        }

        /// <summary>
        /// Retrieves a student by Id.
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<StudentDTO> GetById(int id)
        {
            var student = _service.GetById(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        /// <summary>
        /// Creates a new student.
        /// </summary>
        [HttpPost]
        public ActionResult<StudentDTO> Create([FromBody] StudentDTO dto)
        {
            var createdStudent = _service.Add(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdStudent.Id }, createdStudent);
        }

        /// <summary>
        /// Updates an existing student.
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] StudentDTO dto)
        {
            dto.Id = id;
            var updatedStudent = _service.Update(dto);
            if (updatedStudent == null)
                return NotFound();
            return NoContent();
        }

        /// <summary>
        /// Deletes a student.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}
