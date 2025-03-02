﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Contract
	{
		public int Id { get; set; }
		public string ContractNumber { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }

		public ICollection<Intervention> Interventions { get; set; }
	}

}
