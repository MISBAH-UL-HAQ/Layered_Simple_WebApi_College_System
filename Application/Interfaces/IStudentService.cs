using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Interfaces
{
    /// <summary>
    /// Defines business operations for Student data.
    /// </summary>
    public interface IStudentService
    {
        StudentDTO GetById(int id);
        IEnumerable<StudentDTO> GetAll();
        StudentDTO Add(StudentDTO dto);
        StudentDTO Update(StudentDTO dto);
        bool Delete(int id);
    }
}