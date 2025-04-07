using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{

    /// <summary>
    /// Repository for managing Student data synchronously.
    /// </summary>
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Finds a student by Id.
        /// </summary>
        public Student GetById(int id) => _context.Students.Find(id);

        /// <summary>
        /// Retrieves all students.
        /// </summary>
        public IEnumerable<Student> GetAll() => _context.Students.ToList();

        /// <summary>
        /// Adds a new student.
        /// </summary>
        public void Add(Student entity) => _context.Students.Add(entity);

        /// <summary>
        /// Updates an existing student.
        /// </summary>
        public void Update(Student entity) => _context.Students.Update(entity);

        /// <summary>
        /// Deletes a student.
        /// </summary>
        public void Delete(Student entity) => _context.Students.Remove(entity);

        /// <summary>
        /// Saves changes to the database.
        /// </summary>
        public void SaveChanges() => _context.SaveChanges();
    }
}