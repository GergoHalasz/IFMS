using Domain.Entities;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
	public class InterventionDto
	{
		public int Id { get; set; }
		public int ContractId { get; set; }
		public string ContractNumber { get; set; }
		public int SystemTypeId { get; set; }
		public string SystemTypeName { get; set; }
		public int ClientId { get; set; }
		public string ClientName { get; set; }
		public int TechnicianId { get; set; }
		public string TechnicianName { get; set; }
		public int StatusId { get; set; }
		public string StatusName { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? CompletedAt { get; set; }
		public string Notes { get; set; }
		public Geolocation Geolocation { get; set; }
		public List<Signature> Signatures { get; set; }
	}
}
