using System.ComponentModel.DataAnnotations;

namespace GIVE_AID.Models
{
    public class HelpCentre
    {

        [Key]
        public int id { get; set; }
        public string category { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
        public string image { get; set; }
    }
}
