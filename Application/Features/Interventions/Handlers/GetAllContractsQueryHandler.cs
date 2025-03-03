using Application.DTOs;
using Application.Features.Interventions.Queries;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class GetAllContractsQueryHandler : IRequestHandler<GetAllContractsQuery, List<ContractDto>>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public GetAllContractsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<List<ContractDto>> Handle(GetAllContractsQuery request, CancellationToken cancellationToken)
	{
		var contracts = await _unitOfWork.Contracts.GetAllAsync();
		return _mapper.Map<List<ContractDto>>(contracts);
	}
}
