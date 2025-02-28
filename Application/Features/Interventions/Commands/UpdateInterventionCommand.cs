// APPLICATION/FEATURES/Interventions/Commands/UpdateInterventionCommand.cs
using Application.DTOs;
using MediatR;

namespace Application.Features.Interventions.Commands
{
	public class UpdateInterventionCommand : IRequest<InterventionDto> 
	{
		public int Id { get; set; }
		public UpdateInterventionDto Intervention { get; set; }

		public UpdateInterventionCommand(int id, UpdateInterventionDto intervention)
		{
			Id = id;
			Intervention = intervention;
		}
	}
}
