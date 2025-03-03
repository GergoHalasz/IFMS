namespace Application.Interfaces
{
	public interface IUnitOfWork
	{
		IInterventionRepository Interventions { get; }
		IContractRepository Contracts { get; }
		Task<int> CompleteAsync();
	}
}
