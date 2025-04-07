using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{

    /// <summary>
    /// The Entity Framework Core database context.
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Departments table.
        /// </summary>
        public DbSet<Department> Departments { get; set; }

        /// <summary>
        /// Students table.
        /// </summary>
        public DbSet<Student> Students { get; set; }
    }
}