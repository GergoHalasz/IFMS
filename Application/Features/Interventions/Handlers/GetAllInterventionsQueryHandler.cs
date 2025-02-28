using Application.DTOs;
using Application.Features.Interventions.Queries;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Interventions.Handlers
{
	public class GetAllInterventionsQueryHandler : IRequestHandler<GetAllInterventionsQuery, List<InterventionDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetAllInterventionsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<List<InterventionDto>> Handle(GetAllInterventionsQuery request, CancellationToken cancellationToken)
		{
			var interventions = await _unitOfWork.Interventions.GetAllAsync();
			return _mapper.Map<List<InterventionDto>>(interventions);
		}
	}
}
