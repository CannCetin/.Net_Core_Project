using Microsoft.EntityFrameworkCore;

namespace BlogApiDemo.DataAccessLayer
{
	public class Context :DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=CAN\\SQLEXPRESS01;database=CoreBlogApiDb;integrated security=True;");
		}
        public DbSet<Employee> Employees { get; set; }
    }
}
