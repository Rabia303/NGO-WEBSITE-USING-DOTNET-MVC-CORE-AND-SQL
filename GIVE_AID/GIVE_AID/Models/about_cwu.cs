using System.ComponentModel.DataAnnotations;

namespace GIVE_AID.Models
{
	public class about_cwu
	{
		[Key]
		public int cvuID { get; set; }
		public string name { get; set; }
		public string email { get; set; }
		public string contact { get; set; }
		public string cv { get; set; }
	}
}
