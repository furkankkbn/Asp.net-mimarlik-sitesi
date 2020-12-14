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
using System.IO;


namespace MBY.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        DBMBYDesignStudio db = new DBMBYDesignStudio();
        public ActionResult admin()
        {
            return View();
        }


        public ActionResult NewProject()
        {
            return View();

        }
        [HttpPost]
        public ActionResult NewProject(HttpPostedFileBase[] files, Proje prop)
        {
            if (ModelState.IsValid)
            {   //iterating through multiple file collection   
                foreach (HttpPostedFileBase file in files)
                {
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        var InputFileName = Path.GetFileName(file.FileName);
                        var ServerSavePath = Path.Combine(Server.MapPath("~/Content/img/AppFile/Project/") + InputFileName);
                        //Save file to server folder  
                        file.SaveAs(ServerSavePath);
                        //assigning file uploaded status to ViewBag for showing message to user.  
                        ViewBag.UploadStatus = files.Count().ToString() + " files uploaded successfully.";
                        prop.Path = InputFileName;
                        db.Projes.Add(prop);
                        db.SaveChanges();

                    }

                }
            }
            return View();
        }
        public ActionResult NewPersonnel()
        {
            return View("NewPersonnel");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewPersonnel(Ekip newpers, HttpPostedFileBase[] files)
        {
            if (ModelState.IsValid)
            {   //iterating through multiple file collection   
                foreach (HttpPostedFileBase file in files)
                {
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        var InputFileName = Path.GetFileName(file.FileName);
                        var ServerSavePath = Path.Combine(Server.MapPath("~/Content/img/AppFile/Ekip/") + InputFileName);
                        //Save file to server folder  
                        file.SaveAs(ServerSavePath);
                        //assigning file uploaded status to ViewBag for showing message to user.  
                        ViewBag.UploadStatus = files.Count().ToString() + " files uploaded successfully.";
                        newpers.Fotograf = InputFileName;

                        db.Ekips.Add(newpers);
                        db.SaveChanges();

                    }

                }
            } return View();
        }

        public ActionResult Personnel(Ekip ekip)
        {
            var personnel = db.Ekips.ToList();
            return View(personnel);
        }
        public ActionResult personnelDelete(int id)
        {
            var deletePers = db.Ekips.Find(id);
            if (deletePers == null)
                return HttpNotFound();
            db.Ekips.Remove(deletePers);
            db.SaveChanges();
            return RedirectToAction("Personnel");
        }

        public ActionResult deleteproject(int id)
        {
            var deleteproject = db.Projes.Find(id);
            if (deleteproject == null)
                return HttpNotFound();
            db.Projes.Remove(deleteproject);
            db.SaveChanges();
            return RedirectToAction("Projeler");
        }
        public ActionResult updateproject(int id)
        {
            var model = db.Projes.Find(id);
            if (model == null)
                return HttpNotFound();
            return View("updateproject", model);
        }
        [HttpPost]
        public ActionResult updateproject(HttpPostedFileBase[] files, Proje proje)
        {
            if (ModelState.IsValid)
            {
                var updateprje = db.Projes.Find(proje.Id);
                foreach (HttpPostedFileBase file in files)
                {
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        var InputFileName = Path.GetFileName(file.FileName);
                        var ServerSavePath = Path.Combine(Server.MapPath("~/AppFile/Project/") + InputFileName);
                        //Save file to server folder  
                        file.SaveAs(ServerSavePath);

                        updateprje.Path = proje.Path;
                        updateprje.Name = proje.Name;

                        updateprje.Area = proje.Area;
                        updateprje.Location = proje.Location;
                        updateprje.Rooms = proje.Rooms;
                        updateprje.Type = proje.Type;
                        updateprje.Year = proje.Year;

                        db.SaveChanges();
                    }
                }

                updateprje.Name = proje.Name;

                updateprje.Area = proje.Area;
                updateprje.Location = proje.Location;
                updateprje.Rooms = proje.Rooms;
                updateprje.Type = proje.Type;
                updateprje.Year = proje.Year;
                db.SaveChanges();

            }

            return RedirectToAction("Projeler", "Admin");
        }
        public ActionResult personnelUpdate(int id)
        {
            var model = db.Ekips.Find(id);
            if (model == null)
                return HttpNotFound();
            return View("personnelUpdate", model);
        }
        [HttpPost]
        public ActionResult personnelUpdate(HttpPostedFileBase[] files,Ekip ekip)
        {

            if (ModelState.IsValid)
            {
                var updateprje = db.Ekips.Find(ekip.Id);

                foreach (HttpPostedFileBase file in files)
                {
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        var InputFileName = Path.GetFileName(file.FileName);
                        var ServerSavePath = Path.Combine(Server.MapPath("~/AppFile/Ekip/") + InputFileName);
                        //Save file to server folder  
                        file.SaveAs(ServerSavePath);



                        updateprje.AdSoyad = ekip.AdSoyad;
                        updateprje.Aciklama = ekip.Aciklama;
                        updateprje.Unvan = ekip.Unvan;

                        db.SaveChanges();
                    }
                }
                updateprje.AdSoyad = ekip.AdSoyad;
                updateprje.Aciklama = ekip.Aciklama;

                updateprje.Unvan = ekip.Unvan;
                db.SaveChanges();

            }

            return RedirectToAction("Personnel", "Admin");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ComminationPage(Commination commi)
        {
            var commination = db.Comminations.ToList();
            return View(commination);
        }

        public ActionResult commupdate(int id)
        {
            var model = db.Comminations.Find(id);
            if (model == null)
                return HttpNotFound();
            return View("commupdate", model);
        }
        [HttpPost]
        public ActionResult commupdate(Commination commination)
        {
            var updatecom = db.Comminations.Find(commination.Id);
            if (updatecom == null)
            {
                return HttpNotFound();
            }
            updatecom.Adres = commination.Adres;
            updatecom.Telefon = commination.Telefon;
            updatecom.Mail = commination.Mail;
            db.SaveChanges();
            return RedirectToAction("ComminationPage", "Admin");
        }

        public ActionResult Hakkimizda(Hakkimizda hakkimiz)
        {
            var hak = db.Hakkimizdas.ToList();
            return View(hak);
        }

        public ActionResult hakupdate(int id)
        {
            var model = db.Hakkimizdas.Find(id);
            if (model == null)
                return HttpNotFound();
            return View("hakupdate", model);
        }
        [HttpPost]
        public ActionResult hakupdate(Hakkimizda hakkimiz)
        {
            var udpdatehakkimiz = db.Hakkimizdas.Find(hakkimiz.Id);
            if (udpdatehakkimiz == null)
            {
                return HttpNotFound();
            }
            udpdatehakkimiz.Baslik = hakkimiz.Baslik;
            udpdatehakkimiz.Konu = hakkimiz.Konu;
            udpdatehakkimiz.İcerik = hakkimiz.İcerik;
            db.SaveChanges();
            return RedirectToAction("Hakkimizda", "Admin");
        }
        public ActionResult Mailler(Iletisim iletisim)
        {
            var mail = db.Iletisims.ToList();
            return View(mail);
        }
        public ActionResult Projeler(Proje propj)
        {
            var proje = db.Projes.ToList();
            return View(proje);
        }


    }
}
