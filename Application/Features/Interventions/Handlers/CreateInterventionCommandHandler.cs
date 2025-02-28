using Domain.Entities;
using Domain.Enums;
using MediatR;
using Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Interventions.Commands;

namespace Application.Features.Interventions.Handlers
{
	public class CreateInterventionCommandHandler : IRequestHandler<CreateInterventionCommand, int>
	{
		private readonly IUnitOfWork _unitOfWork;

		public CreateInterventionCommandHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<int> Handle(CreateInterventionCommand request, CancellationToken cancellationToken)
		{
			var intervention = new Intervention
			{
				ContractId = request.Intervention.ContractId,
				SystemType = (SystemType)request.Intervention.SystemType, // Convert int to SystemType enum
				AssignedClientId = request.Intervention.AssignedClientId,
				Status = InterventionStatus.Pending, // Set default status (or from request if needed)
				Notes = request.Intervention.Notes
			};


			await _unitOfWork.Interventions.AddAsync(intervention); 
			await _unitOfWork.CompleteAsync();

			return intervention.Id;
		}
	}
}
