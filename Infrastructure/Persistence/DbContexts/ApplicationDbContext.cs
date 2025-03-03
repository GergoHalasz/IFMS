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

			modelBuilder.Entity<Client>().HasData(
				new Client { Id = 1, Name = "Client 1" },
				new Client { Id = 2, Name = "Client 2" },
				new Client { Id = 3, Name = "Client 3" }
			);

			modelBuilder.Entity<Contract>().HasData(
				new Contract { Id = 1, ContractNumber = "C-001", StartDate = DateTime.Now, EndDate = DateTime.Now.AddYears(1) },
				new Contract { Id = 2, ContractNumber = "C-002", StartDate = DateTime.Now, EndDate = DateTime.Now.AddYears(2) },
				new Contract { Id = 3, ContractNumber = "C-003", StartDate = DateTime.Now, EndDate = DateTime.Now.AddYears(3) }
			);

			modelBuilder.Entity<Geolocation>().HasData(
				new Geolocation { Id = 1, Latitude = 34.0522, Longitude = -118.2437, InterventionId = 1 },
				new Geolocation { Id = 2, Latitude = 40.7128, Longitude = -74.0060, InterventionId = 2 },
				new Geolocation { Id = 3, Latitude = 51.5074, Longitude = -0.1278, InterventionId = 3 }
			);

			modelBuilder.Entity<SystemType>().HasData(
				new SystemType { Id = 1, Name = "System Type 1" },
				new SystemType { Id = 2, Name = "System Type 2" },
				new SystemType { Id = 3, Name = "System Type 3" }
			);

			modelBuilder.Entity<Technician>().HasData(
				new Technician { Id = 1, Name = "Technician 1", Email = "tech1@domain.com" },
				new Technician { Id = 2, Name = "Technician 2", Email = "tech2@domain.com" },
				new Technician { Id = 3, Name = "Technician 3", Email = "tech3@domain.com" }
			);

			modelBuilder.Entity<Status>().HasData(
				new Status { Id = 1, StatusName = "Status 1" },
				new Status { Id = 2, StatusName = "Status 2" },
				new Status { Id = 3, StatusName = "Status 3" }
			);

			modelBuilder.Entity<Intervention>().HasData(
				new Intervention { Id = 1, ContractId = 1, SystemTypeId = 1, ClientId = 1, TechnicianId = 1, StatusId = 1, CreatedAt = DateTime.Now, Notes = "Intervention 1" },
				new Intervention { Id = 2, ContractId = 2, SystemTypeId = 2, ClientId = 2, TechnicianId = 2, StatusId = 2, CreatedAt = DateTime.Now, Notes = "Intervention 2" },
				new Intervention { Id = 3, ContractId = 3, SystemTypeId = 3, ClientId = 3, TechnicianId = 3, StatusId = 3, CreatedAt = DateTime.Now, Notes = "Intervention 3" }
			);

			modelBuilder.Entity<Signature>().HasData(
				new Signature { Id = 1, SignedBy = "Signer 1", SignedAt = DateTime.Now, SignatureData = "data1", InterventionId = 1 },
				new Signature { Id = 2, SignedBy = "Signer 2", SignedAt = DateTime.Now, SignatureData = "data2", InterventionId = 2 },
				new Signature { Id = 3, SignedBy = "Signer 3", SignedAt = DateTime.Now, SignatureData = "data3", InterventionId = 3 }
			);

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
