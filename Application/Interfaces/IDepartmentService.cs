using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    /// <summary>
    /// Defines business operations for Department data.
    /// </summary>
    public interface IDepartmentService
    {
        DepartmentDTO GetById(int id);
        IEnumerable<DepartmentDTO> GetAll();
        DepartmentDTO Add(DepartmentDTO dto);
        DepartmentDTO Update(DepartmentDTO dto);
        bool Delete(int id);
    }
}