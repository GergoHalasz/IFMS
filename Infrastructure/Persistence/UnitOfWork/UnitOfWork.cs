using Application.Interfaces;
using Infrastructure.Persistence.DbContexts;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;
		private IInterventionRepository _interventionRepository;
		private IContractRepository _contractRepository;

		public UnitOfWork(ApplicationDbContext context, IInterventionRepository _interventionRepository, IContractRepository _contractRepository)
		{
			_context = context;
			this._interventionRepository = _interventionRepository;
			this._contractRepository = _contractRepository;
		}

		public IInterventionRepository Interventions =>  _interventionRepository;
		public IContractRepository Contracts => _contractRepository;

		public async Task<int> CompleteAsync()
		{
			return await _context.SaveChangesAsync();
		}
	}
}
