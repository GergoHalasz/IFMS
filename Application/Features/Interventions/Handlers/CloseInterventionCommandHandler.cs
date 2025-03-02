using Application.Features.Interventions.Commands;
using Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

public class CloseInterventionCommandHandler : IRequestHandler<CloseInterventionCommand, bool>
{
	private readonly IUnitOfWork _unitOfWork;

	public CloseInterventionCommandHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<bool> Handle(CloseInterventionCommand request, CancellationToken cancellationToken)
	{
		await _unitOfWork.Interventions.CloseInterventionAsync(request.Intervention.Id, request.Intervention.Geolocation, request.Intervention.Signatures);
		return true;
	}
}
