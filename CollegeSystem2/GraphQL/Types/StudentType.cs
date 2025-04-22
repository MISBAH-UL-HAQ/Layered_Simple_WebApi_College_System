using Application.DTOs;
using HotChocolate.Types;

namespace CollegeSystem2.GraphQL.Types
{
    public class StudentType : ObjectType<StudentDTO>
    {
        protected override void Configure(IObjectTypeDescriptor<StudentDTO> descriptor)
        {
            descriptor.Field(s => s.Id).Description("The unique identifier of the student.");
            descriptor.Field(s => s.Name).Description("The name of the student.");
            descriptor.Field(s => s.DepartmentId).Description("The ID of the department the student belongs to.");
        }
    }
}
