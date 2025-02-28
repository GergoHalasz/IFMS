using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
	public class Client
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(200)]
		public string Name { get; set; }

		[Required]
		[EmailAddress]
		[MaxLength(200)]
		public string Email { get; set; }

		[Phone]
		[MaxLength(15)]
		public string PhoneNumber { get; set; }

		public ICollection<Intervention> Interventions { get; set; } = new List<Intervention>();
	}
}
