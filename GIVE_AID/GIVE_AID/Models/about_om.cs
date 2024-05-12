using System.ComponentModel.DataAnnotations;

namespace GIVE_AID.Models
{
	public class about_om
	{
		[Key]
		public int omID { get; set; }
		public string desc { get; set; }
		public string img { get; set; }
	}
}
