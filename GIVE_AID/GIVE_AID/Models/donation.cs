using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GIVE_AID.Models
{
	public class donation
	{
		[Key]
        public int donatorId { get; set; }
		public string amount { get; set; }
		//public string cause { get; set; }
		public string name { get; set; }
		public string email { get; set; }
		public string contact { get; set; }

		public int? donationId { get; set; }

		[ForeignKey("donationId")]
		public AddDonation AddDonation { get; set; }

		public int? UserId { get; set; }

		[ForeignKey("UserId")]
		public UserReg UserReg { get; set; }
	}
}
