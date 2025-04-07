using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    /// <summary>
    /// Repository for managing Department data synchronously.
    /// </summary>
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Finds a department by Id.
        /// </summary>
        public Department GetById(int id) => _context.Departments.Find(id);

        /// <summary>
        /// Retrieves all departments.
        /// </summary>
        public IEnumerable<Department> GetAll() => _context.Departments.ToList();

        /// <summary>
        /// Adds a new department.
        /// </summary>
        public void Add(Department entity) => _context.Departments.Add(entity);

        /// <summary>
        /// Updates an existing department.
        /// </summary>
        public void Update(Department entity) => _context.Departments.Update(entity);

        /// <summary>
        /// Deletes a department.
        /// </summary>
        public void Delete(Department entity) => _context.Departments.Remove(entity);

        /// <summary>
        /// Saves changes to the database.
        /// </summary>
        public void SaveChanges() => _context.SaveChanges();
    }
}
