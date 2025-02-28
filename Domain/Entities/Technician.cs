using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
	public class Technician
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(200)]
		public string Name { get; set; }

		[MaxLength(500)]
		public string SkillSet { get; set; }

		public ICollection<TechnicianAssignment> Assignments { get; set; } = new List<TechnicianAssignment>();
	}
}
