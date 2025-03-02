using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

public class ContractConfiguration : IEntityTypeConfiguration<Contract>
{
	public void Configure(EntityTypeBuilder<Contract> builder)
	{
		builder.ToTable("Contracts");

		builder.HasKey(c => c.Id);

		builder.Property(c => c.ContractNumber)
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(c => c.StartDate)
			.IsRequired();

		builder.Property(c => c.EndDate)
			.IsRequired();

		builder.HasMany(c => c.Interventions)
			.WithOne(i => i.Contract)
			.HasForeignKey(i => i.ContractId);
	}
}
