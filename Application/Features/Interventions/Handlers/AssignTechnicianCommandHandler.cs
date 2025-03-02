using Application.Features.Interventions.Commands;
using Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

public class AssignTechnicianCommandHandler : IRequestHandler<AssignTechnicianCommand, bool>
{
	private readonly IUnitOfWork _unitOfWork;

	public AssignTechnicianCommandHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<bool> Handle(AssignTechnicianCommand request, CancellationToken cancellationToken)
	{
		await _unitOfWork.Interventions.AssignToTechnicianAsync(request.InterventionId, request.TechnicianId);
		return true;
	}
}
