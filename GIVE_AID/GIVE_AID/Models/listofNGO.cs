using System.ComponentModel.DataAnnotations;

namespace GIVE_AID.Models
{
    public class listofNGO
    {
        [Key]
        public int id { get; set; }
        public string nameofNGO { get; set; }
        public string desc { get; set; }
        public string logo_img { get; set; }
    }
}
