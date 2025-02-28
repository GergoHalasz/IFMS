using Domain.Entities;
using Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories
{
	public class InterventionRepository : IInterventionRepository
	{
		private readonly ApplicationDbContext _context;

		public InterventionRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Intervention> GetByIdAsync(int id)
		{
			return await _context.Interventions
								 .Include(i => i.AssignedClient)
								 .Include(i => i.TechnicianAssignments)
								 .FirstOrDefaultAsync(i => i.Id == id);
		}

		public async Task<List<Intervention>> GetAllAsync()
		{
			return await _context.Interventions
								 .Include(i => i.AssignedClient)
								 .Include(i => i.TechnicianAssignments)
								 .ToListAsync();
		}

		public async Task AddAsync(Intervention intervention)
		{
			await _context.Interventions.AddAsync(intervention);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(Intervention intervention)
		{
			_context.Interventions.Update(intervention);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var intervention = await GetByIdAsync(id);
			if (intervention != null)
			{
				_context.Interventions.Remove(intervention);
				await _context.SaveChangesAsync();
			}
		}
	}
}
