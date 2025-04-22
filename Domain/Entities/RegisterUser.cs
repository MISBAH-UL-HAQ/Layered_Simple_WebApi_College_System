using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    public class RegisterUser
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int DepartmentId { get; set; }
    }
}