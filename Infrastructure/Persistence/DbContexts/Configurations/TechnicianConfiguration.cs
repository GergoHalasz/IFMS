using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

public class TechnicianConfiguration : IEntityTypeConfiguration<Technician>
{
	public void Configure(EntityTypeBuilder<Technician> builder)
	{
		builder.ToTable("Technicians");

		builder.HasKey(t => t.Id);

		builder.Property(t => t.Name)
			.IsRequired()
			.HasMaxLength(50);

		builder.Property(t => t.Email)
			.IsRequired()
			.HasMaxLength(100);

		builder.HasMany(t => t.Interventions)
			.WithOne(i => i.Technician)
			.HasForeignKey(i => i.TechnicianId)
			.OnDelete(DeleteBehavior.SetNull);
	}
}
