using Application.Features.Interventions.Commands;
using Application.Interfaces;
using AutoMapper;
using MediatR;

public class UpdateInterventionCommandHandler : IRequestHandler<UpdateInterventionCommand, bool>
{
	private readonly IUnitOfWork _unitOfWork;

	public UpdateInterventionCommandHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	
	public async Task<bool> Handle(UpdateInterventionCommand request, CancellationToken cancellationToken)
	{
		var intervention = await _unitOfWork.Interventions.GetByIdAsync(request.Id);
		if (intervention == null) return false;

		intervention.Notes = request.Intervention.Notes;
		intervention.TechnicianId = request.Intervention.TechnicianId;

		await _unitOfWork.Interventions.UpdateAsync(intervention);
		return true;
	}
}
