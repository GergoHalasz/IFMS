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
	options.AddPolicy("AllowReactApp",
		policy =>
		{
			policy.WithOrigins("http://localhost:3000")
				  .AllowAnyMethod()
				  .AllowAnyHeader();
		});
	options.AddPolicy("AllowWebAPI",
		policy =>
		{
			policy.WithOrigins("https://localhost:5011")
				  .AllowAnyMethod()
				  .AllowAnyHeader();
		});
	options.AddPolicy("AllowLocalReact",
		policy =>
		{
			policy.WithOrigins("http://localhost:53140")
				  .AllowAnyMethod()
				  .AllowAnyHeader();
		});
});

var app = builder.Build();

app.UseCors("AllowReactApp");
app.UseCors("AllowWebAPI");
app.UseCors("AllowLocalReact");

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
