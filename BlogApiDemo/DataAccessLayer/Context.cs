using Microsoft.EntityFrameworkCore;

namespace BlogApiDemo.DataAccessLayer
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-04FKJQB\\SQLEXPRESS;Database=CoreBlogApiDb;Integrated Security=True;");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
