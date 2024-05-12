using GIVE_AID.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace GIVE_AID.Controllers
{
	public class AdminController : Controller
	{
		public readonly ngoDbContext db;

		public AdminController(ngoDbContext db)
		{
			this.db = db;
		}

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult About_Insert()
		{
			return View();
		}
        public IActionResult Admin_DonationList()
        {

            return View(db.Donation.ToList());
        }
     

        public IActionResult AboutInsert()
		{
			var cwu = db.About_Career_with_us.ToList();
			var om = db.ABout_Our_Mission.ToList();
			var os = db.About_Our_Supporters.ToList();
			var team = db.About_team.ToList();
			var wwd = db.About_what_we_do.ToList();
			about1 ab = new about1()
			{
				aboutcwu = cwu,
				aboutom = om,
				aboutos = os,
				aboutteam = team,
				aboutwwd = wwd,
			};

			return View(ab);
		}

        public IActionResult whatwedo()
        {
            return View();
        }

        [HttpPost]
		public IActionResult whatwedo(about_wwd add, IFormFile img11)
		{
			var ext = new[] { "png", "jpg", "jpeg" };

			if (img11 != null && img11.Length > 0)
			{
				var fe = System.IO.Path.GetExtension(img11.FileName).Substring(1);
				if (!ext.Contains(fe))
				{
					ViewBag.e = "Choose png jpg jpeg Type only";
					return View("About_Insert");
				}
				var rn = Path.GetFileName(img11.FileName);
				//Random rand = new Random();
				//var filename = rand.Next(1, 50) + rn;
				var filename = Guid.NewGuid() + rn;
				string imgFolder = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/aboutimg");
				if (!Directory.Exists(imgFolder))
				{
					Directory.CreateDirectory(imgFolder);
				}
				string filePath = Path.Combine(imgFolder, filename);
				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					img11.CopyTo(stream);
				}
				var dbAddress = Path.Combine("aboutimg", filename);
				add.img = dbAddress;
				db.About_what_we_do.Add(add);
				db.SaveChanges();
				return RedirectToAction("Index");

			}
			return View();
		}
        public IActionResult fetchwwd()
        {
            return View(db.About_what_we_do.ToList());
        }
        public IActionResult editwwd(int wwdID)
        {
            var id = db.About_what_we_do.Find(wwdID);
            return View(id);
        }
		[HttpPost]
        public IActionResult editwwd(about_wwd abcd, IFormFile img)
        {
            if (img != null && img.Length > 0)
            {
                var filename = Path.GetFileName(img.FileName);
                string imgFolder = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/aboutimg");
                if (!Directory.Exists(imgFolder))
                {
                    Directory.CreateDirectory(imgFolder);
                }
                string filePath = Path.Combine(imgFolder, filename);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    img.CopyTo(stream);
                }
                var dbAddress = Path.Combine("aboutimg", filename);
                abcd.img = dbAddress;
                db.About_what_we_do.Update(abcd);
                db.SaveChanges();
                return RedirectToAction("fetchwwd");
            }
            return View();
        }
        public IActionResult deletewwd(int wwdID)
        {
            var id = db.About_what_we_do.Find(wwdID);
            db.About_what_we_do.Remove(id);
            db.SaveChanges();
            return RedirectToAction("fetchwwd");
        }
        public IActionResult fetchmission()
        {
            return View(db.ABout_Our_Mission.ToList());
        }
        public IActionResult editmission(int omID)
        {
            var id = db.ABout_Our_Mission.Find(omID);
            return View(id);
        }
		[HttpPost]
        public IActionResult editmission(about_om abcd, IFormFile img)
        {
            if (img != null && img.Length > 0)
            {
                var filename = Path.GetFileName(img.FileName);
                string imgFolder = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/aboutimg");
                if (!Directory.Exists(imgFolder))
                {
                    Directory.CreateDirectory(imgFolder);
                }
                string filePath = Path.Combine(imgFolder, filename);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    img.CopyTo(stream);
                }
                var dbAddress = Path.Combine("aboutimg", filename);
                abcd.img = dbAddress;
                db.ABout_Our_Mission.Update(abcd);
                db.SaveChanges();
                return RedirectToAction("fetchmission");
            }
            return View();
        }

    

        public IActionResult deletemission(int omID)
        {
            var id = db.ABout_Our_Mission.Find(omID);
            db.ABout_Our_Mission.Remove(id);
            db.SaveChanges();
            return RedirectToAction("fetchmission");
        }
        public IActionResult Ourmission()
        {
            return View();
        }

        [HttpPost]
		public IActionResult Ourmission(about_om add1, IFormFile img)
		{
			var ext = new[] { "png", "jpg", "jpeg" };

			if (img != null && img.Length > 0)
			{
				var fe = System.IO.Path.GetExtension(img.FileName).Substring(1);
				if (!ext.Contains(fe))
				{
					ViewBag.e = "Choose png jpg jpeg Type only";
					return View();
				}
				var rn = Path.GetFileName(img.FileName);
				//Random rand = new Random();
				//var filename = rand.Next(1, 50) + rn;
				var filename = Guid.NewGuid() + rn;
				string imgFolder = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/aboutimages1");
				if (!Directory.Exists(imgFolder))
				{
					Directory.CreateDirectory(imgFolder);
				}
				string filePath = Path.Combine(imgFolder, filename);
				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					img.CopyTo(stream);
				}
				var dbAddress = Path.Combine("aboutimages1", filename);
				add1.img = dbAddress;
				db.ABout_Our_Mission.Add(add1);
				db.SaveChanges();
				return RedirectToAction("index");

			}
			return View();
		}
        public IActionResult fetchgallery()
        {
            return View(db.Gallery.ToList());
        }
        public IActionResult editgallery(int imgId)
        {
            var id = db.Gallery.Find(imgId);
            return View(id);
        }
        [HttpPost]
        public IActionResult editgallery(Gallery abcd, IFormFile img)
        {
            if (img != null && img.Length > 0)
            {
                var filename = Path.GetFileName(img.FileName);
                string imgFolder = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/ngoimage");
                if (!Directory.Exists(imgFolder))
                {
                    Directory.CreateDirectory(imgFolder);
                }
                string filePath = Path.Combine(imgFolder, filename);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    img.CopyTo(stream);
                }
                var dbAddress = Path.Combine("ngoimage", filename);
                abcd.img = dbAddress;
                db.Gallery.Update(abcd);
                db.SaveChanges();
                return RedirectToAction("fetchgallery");
            }
            return View();
        }

     
        public IActionResult deletegallery(int imgId)
        {
            var id = db.Gallery.Find(imgId);
            db.Gallery.Remove(id);
            db.SaveChanges();
            return RedirectToAction("fetchgallery");
        }
        public IActionResult edit_helpcenter(int id)
        {
            var id1 = db.HelpCentre.Find(id);
            return View(id1);
        }
        [HttpPost]
        public IActionResult edit_helpcenter(HelpCentre abcd, IFormFile img)
        {
            if (img != null && img.Length > 0)
            {
                var filename = Path.GetFileName(img.FileName);
                string imgFolder = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/ngoimage");
                if (!Directory.Exists(imgFolder))
                {
                    Directory.CreateDirectory(imgFolder);
                }
                string filePath = Path.Combine(imgFolder, filename);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    img.CopyTo(stream);
                }
                var dbAddress = Path.Combine("ngoimage", filename);
                abcd.image = dbAddress;
                db.HelpCentre.Update(abcd);
                db.SaveChanges();
                return RedirectToAction("fetch_help");
            }
            return View();
        }
        public IActionResult fetch_help()
        {
            return View(db.HelpCentre.ToList());
        }
        public IActionResult delete_help(int image)
        {
            var find = db.Gallery.Find(image);
            db.Gallery.Remove(find);
            db.SaveChanges();
            return RedirectToAction("fetch_help");
   
        }
        public IActionResult edit_programmes(int opid)
        {
            var id = db.OurPrograms.Find(opid);
            return View(id);
        }
        [HttpPost]
        public IActionResult edit_programmes(ourPrograms abcd, IFormFile img)
        {
            if (img != null && img.Length > 0)
            {
                var filename = Path.GetFileName(img.FileName);
                string imgFolder = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/ngoimage");
                if (!Directory.Exists(imgFolder))
                {
                    Directory.CreateDirectory(imgFolder);
                }
                string filePath = Path.Combine(imgFolder, filename);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    img.CopyTo(stream);
                }
                var dbAddress = Path.Combine("ngoimage", filename);
                abcd.img = dbAddress;
                db.OurPrograms.Update(abcd);
                db.SaveChanges();
                return RedirectToAction("fetchprogrammes");
            }
            return View();
        }
      
     
        public IActionResult fetchprogrammes()
        {
            return View(db.OurPrograms.ToList());
        }
        public IActionResult delete_programmes(int opID)
        {
            var find = db.OurPrograms.Find(opID);
            db.OurPrograms.Remove(find);
            db.SaveChanges();
            return RedirectToAction("fetchprogrammes");
        }
            public IActionResult cause_list()
        {
            return View(db.AddDonation.ToList());
        }
        public IActionResult ourSupporters()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ourSupporters(about_os model, IFormFile imga, IFormFile imgb, IFormFile imgc, IFormFile imgd)
        {
            var ext = new[] { "png", "jpg", "jpeg" };

            // Check if all four images are provided and are of valid types
            if (imga != null && imgb != null && imgc != null && imgd != null &&
                imga.Length > 0 && imgb.Length > 0 && imgc.Length > 0 && imgd.Length > 0)
            {
                // Check each image for valid file type
                foreach (var img in new[] { imga, imgb, imgc, imgd })
                {
                    var fe = Path.GetExtension(img.FileName).Substring(1);
                    if (!ext.Contains(fe))
                    {
                        ViewBag.e = "Choose png jpg jpeg Type only";
                        return View();
                    }
                }

                // Generate unique filenames for each image
                var filenameA = Guid.NewGuid() + Path.GetExtension(imga.FileName);
                var filenameB = Guid.NewGuid() + Path.GetExtension(imgb.FileName);
                var filenameC = Guid.NewGuid() + Path.GetExtension(imgc.FileName);
                var filenameD = Guid.NewGuid() + Path.GetExtension(imgd.FileName);

                // Get the wwwroot folder path
                string imgFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "aboutimages1");

                // Save each image to a separate file path
                string filePathA = Path.Combine(imgFolder, filenameA);
                using (var stream = new FileStream(filePathA, FileMode.Create))
                {
                    imga.CopyTo(stream);
                }
                string filePathB = Path.Combine(imgFolder, filenameB);
                using (var stream = new FileStream(filePathB, FileMode.Create))
                {
                    imgb.CopyTo(stream);
                }
                string filePathC = Path.Combine(imgFolder, filenameC);
                using (var stream = new FileStream(filePathC, FileMode.Create))
                {
                    imgc.CopyTo(stream);
                }
                string filePathD = Path.Combine(imgFolder, filenameD);
                using (var stream = new FileStream(filePathD, FileMode.Create))
                {
                    imgd.CopyTo(stream);
                }

                // Update model properties with the image paths
                model.osimg1 = Path.Combine("aboutimages1", filenameA);
                model.osimg2 = Path.Combine("aboutimages1", filenameB);
                model.osimg3 = Path.Combine("aboutimages1", filenameC);
                model.osimg4 = Path.Combine("aboutimages1", filenameD);

                // Save the model to the database
                db.About_Our_Supporters.Add(model);
                db.SaveChanges();

                return RedirectToAction("index");
            }

            return View();
        }

        public IActionResult Admin_Gallery()
		{
			return View();
		}
		[HttpPost]
		public IActionResult admin_Gallery(Gallery abc, IFormFile gimg)
		{
			var ext = new[] { "png", "jpg", "jpeg" };

			if (gimg != null && gimg.Length > 0)
			{
				var fe = System.IO.Path.GetExtension(gimg.FileName).Substring(1);
				if (!ext.Contains(fe))
				{
					ViewBag.e = "Choose png jpg jpeg Type only";
					return View();
				}
				var rn = Path.GetFileName(gimg.FileName);
				//Random rand = new Random();
				//var filename = rand.Next(1, 50) + rn;
				var filename = Guid.NewGuid() + rn;
				string imgFolder = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/ngoimage");
				if (!Directory.Exists(imgFolder))
				{
					Directory.CreateDirectory(imgFolder);
				}
				string filePath = Path.Combine(imgFolder, filename);
				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					gimg.CopyTo(stream);
				}
				var dbAddress = Path.Combine("ngoimage", filename);
				abc.img = dbAddress;
				db.Gallery.Add(abc);
				db.SaveChanges();
				return RedirectToAction("Index");

			}
			return View();
		}
		public IActionResult Gallery_fetch()
		{
			return View(db.Gallery.ToList());
		}

		public IActionResult Admin_OurProgrames()
		{
			return View();
        }
        [HttpPost]
		public IActionResult Admin_OurProgrames(ourPrograms op, IFormFile img)
		{
            var ext = new[] { "png", "jpg", "jpeg" };

            if (img != null && img.Length > 0)
            {
                var fe = System.IO.Path.GetExtension(img.FileName).Substring(1);
                if (!ext.Contains(fe))
                {
                    ViewBag.e = "Choose png jpg jpeg Type only";
                    return View();
                }
                var rn = Path.GetFileName(img.FileName);
                //Random rand = new Random();
                //var filename = rand.Next(1, 50) + rn;
                var filename = Guid.NewGuid() + rn;
                string imgFolder = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/ngoimage");
                if (!Directory.Exists(imgFolder))
                {
                    Directory.CreateDirectory(imgFolder);
                }
                string filePath = Path.Combine(imgFolder, filename);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    img.CopyTo(stream);
                }
                var dbAddress = Path.Combine("ngoimage", filename);
                op.img = dbAddress;
                db.OurPrograms.Add(op);
                db.SaveChanges();
                return RedirectToAction("fetchprogrammes");

            }
            return View();
        }
        public IActionResult Admin_Donateus()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Admin_Donateus(AddDonation add)
		{
			db.AddDonation.Add(add);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
        public IActionResult CausesManagement()
        {
      
                // Retrieve the list of causes from your database or wherever you're getting it from
                var causes = db.AddDonation.ToList();

                // Assign the list of causes to ViewBag.ep
                ViewBag.ep = causes;

                // Return the view
                return View();
            }
     
        public IActionResult Admin_DetailsofNGO()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Admin_DetailsofNGO(listofNGO abc, IFormFile image)
		{
			var ext = new[] { "png", "jpg", "jpeg" };

			if (image != null && image.Length > 0)
			{
				var fe = System.IO.Path.GetExtension(image.FileName).Substring(1);
				if (!ext.Contains(fe))
				{
					ViewBag.e = "Choose png jpg jpeg Type only";
					return View();
				}
				var rn = Path.GetFileName(image.FileName);
				//Random rand = new Random();
				//var filename = rand.Next(1, 50) + rn;
				var filename = Guid.NewGuid() + rn;
				string imgFolder = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/ngoimage");
				if (!Directory.Exists(imgFolder))
				{
					Directory.CreateDirectory(imgFolder);
				}
				string filePath = Path.Combine(imgFolder, filename);
				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					image.CopyTo(stream);
				}
				var dbAddress = Path.Combine("ngoimage", filename);
				abc.logo_img = dbAddress;
				db.ListOfNGO.Add(abc);
				db.SaveChanges();
				return RedirectToAction("Index");

			}
			return View();
		}
		public IActionResult Admin_OtherPartners()
		{
			return View(db.About_Our_Supporters.ToList());
		}
		public IActionResult team()
		{
			return View();
		}
		[HttpPost]
        public IActionResult team(about_team add,IFormFile img)
        {
            var ext = new[] { "png", "jpg", "jpeg" };

            if (img != null && img.Length > 0)
            {
                var fe = System.IO.Path.GetExtension(img.FileName).Substring(1);
                if (!ext.Contains(fe))
                {
                    ViewBag.e = "Choose png jpg jpeg Type only";
                    return View();
                }
                var rn = Path.GetFileName(img.FileName);
                //Random rand = new Random();
                //var filename = rand.Next(1, 50) + rn;
                var filename = Guid.NewGuid() + rn;
                string imgFolder = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/ngoimage");
                if (!Directory.Exists(imgFolder))
                {
                    Directory.CreateDirectory(imgFolder);
                }
                string filePath = Path.Combine(imgFolder, filename);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    img.CopyTo(stream);
                }
                var dbAddress = Path.Combine("ngoimage", filename);
				add.img = dbAddress;
				db.About_team.Add(add);
				db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }
		public IActionResult edit_team(int atID)
		{
            var id = db.About_team.Find(atID);
            return View(id);
        }
		[HttpPost]
        public IActionResult edit_team(about_team abcd,IFormFile img)
        {
            if (img != null && img.Length > 0)
            {
                var filename = Path.GetFileName(img.FileName);
                string imgFolder = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/ngoimage1");
                if (!Directory.Exists(imgFolder))
                {
                    Directory.CreateDirectory(imgFolder);
                }
                string filePath = Path.Combine(imgFolder, filename);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    img.CopyTo(stream);
                }
                var dbAddress = Path.Combine("ngoimage1", filename);
                abcd.img = dbAddress;
                db.About_team.Update(abcd);
                db.SaveChanges();
                return RedirectToAction("fetch_team");
            }
            return View();
        }
        public IActionResult delete(int atid)
        {
            var id = db.About_team.Find(atid);
            db.About_team.Remove(id);
            db.SaveChanges();
            return RedirectToAction("fetch_team");
        }
        public IActionResult fetch_team()
        {
            return View(db.About_team.ToList());
        }


        public IActionResult admin_register()
		{
			return View();
		}

		[HttpPost]
		public IActionResult admin_register(admin_register model)
		{

            db.Admin_Register.Add(model);
            db.SaveChanges();
            return RedirectToAction("Admin_Login");
         
		}

		public IActionResult Admin_Login()
		{
			if (HttpContext.Session.GetString("s") != null)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpPost]
		public IActionResult Admin_Login(admin_register log)
		{
			var login = db.Admin_Register.Where(db => db.UserEmail == log.UserEmail && db.UserPass == log.UserPass).FirstOrDefault();
			if (login != null)
			{
				HttpContext.Session.SetString("s", login.UserEmail);
				return RedirectToAction("Index");
			}
			else
			{
				ViewBag.m = "Login Failed";
			}
			return View();
		}
		public IActionResult logout()
		{

			if (HttpContext.Session.GetString("s") != null)
			{
				HttpContext.Session.Remove("s");
				return RedirectToAction("Admin_Login");
			}
			return View();
		}

		public IActionResult Admin_ContactList()
		{
			return View(db.Contact.ToList());
		}
		public IActionResult Admin_RegisterdMembers()
		{
			return View(db.User_Reg.ToList());
		}
        public IActionResult listofngo()
        {

            return View(db.ListOfNGO.ToList());
        }
        public IActionResult Admin_HelpCentre()
		{

			return View();
		}

		[HttpPost]
		public IActionResult Admin_HelpCentre(HelpCentre abc, IFormFile img)
		{
			var ext = new[] { "png", "jpg", "jpeg" };

			if (img != null && img.Length > 0)
			{
				var fe = System.IO.Path.GetExtension(img.FileName).Substring(1);
				if (!ext.Contains(fe))
				{
					ViewBag.e = "Choose png jpg jpeg Type only";
					return View();
				}
				var rn = Path.GetFileName(img.FileName);
				//Random rand = new Random();
				//var filename = rand.Next(1, 50) + rn;
				var filename = Guid.NewGuid() + rn;
				string imgFolder = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/ngoimage");
				if (!Directory.Exists(imgFolder))
				{
					Directory.CreateDirectory(imgFolder);
				}
				string filePath = Path.Combine(imgFolder, filename);
				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					img.CopyTo(stream);
				}
				var dbAddress = Path.Combine("hcimage", filename);
				abc.image = dbAddress;
				db.HelpCentre.Add(abc);
				db.SaveChanges();
				return RedirectToAction("Index");

			}
			return View();
		}
	}
}
