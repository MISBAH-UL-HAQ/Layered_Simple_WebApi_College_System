using Application.DTOs;
using Application.Interfaces;
using HotChocolate;
using HotChocolate.Types;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace CollegeSystem2.GraphQL.Queries
{
    [ExtendObjectType(Name = "Query")]
    public class StudentQueries
    {
        private readonly IStudentService _studentService;
        public StudentQueries(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [GraphQLDescription("Get all students.")]
        public async Task<IEnumerable<StudentDTO>> GetStudentsAsync()
        {
            return _studentService.GetAll();
        }

        [GraphQLDescription("Get a student by its id.")]
        public async Task<StudentDTO> GetStudentByIdAsync(int id)
        {
            return _studentService.GetById(id);
        }
    }
}
    

