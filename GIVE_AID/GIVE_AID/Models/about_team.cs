using System.ComponentModel.DataAnnotations;

namespace GIVE_AID.Models
{
	public class about_team
	{
		[Key]
		public int atID { get; set; }
		public string designation { get; set; }
		public string name { get; set; }
		public string img { get; set; }
	}
}
