﻿using Application.Interfaces;
using Infrastructure.Persistence.DbContexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseNpgsql(connectionString, options => options.MigrationsAssembly("Infrastructure")));

			services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
			services.AddScoped<IInterventionRepository, InterventionRepository>();
			services.AddScoped<IContractRepository, ContractRepository>();

			return services;
		}
	}
}
