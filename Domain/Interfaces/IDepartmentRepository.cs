using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    /// <summary>
    /// Defines repository operations for Department entities.
    /// </summary>
    public interface IDepartmentRepository
    {
        Department GetById(int id);
        IEnumerable<Department> GetAll();
        void Add(Department entity);
        void Update(Department entity);
        void Delete(Department entity);
        void SaveChanges();
    }
}
