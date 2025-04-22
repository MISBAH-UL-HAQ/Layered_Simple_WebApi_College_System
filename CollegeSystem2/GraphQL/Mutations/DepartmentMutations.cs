using Application.DTOs;
using Application.Interfaces;
using HotChocolate;
using HotChocolate.Types;
using System.Threading.Tasks;

namespace CollegeSystem2.GraphQL.Mutations
{
    [ExtendObjectType(Name = "Mutation")]
    public class DepartmentMutations
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentMutations(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [GraphQLName("addDepartment")]
        public async Task<DepartmentDTO> AddDepartmentAsync(DepartmentDTO input)
        {
            return  _departmentService.Add(input);
        }

        [GraphQLName("updateDepartment")]
        public async Task<DepartmentDTO> UpdateDepartmentAsync(int id, DepartmentDTO input)
        {
            input.Id = id;
            return _departmentService.Update(input);
        }

        [GraphQLName("deleteDepartment")]
        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            return  _departmentService.Delete(id);
        }
    }
}
    

