using Application.Features.Interventions.Commands;
using Application.Features.Interventions.Queries;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers
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
		public async Task<IActionResult> Create([FromBody] CreateInterventionCommand command)
		{
			if (command == null)
				return BadRequest("Invalid intervention data.");

			var interventionId = await _mediator.Send(command);

			return CreatedAtAction(nameof(GetById), new { id = interventionId }, command);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] UpdateInterventionCommand command)
		{
			command.Id = id;

			var query = new GetInterventionByIdQuery(id);
			var intervention = await _mediator.Send(query);

			if (intervention == null)
				return NotFound();

			await _mediator.Send(command);
			return NoContent();
		}

		[HttpPut("{id}/close")]
		public async Task<IActionResult> Close(int id, [FromBody] CloseInterventionCommand command)
		{
			if (id != command.Intervention.Id)
				return BadRequest("ID mismatch.");

			var query = new GetInterventionByIdQuery(id);
			var intervention = await _mediator.Send(query);

			if (intervention == null)
				return NotFound();

			await _mediator.Send(command);
			return NoContent();
		}

		[HttpPut("{id}/assign")]
		public async Task<IActionResult> AssignTechnician(int id, [FromBody] AssignTechnicianCommand command)
		{
			if (id != command.InterventionId)
				return BadRequest("ID mismatch.");

			var query = new GetInterventionByIdQuery(id);
			var intervention = await _mediator.Send(query);

			if (intervention == null)
				return NotFound();

			await _mediator.Send(command);
			return NoContent();
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var query = new GetInterventionByIdQuery(id);
			var intervention = await _mediator.Send(query);

			if (intervention == null)
				return NotFound();

			return Ok(intervention);
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var query = new GetAllInterventionsQuery();
			var interventions = await _mediator.Send(query);

			return Ok(interventions);
		}
	}
}
