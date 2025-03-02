using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Signature
	{
		public int Id { get; set; }
		public string SignedBy { get; set; }  // The person who signed.
		public DateTime SignedAt { get; set; }
		public string SignatureData { get; set; }  // Could be the actual signature image or data.

		public int InterventionId { get; set; }
		public Intervention Intervention { get; set; }
	}

}
