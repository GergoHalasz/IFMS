using Application.DTOs;
using Application.Features.Interventions.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Interventions.Handlers
{
	public class UpdateInterventionCommandHandler : IRequestHandler<UpdateInterventionCommand, InterventionDto>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public UpdateInterventionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<InterventionDto> Handle(UpdateInterventionCommand request, CancellationToken cancellationToken)
		{
			var intervention = await _unitOfWork.Interventions.GetByIdAsync(request.Id);
			if (intervention == null) return null;

			intervention.Status = request.Intervention.Status;
			intervention.Notes = request.Intervention.Notes;

			_unitOfWork.Interventions.UpdateAsync(intervention);
			await _unitOfWork.CompleteAsync();

			return _mapper.Map<InterventionDto>(intervention);
		}
	}
}
