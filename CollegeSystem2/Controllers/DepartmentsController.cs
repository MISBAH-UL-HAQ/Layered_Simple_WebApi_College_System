using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollegeSystem2.Controllers
{

    /// <summary>
    /// API Controller for managing Department resources.
    /// </summary>
    

    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _service;

        public DepartmentsController(IDepartmentService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retrieves all departments.
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<DepartmentDTO>> GetAll()
        {
            var departments = _service.GetAll();
            return Ok(departments);
        }

        /// <summary>
        /// Retrieves a department by Id.
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<DepartmentDTO> GetById(int id)
        {
            var department = _service.GetById(id);
            if (department == null)
                return NotFound();
            return Ok(department);
        }

        /// <summary>
        /// Creates a new department.
        /// </summary>
        [HttpPost]
        public ActionResult<DepartmentDTO> Create([FromBody] DepartmentDTO dto)
        {
            var createdDepartment = _service.Add(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdDepartment.Id }, createdDepartment);
        }

        /// <summary>
        /// Updates an existing department.
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] DepartmentDTO dto)
        {
            dto.Id = id;
            var updatedDepartment = _service.Update(dto);
            if (updatedDepartment == null)
                return NotFound();
            return NoContent();
        }

        /// <summary>
        /// Deletes a department.
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

