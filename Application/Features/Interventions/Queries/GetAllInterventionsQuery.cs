using Application.DTOs;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Interventions.Queries
{
	public class GetAllInterventionsQuery : IRequest<List<InterventionDto>> { }
}
