
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeresNL.Core.Models
{
	public class mUsers
	{
		public int idUsers { get; set; }
		public string name { get; set; }
		public string email { get; set; }
		public string phone { get; set; }
		public int? idRol { get; set; }
		public string password { get; set; }
		public byte[]? photo { get; set; }
		public bool? isActive { get; set; }
		public DateTime? registrationDate { get; set; }
	}
}