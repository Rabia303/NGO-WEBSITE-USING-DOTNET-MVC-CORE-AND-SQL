using System.ComponentModel.DataAnnotations;

namespace GIVE_AID.Models
{
	public class AddDonation
	{
		[Key]
        public int donationId { get; set; }
		//public string amount { get; set; }
		public string cause { get; set; }
        public ICollection<donation>  donations { get; set; }

    }
}
