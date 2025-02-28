// APPLICATION/FEATURES/Interventions/Handlers/DeleteInterventionCommandHandler.cs
using Application.Features.Interventions.Commands;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Interventions.Handlers
{
	public class DeleteInterventionCommandHandler : IRequestHandler<DeleteInterventionCommand, bool>
	{
		private readonly IUnitOfWork _unitOfWork;

		public DeleteInterventionCommandHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<bool> Handle(DeleteInterventionCommand request, CancellationToken cancellationToken)
		{
			var intervention = await _unitOfWork.Interventions.GetByIdAsync(request.Id);
			if (intervention == null) return false;

			_unitOfWork.Interventions.DeleteAsync(intervention.Id);
			await _unitOfWork.CompleteAsync();

			return true;
		}
	}
}
