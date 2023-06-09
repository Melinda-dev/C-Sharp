using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // change the connection string below as needed
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\liu_s\OneDrive\Documents\Holmesglen Assessment\C#\Assessment 2\AT2Project\Entity Framework\HolmesglenStudentManagementSystemEF.db");

        }
   }
}
