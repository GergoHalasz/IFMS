using MediatR;

namespace Application.Features.Interventions.Commands
{
	public class DeleteInterventionCommand : IRequest<bool> 
	{
		public int Id { get; set; }

		public DeleteInterventionCommand(int id)
		{
			Id = id;
		}
	}
}
