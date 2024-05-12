using System.ComponentModel.DataAnnotations;

namespace GIVE_AID.Models
{
	public class about_wwd
	{
		[Key]
		public int wwdID { get; set; }
		public string desc { get; set; }
		public string img { get; set; }
	}
}
