using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
	public class Technician
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }

		public ICollection<Intervention> Interventions { get; set; }
	}

}
