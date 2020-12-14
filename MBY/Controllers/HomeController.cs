using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBY.Models;
using System.Web.Helpers;
using System.Data.Entity;
using System.Data;
using System.Web.Security;
using System.Text;

namespace MBY.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        DBMBYDesignStudio db = new DBMBYDesignStudio();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Iletisim()
        {
            var personnel = db.Comminations.ToList();
            return View(personnel);
        }
       [HttpPost]
        public ActionResult Iletisim(Iletisim ilet)
        {
            db.Iletisims.Add(ilet);
            db.SaveChanges();

            WebMail.SmtpServer = "smtp.gmail.com";
            WebMail.EnableSsl = true;
            WebMail.UserName = "contenct@mbydesignstudio.com";
            WebMail.Password = "cansubatuhan1317"; // gerçek dışı
            WebMail.SmtpPort = 587;
            WebMail.Send(
                 ilet.Mail,
                  subject: "Yeni bir iletiniz var..",
                  body: ilet.Ad + ilet.Soyad +"<br />" + ilet.Icerik ,
                  replyTo: "contenct@mbydesignstudio.com"

                );

               
            return RedirectToAction("Iletisim", "Home");
        }
        public ActionResult Hakkimizda()
        {

            var personnel = db.Hakkimizdas.ToList();
            return View(personnel);
        }
        public ActionResult Personnell()
        {
            var personnel = db.Ekips.ToList();
            return View(personnel);
        
        }

        public ActionResult AdminPanel()
        {
            return View();
        }

        public ActionResult ProjectDetail(int id)
        {
            var imagename = db.Projes.Find(id);

            ViewBag.soru = imagename.Name.ToString();
            var projje = db.Projes.ToList();
            TempData["Area"] = imagename.Area;
            TempData["Location"] = imagename.Location;
            TempData["Name"] = imagename.Name;
            TempData["Path"] = imagename.Path;
            TempData["Rooms"] = imagename.Rooms;
            TempData["Type"] = imagename.Type;
            TempData["Year"] = imagename.Year;
            

            return View(projje);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(Admin admin)
        {   try
            {
                var varmi = db.Admins.Where(i => i.KullaniciAdi == admin.KullaniciAdi).SingleOrDefault();
                if (varmi == null)
                {
                    return View();
                }
                if (varmi.Sifre == admin.Sifre)
                {
                    Session["username"] = varmi.AdSoyad;
                    Session["Id"] = varmi.Id;
                    
                    return RedirectToAction("AdminPanel", "Home");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
            
        }
        public ActionResult project()
        {
         
            var projje = db.Projes.GroupBy(x => x.Name)
          .Select(g => g.FirstOrDefault()).ToList(); 
            return View(projje);
        }
       
    }
}
