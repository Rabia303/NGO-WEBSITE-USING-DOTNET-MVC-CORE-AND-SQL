using System.ComponentModel.DataAnnotations;

namespace GIVE_AID.Models
{
	public class about_os
	{
		[Key]
		public int osID { get; set; }
		public string osimg1 { get; set; }
		public string osimg2 { get; set; }
		public string osimg3 { get; set; }
		public string osimg4 { get; set; }
	}
}
