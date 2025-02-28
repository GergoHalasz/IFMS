﻿using Domain.Entities;

namespace Application.Interfaces
{
	public interface IInterventionRepository
	{
		Task<Intervention> GetByIdAsync(int id);
		Task<List<Intervention>> GetAllAsync();
		Task AddAsync(Intervention intervention);
		Task UpdateAsync(Intervention intervention);
		Task DeleteAsync(int id);
	}
}
