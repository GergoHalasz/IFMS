using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.DbContexts
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		public DbSet<Intervention> Interventions { get; set; }
		public DbSet<Client> Clients { get; set; }
		public DbSet<Technician> Technicians { get; set; }
		public DbSet<TechnicianAssignment> TechnicianAssignments { get; set; }
	}
}
