using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GIVE_AID.Models
{
	public class ourPrograms
	{
		[Key]
		public int opID { get; set; }
		public string opHeading { get; set; }
		public string opDesc { get; set; }

		public string img { get; set; }
		//public int UserId { get; set; }

		//[ForeignKey("UserId")]
		//public UserReg UserReg { get; set; }
	}
}
