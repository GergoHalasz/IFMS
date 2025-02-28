using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
	public class Intervention
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int ContractId { get; set; }

		[Required]
		public SystemType SystemType { get; set; }

		[Required]
		public int AssignedClientId { get; set; }

		[Required]
		public InterventionStatus Status { get; set; }

		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

		public DateTime? CompletedAt { get; set; }

		[MaxLength(500)]
		public string Notes { get; set; }

		public Client AssignedClient { get; set; }
		public ICollection<TechnicianAssignment> TechnicianAssignments { get; set; } = new List<TechnicianAssignment>();
	}
}
