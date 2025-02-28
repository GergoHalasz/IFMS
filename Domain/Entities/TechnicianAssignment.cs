using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
	public class TechnicianAssignment
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int TechnicianId { get; set; }

		public Technician Technician { get; set; }

		[Required]
		public int InterventionId { get; set; }

		public Intervention Intervention { get; set; }

		public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
	}
}
