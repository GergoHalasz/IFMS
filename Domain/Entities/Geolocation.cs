using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Geolocation
	{
		public int Id { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }

		public int InterventionId { get; set; }
		public Intervention Intervention { get; set; }
	}

}
