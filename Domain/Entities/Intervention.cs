using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace Domain.Entities
{
	public class Intervention
	{
		public int Id { get; set; }
		public int ContractId { get; set; }
		public Contract Contract { get; set; }

		public int SystemTypeId { get; set; }
		public SystemType SystemType { get; set; }

		public int ClientId { get; set; }
		public Client Client { get; set; }

		public int TechnicianId { get; set; }
		public Technician Technician { get; set; }

		public int StatusId { get; set; }
		public Status Status { get; set; }

		public Geolocation Geolocation { get; set; }
		public ICollection<Signature> Signatures { get; set; }

		public DateTime CreatedAt { get; set; }
		public DateTime? CompletedAt { get; set; }

		public string Notes { get; set; }  // For additional notes or comments.
	}
}
