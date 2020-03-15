using System.Data.Entity;
using ServerUsage.Models;

namespace ServerUsage.EF
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext() : base("DefaultConnection")
		{ }

		public DbSet<ServerHistory> ServerHistories { get; set; }
	}
}