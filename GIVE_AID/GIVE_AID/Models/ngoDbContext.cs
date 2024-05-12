using Microsoft.EntityFrameworkCore;

namespace GIVE_AID.Models
{
    public class ngoDbContext : DbContext
    {
        public ngoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<contact> Contact { get; set; }

        public DbSet<AddDonation> AddDonation { get; set; }
        public DbSet<donation> Donation { get; set; }
        public DbSet<team> teams { get; set; }
        public DbSet<Gallery> Gallery { get; set; }
        public DbSet<listofNGO> ListOfNGO { get; set; }
        public DbSet<ourPrograms> OurPrograms { get; set; }
        public DbSet<about_cwu> About_Career_with_us { get; set; }
        public DbSet<about_om> ABout_Our_Mission { get; set; }
        public DbSet<about_team> About_team { get; set; }
        public DbSet<about_wwd> About_what_we_do { get; set; }
        public DbSet<about_os> About_Our_Supporters { get; set; }
        public DbSet<HelpCentre> HelpCentre { get; set; }
		public DbSet<UserReg> User_Reg { get; set; }
		public DbSet<admin_register> Admin_Register { get; set; }

    }
}
