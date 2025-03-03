using Application.Features.Interventions.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IFMS.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContractController : Controller
	{
		private readonly IMediator _mediator;

		public ContractController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var query = new GetAllContractsQuery();
			var contracts = await _mediator.Send(query);

			return Ok(contracts);
		}
	}
}
