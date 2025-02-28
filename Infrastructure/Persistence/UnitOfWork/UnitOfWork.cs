using Application.Interfaces;
using Infrastructure.Persistence.DbContexts;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;
		private IInterventionRepository _interventionRepository;

		public UnitOfWork(ApplicationDbContext context, IInterventionRepository _repository)
		{
			_context = context;
			_interventionRepository = _repository;
		}

		public IInterventionRepository Interventions =>  _interventionRepository;

		public async Task<int> CompleteAsync()
		{
			return await _context.SaveChangesAsync();
		}
	}
}
