using Application.DTOs;
using Application.Interfaces;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CollegeSystem2.GraphQL.Queries

{
    [ExtendObjectType(Name = "Query")]
    public class DepartmentQueries
    {
        // Inject the department service via constructor dependency injection.
        private readonly IDepartmentService _departmentService;
        public DepartmentQueries(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // Exposes a query to get all departments.
        [GraphQLDescription("Get all departments.")]
        public async Task<IEnumerable<DepartmentDTO>> GetDepartmentsAsync()
        {
            return _departmentService.GetAll();
        }

        // Exposes a query to get a department by id.
        [GraphQLDescription("Get a department by its id.")]
        public async Task<DepartmentDTO> GetDepartmentByIdAsync(int id)
        {
            return _departmentService.GetById(id);
        }
    }
}
    