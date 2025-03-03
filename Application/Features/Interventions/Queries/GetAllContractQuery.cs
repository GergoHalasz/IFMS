using Application.DTOs;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Interventions.Queries
{
	public class GetAllContractsQuery : IRequest<List<ContractDto>> { }
}
