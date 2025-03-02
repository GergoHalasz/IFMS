using Application.DTOs;
using Application.Features.Interventions.Queries;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

public class GetInterventionByIdQueryHandler : IRequestHandler<GetInterventionByIdQuery, InterventionDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

	public GetInterventionByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

    public async Task<InterventionDto> Handle(GetInterventionByIdQuery request, CancellationToken cancellationToken)
    {
        var intervention = await _unitOfWork.Interventions.GetByIdAsync(request.Id); 
		return _mapper.Map<InterventionDto>(intervention);
	}
}
