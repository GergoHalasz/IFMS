using Application.DTOs;
using MediatR;

namespace Application.Features.Interventions.Commands
{
	public class CreateInterventionCommand : IRequest<int>
	{
		public CreateInterventionDto Intervention { get; set; }

		public CreateInterventionCommand(CreateInterventionDto intervention)
		{
			Intervention = intervention;
		}
	}
}
