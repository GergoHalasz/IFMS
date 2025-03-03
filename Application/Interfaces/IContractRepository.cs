using Domain.Entities;

namespace Application.Interfaces
{
	public interface IContractRepository
	{
		Task<List<Contract>> GetAllAsync();
	}
}