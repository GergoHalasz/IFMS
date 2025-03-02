using Application.DTOs;
using MediatR;

namespace Application.Features.Interventions.Commands
{
	public class CloseInterventionCommand : IRequest<bool>
	{
		public CloseInterventionDto Intervention { get; set; }

		public CloseInterventionCommand(CloseInterventionDto intervention)
		{
			Intervention = intervention;
		}
	}
}
