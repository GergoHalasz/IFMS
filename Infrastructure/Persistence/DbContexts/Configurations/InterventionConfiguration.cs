using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

public class InterventionConfiguration : IEntityTypeConfiguration<Intervention>
{
	public void Configure(EntityTypeBuilder<Intervention> builder)
	{
		builder.ToTable("Interventions");

		builder.HasKey(i => i.Id);

		builder.HasOne(i => i.Contract)
			.WithMany(c => c.Interventions)
			.HasForeignKey(i => i.ContractId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(i => i.Technician)
			.WithMany(t => t.Interventions)
			.HasForeignKey(i => i.TechnicianId)
			.OnDelete(DeleteBehavior.SetNull);

		builder.HasOne(i => i.Status)
			.WithMany(t => t.Interventions)
			.HasForeignKey(i => i.StatusId);

		builder.Property(i => i.CreatedAt)
			.IsRequired();
	}
}
