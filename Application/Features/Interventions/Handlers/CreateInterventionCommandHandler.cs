using Application.Features.Interventions.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

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
            SystemTypeId = request.Intervention.SystemTypeId,
            ClientId = request.Intervention.ClientId,
            TechnicianId = request.Intervention.TechnicianId,
            StatusId = request.Intervention.StatusId,
            Notes = request.Intervention.Notes,
            CreatedAt = DateTime.UtcNow
        };

        await _unitOfWork.Interventions.AddAsync(intervention);
        return intervention.Id;
    }
}
