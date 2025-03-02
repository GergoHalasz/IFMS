using Domain.Entities;
using Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Domain.Enums;

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
								 .Include(i => i.Contract)
								 .Include(i => i.SystemType)
								 .Include(i => i.Client)
								 .Include(i => i.Technician)
								 .Include(i => i.Status)
								 .Include(i => i.Geolocation)
								 .Include(i => i.Signatures)
								 .FirstOrDefaultAsync(i => i.Id == id);
		}

		public async Task<List<Intervention>> GetAllAsync()
		{
			return await _context.Interventions
								 .Include(i => i.Contract)
								 .Include(i => i.SystemType)
								 .Include(i => i.Client)
								 .Include(i => i.Technician)
								 .Include(i => i.Status)
								 .Include(i => i.Geolocation)
								 .Include(i => i.Signatures)
								 .ToListAsync();
		}

		public async Task AddAsync(Intervention intervention)
		{
			if (intervention == null)
				throw new ArgumentNullException(nameof(intervention));

			intervention.CreatedAt = DateTime.UtcNow; 

			await _context.Interventions.AddAsync(intervention);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(Intervention intervention)
		{
			if (intervention == null)
				throw new ArgumentNullException(nameof(intervention));

			_context.Interventions.Update(intervention);
			await _context.SaveChangesAsync();
		}

		public async Task CloseInterventionAsync(int interventionId, Geolocation geolocation, List<Signature> signatures)
		{
			var intervention = await GetByIdAsync(interventionId);
			if (intervention == null)
				throw new InvalidOperationException("Intervention not found.");

			if (intervention.Status.StatusName == "Completed")
				throw new InvalidOperationException("Intervention is already completed.");

			if (geolocation == null)
				throw new InvalidOperationException("Geolocation is required to close the intervention.");

			if (signatures == null || signatures.Count == 0)
				throw new InvalidOperationException("At least one signature is required to close the intervention.");

			intervention.Geolocation = geolocation;
			intervention.Signatures = signatures;
			intervention.CompletedAt = DateTime.UtcNow;
			intervention.StatusId = '1';

			_context.Interventions.Update(intervention);
			await _context.SaveChangesAsync();
		}

		public async Task AssignToTechnicianAsync(int interventionId, int technicianId)
		{
			var intervention = await GetByIdAsync(interventionId);
			if (intervention == null)
				throw new InvalidOperationException("Intervention not found.");

			var technician = await _context.Technicians.FindAsync(technicianId);
			if (technician == null)
				throw new InvalidOperationException("Technician not found.");

			intervention.TechnicianId = technicianId;

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
