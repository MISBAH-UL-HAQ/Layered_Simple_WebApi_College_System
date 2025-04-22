using Application.DTOs;
using HotChocolate.Types;

namespace CollegeSystem2.GraphQL.Types
{
    public class DepartmentType : ObjectType<DepartmentDTO>
    {
        protected override void Configure(IObjectTypeDescriptor<DepartmentDTO> descriptor)
        {
            descriptor.Field(d => d.Id).Description("The unique identifier of the department.");
            descriptor.Field(d => d.Name).Description("The name of the department.");
        }
    }
}