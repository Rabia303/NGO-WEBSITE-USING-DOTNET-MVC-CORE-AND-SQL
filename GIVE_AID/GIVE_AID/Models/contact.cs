using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GIVE_AID.Models
{
	public class contact
	{
		[Key]
        public int contactId { get; set; }
		public string name { get; set; }
		public string email { get; set; }
		public string phone { get; set; }
		public string message { get; set; }
		public int UserId { get; set; }

		[ForeignKey("UserId")]
		public UserReg UserReg { get; set; }


	}
}
