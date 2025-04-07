using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    // <summary>
    /// Represents a college department.
    /// </summary>
    public class Department
    {
        /// <summary>
        /// The unique identifier for the department.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the department.
        /// </summary>
        [Required(ErrorMessage = "Department name is required.")]
        [StringLength(100, ErrorMessage = "Department name cannot exceed 100 characters.")]
        public string Name { get; set; }

        /// <summary>
        /// Collection of students that belong to this department.
        /// </summary>
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}

