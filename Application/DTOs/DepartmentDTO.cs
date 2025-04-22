using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{

    public class DepartmentDTO
    {
        public int Id { get; set; }
        //public int? Id { get; set; } // now the id field is optional in input
        public string Name { get; set; }
    }
}
