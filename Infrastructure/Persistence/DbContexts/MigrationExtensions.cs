using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence.DbContexts
{
	public static class MigrationExtensions
	{
		public static void ApplyMigrations(this IApplicationBuilder app)
		{
			using var scope = app.ApplicationServices.CreateScope();
			var services = scope.ServiceProvider;
			var logger = services.GetRequiredService<ILogger<IApplicationBuilder>>();

			try
			{
				var dbContext = services.GetRequiredService<ApplicationDbContext>();
				logger.LogInformation("Applying database migrations...");
				dbContext.Database.Migrate();
				logger.LogInformation("Database migrations applied successfully.");
			}
			catch (Exception ex)
			{
				logger.LogError(ex, "An error occurred while applying database migrations.");
			}
		}
	}
}
