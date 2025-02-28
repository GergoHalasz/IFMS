using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
	public class InterventionDto
	{
		public int Id { get; set; }

		public int ContractId { get; set; }

		public SystemType SystemType { get; set; }

		public int AssignedClientId { get; set; }

		public InterventionStatus Status { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime? CompletedAt { get; set; }

		public string? Notes { get; set; }
	}
}
