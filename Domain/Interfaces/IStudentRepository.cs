using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    /// <summary>
    /// Defines repository operations for Student entities.
    /// </summary>
    public interface IStudentRepository
    {
        Student GetById(int id);
        IEnumerable<Student> GetAll();
        void Add(Student entity);
        void Update(Student entity);
        void Delete(Student entity);
        void SaveChanges();
    }
}

