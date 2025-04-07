using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{

    /// <summary>
    /// Service layer for managing Student data.
    /// </summary>
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retrieves a student by its Id.
        /// </summary>
        public StudentDTO GetById(int id)
        {
            var student = _repository.GetById(id);
            if (student == null) return null;

            return new StudentDTO
            {
                Id = student.Id,
                Name = student.Name,
                DepartmentId = student.DepartmentId
            };
        }

        /// <summary>
        /// Retrieves all students.
        /// </summary>
        public IEnumerable<StudentDTO> GetAll()
        {
            var students = _repository.GetAll();
            return students.Select(s => new StudentDTO
            {
                Id = s.Id,
                Name = s.Name,
                DepartmentId = s.DepartmentId
            });
        }

        /// <summary>
        /// Adds a new student.
        /// </summary>
        public StudentDTO Add(StudentDTO dto)
        {
            var student = new Student
            {
                Name = dto.Name,
                DepartmentId = dto.DepartmentId
            };
            _repository.Add(student);
            _repository.SaveChanges();
            dto.Id = student.Id;
            return dto;
        }

        /// <summary>
        /// Updates an existing student.
        /// </summary>
        public StudentDTO Update(StudentDTO dto)
        {
            var student = _repository.GetById(dto.Id);
            if (student == null) return null;

            student.Name = dto.Name;
            student.DepartmentId = dto.DepartmentId;
            _repository.Update(student);
            _repository.SaveChanges();
            return dto;
        }

        /// <summary>
        /// Deletes a student by its Id.
        /// </summary>
        public bool Delete(int id)
        {
            var student = _repository.GetById(id);
            if (student == null) return false;

            _repository.Delete(student);
            _repository.SaveChanges();
            return true;
        }
    }
}
