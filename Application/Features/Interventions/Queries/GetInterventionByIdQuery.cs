﻿using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Features.Interventions.Queries
{
	public class GetInterventionByIdQuery : IRequest<InterventionDto>
	{
		public int Id { get; set; }

		public GetInterventionByIdQuery(int id)
		{
			Id = id;
		}
	}
}
