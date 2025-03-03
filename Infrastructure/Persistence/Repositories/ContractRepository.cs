using Domain.Entities;
using Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Domain.Enums;

namespace Infrastructure.Repositories
{
	public class ContractRepository : IContractRepository
	{
		private readonly ApplicationDbContext _context;

		public ContractRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<List<Contract>> GetAllAsync()
		{
			return await _context.Contracts
								 .ToListAsync();
		}
	}
}
