using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.DbContexts
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new InterventionConfiguration());
			modelBuilder.ApplyConfiguration(new ContractConfiguration());
			modelBuilder.ApplyConfiguration(new TechnicianConfiguration());
			modelBuilder.ApplyConfiguration(new ClientConfiguration());
			modelBuilder.ApplyConfiguration(new SystemTypeConfiguration());
		}

		public DbSet<Intervention> Interventions { get; set; }
		public DbSet<Client> Clients { get; set; }
		public DbSet<Technician> Technicians { get; set; }
		public DbSet<SystemType> SystemTypes { get; set; }
		public DbSet<Contract> Contracts { get; set; }
		public DbSet<Geolocation> Geolocations { get; set; }
		public DbSet<Signature> Signatures { get; set; }
		public DbSet<Status> Statuses { get; set; }
	}
}
