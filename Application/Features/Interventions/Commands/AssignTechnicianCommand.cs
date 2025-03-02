using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Interventions.Commands
{
	public class AssignTechnicianCommand : IRequest<bool>
	{
		public int InterventionId { get; set; }
		public int TechnicianId { get; set; }
	}
}
