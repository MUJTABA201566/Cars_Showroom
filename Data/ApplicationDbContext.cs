using Cars_Showroom.Models;
using Microsoft.EntityFrameworkCore;

namespace Cars_Showroom.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<Car> cars { get; set; }
    }
}
