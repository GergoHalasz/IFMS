using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Infrastructure;
using Infrastructure.Persistence.DbContexts;
using Application.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(InterventionMappingProfile));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetInterventionByIdQueryHandler>());

builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo
	{
		Title = "Intervention API",
		Version = "v1",
		Description = "API for managing interventions"
	});
});

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll",
		policy => policy.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AllowAll");
app.UseSwaggerUI(c =>
{
	c.SwaggerEndpoint("/swagger/v1/swagger.json", "Intervention API v1");
	c.RoutePrefix = string.Empty;
});
app.UseSwagger();

if (app.Environment.IsDevelopment())
{
	app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
