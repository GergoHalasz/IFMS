using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
	public class CreateInterventionDto
	{
		public int ContractId { get; set; }
		public int SystemTypeId { get; set; }
		public int ClientId { get; set; }
		public int TechnicianId { get; set; }
		public int StatusId { get; set; }
		public string Notes { get; set; }
	}
}
