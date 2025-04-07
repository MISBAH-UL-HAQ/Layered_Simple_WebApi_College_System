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
    /// Service layer for managing Department data.
    /// </summary>
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retrieves a department by its Id.
        /// </summary>
        public DepartmentDTO GetById(int id)
        {
            var department = _repository.GetById(id);
            if (department == null) return null;

            return new DepartmentDTO
            {
                Id = department.Id,
                Name = department.Name
            };
        }

        /// <summary>
        /// Retrieves all departments.
        /// </summary>
        public IEnumerable<DepartmentDTO> GetAll()
        {
            var departments = _repository.GetAll();
            return departments.Select(d => new DepartmentDTO
            {
                Id = d.Id,
                Name = d.Name
            });
        }

        /// <summary>
        /// Adds a new department.
        /// </summary>
        public DepartmentDTO Add(DepartmentDTO dto)
        {
            var department = new Department { Name = dto.Name };
            _repository.Add(department);
            _repository.SaveChanges();
            dto.Id = department.Id;
            return dto;
        }

        /// <summary>
        /// Updates an existing department.
        /// </summary>
        public DepartmentDTO Update(DepartmentDTO dto)
        {
            var department = _repository.GetById(dto.Id);
            if (department == null) return null;

            department.Name = dto.Name;
            _repository.Update(department);
            _repository.SaveChanges();
            return dto;
        }

        /// <summary>
        /// Deletes a department by its Id.
        /// </summary>
        public bool Delete(int id)
        {
            var department = _repository.GetById(id);
            if (department == null) return false;

            _repository.Delete(department);
            _repository.SaveChanges();
            return true;
        }
    }
}