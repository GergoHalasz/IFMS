using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
	public class CloseInterventionDto
	{
		public int Id { get; set; }
		public Geolocation Geolocation { get; set; }
		public List<Signature> Signatures { get; set; }
	}
}
