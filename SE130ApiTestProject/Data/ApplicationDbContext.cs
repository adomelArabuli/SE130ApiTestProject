using Microsoft.EntityFrameworkCore;
using SE130ApiTestProject.Data.Models;

namespace SE130ApiTestProject.Data
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		public DbSet<Student> Students { get; set; }
		public DbSet<Lector> Lectors { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }
    }
}
