namespace Application.Interfaces
{
	public interface IUnitOfWork
	{
		IInterventionRepository Interventions { get; }
		Task<int> CompleteAsync();
	}
}
