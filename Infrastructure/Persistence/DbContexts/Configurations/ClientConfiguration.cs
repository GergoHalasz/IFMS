using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
	public void Configure(EntityTypeBuilder<Client> builder)
	{
		builder.ToTable("Clients");

		builder.HasKey(c => c.Id);

		builder.Property(c => c.Name)
			.IsRequired()
			.HasMaxLength(100);

		builder.HasMany(c => c.Interventions)
			.WithOne(i => i.Client)
			.HasForeignKey(i => i.ClientId);
	}
}
