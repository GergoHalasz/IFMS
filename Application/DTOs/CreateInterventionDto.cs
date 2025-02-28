using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
	public class CreateInterventionDto
	{
		public int ContractId { get; set; }
		public SystemType SystemType { get; set; }

		public int AssignedClientId { get; set; }

		public InterventionStatus Status { get; set; }

		public string? Notes { get; set; }
	}
}
