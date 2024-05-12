using System.ComponentModel.DataAnnotations;

namespace GIVE_AID.Models
{
    public class UserReg
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }

        public string UserPass { get; set; }

		public ICollection<donation> donations { get; set; }
		public ICollection<contact> Contacts { get; set; }
		//public ICollection<ourPrograms> Programs { get; set; }
	}
}
