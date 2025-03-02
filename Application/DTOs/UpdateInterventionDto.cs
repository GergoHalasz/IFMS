using Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
	public class UpdateInterventionDto
	{
		public string Notes { get; set; }
		public int TechnicianId { get; set; }
		public DateTime? RescheduledDate { get; set; }
	}
}
