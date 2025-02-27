using MediatR;
using Application.Features.Interventions.Commands;
using Application.Features.Interventions.Queries;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class InterventionController : ControllerBase
	{
		private readonly IMediator _mediator;

		public InterventionController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> CreateIntervention([FromBody] CreateInterventionDto interventionDto)
		{
			var command = new CreateInterventionCommand(interventionDto);
			var interventionId = await _mediator.Send(command);
			return CreatedAtAction(nameof(GetInterventionById), new { id = interventionId }, interventionId);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllInterventions()
		{
			return Ok();  
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetInterventionById(int id)
		{
			var query = new GetInterventionByIdQuery(id);
			var intervention = await _mediator.Send(query);
			if (intervention == null) return NotFound();
			return Ok(intervention);
		}
	}
}
