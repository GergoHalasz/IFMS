using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

public class SystemTypeConfiguration : IEntityTypeConfiguration<SystemType>
{
	public void Configure(EntityTypeBuilder<SystemType> builder)
	{
		builder.ToTable("SystemTypes");

		builder.HasKey(s => s.Id);

		builder.Property(s => s.Name)
			.IsRequired()
			.HasMaxLength(100);

		builder.HasMany(s => s.Interventions)
			.WithOne(i => i.SystemType)
			.HasForeignKey(i => i.SystemTypeId);
	}
}
