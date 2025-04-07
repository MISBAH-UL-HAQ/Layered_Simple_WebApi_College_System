using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   
        public class Student
        {
            /// <summary>
            /// The unique identifier for the student.
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// The name of the student.
            /// </summary>
            [Required(ErrorMessage = "Student name is required.")]
            [StringLength(100, ErrorMessage = "Student name cannot exceed 100 characters.")]
            public string Name { get; set; }

            /// <summary>
            /// The foreign key for the department.
            /// </summary>
            public int DepartmentId { get; set; }

            /// <summary>
            /// Navigation property to the student's department.
            /// </summary>
            public Department Department { get; set; }
        }
    }