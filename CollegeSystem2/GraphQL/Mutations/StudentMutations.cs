using Application.DTOs;
using Application.Interfaces;
using HotChocolate;
using HotChocolate.Types;
using System.Threading.Tasks;

namespace CollegeSystem2.GraphQL.Mutations
{

    [ExtendObjectType(Name = "Mutation")]
    public class StudentMutations
    {
        private readonly IStudentService _studentService;
        public StudentMutations(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [GraphQLName("addStudent")]
        public async Task<StudentDTO> AddStudentAsync(StudentDTO input)
        {
            return  _studentService.Add(input);
        }

        [GraphQLName("updateStudent")]
        public async Task<StudentDTO> UpdateStudentAsync(int id, StudentDTO input)
        {
            input.Id = id;
            return _studentService.Update(input);
        }

        [GraphQLName("deleteStudent")]
        public async Task<bool> DeleteStudentAsync(int id)
        {
            return _studentService.Delete(id);
        }
    }
}
    