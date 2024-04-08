using lab1.Models;
using Microsoft.EntityFrameworkCore;

namespace lab1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions dbContextOptions ) : base(dbContextOptions)
        { 
        
        }

        public DbSet<Students> Students { get; set; }
        public DbSet<Courses> courses { get; set; }
        public DbSet<StudentCourses> StudentCourses { get;set; }

    }
}
