using freelancerPlatform.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace freelancerPlatform.Controllers
{
    
    public class FreelancersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Freelancers
        public ActionResult Index()
        {
           
            return View();
        }
        [Authorize(Roles = "Freelancer")]
        public ActionResult MyProfile()
        {

            ViewBag.name = User.Identity.Name.ToString();
            var freelancer = db.Freelancers.SingleOrDefault(f => f.Email == User.Identity.Name.ToString());
            //var free = freelancer.Include(c => c.Specialisations);

            return View(freelancer);

          
        }
        [Authorize(Roles = "Freelancer")]
        public ActionResult Modify(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                Freelancer freelancer = db.Freelancers.Find(id);

                if (freelancer == null)
                {
                    return HttpNotFound();
                }
               TempData["image"] = freelancer.Image.ToString();
                return View(freelancer);
            }
             
            // var freelancer = db.Freelancers.SingleOrDefault(f => f.Email == User.Identity.Name.ToString());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Freelancer")]
        public ActionResult Modify([Bind(Include = "FId,FullName,City,Phone,Email,About")]Freelancer freelancer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(freelancer).State = EntityState.Modified;

                if (TempData.ContainsKey("image"))
                    freelancer.Image = TempData["image"].ToString();
                db.SaveChanges();

                return RedirectToAction("MyProfile","Freelancers");
            }
            return View("Modify",freelancer);
        }
        [Authorize(Roles = "Freelancer")]
        public ActionResult AddSpecialisation(int id)
        {
            var fr = db.Freelancers.SingleOrDefault(f => f.FId == id);
            FreelancersSpecViewModel fs=new FreelancersSpecViewModel
            
            {
               freelancer=fr,
               specialisation=new Specialisation()
            };

            var ser = db.Services.Select(s => new
            {
                serId = s.SerId,
                serviceName = s.ServiceName
            }).ToList();
            ViewData["Service"] = new SelectList(db.Services, "ServiceName", "ServiceName");
            TempData["fid"] = id;
            //db.Specialisations.Add(sp);
            return View(fs);
        }
        [HttpPost]
        [Authorize(Roles = "Freelancer")]
        public ActionResult AddSpecialisation(Specialisation specialisation)
        {
            if (ModelState.IsValid)
            {
                string img = Path.GetFileNameWithoutExtension(specialisation.ImageFile.FileName);
                string ex = Path.GetExtension(specialisation.ImageFile.FileName);
                img = img + ex;
                specialisation.Image = "~/Content/images/" + img;
                img = Path.Combine(Server.MapPath("~/Content/images/"), img);
                specialisation.ImageFile.SaveAs(img);
                if (TempData.ContainsKey("fid"))
                    specialisation.FId = int.Parse(TempData["fid"].ToString());
                db.Specialisations.Add(specialisation);
                db.SaveChanges();
                var ser = db.Services.SingleOrDefault(x => x.ServiceName == specialisation.Name);
                var fre = db.Freelancers.SingleOrDefault(f => f.FId == specialisation.FId);
                fre.Services.Add(ser);
                db.SaveChanges();
                return RedirectToAction("MyProfile");
            }
            else
            {
                return View(specialisation);

            }
        }
        [Authorize(Roles = "Freelancer")]
        public ActionResult MyOrder()
        {
            var freel = db.Freelancers.SingleOrDefault(f => f.Email == User.Identity.Name);
            var order = db.Orders.Where(o=>o.FId==freel.FId).ToList();
            return View(order);
        }
        [Authorize(Roles = "Freelancer")]
        public ActionResult OrderResponse(int id,string status)
        {
            var order = db.Orders.SingleOrDefault(x => x.OId == id);
            if(status=="accept")
            {

                order.Status = "Accepted";
            }
            else if(status=="decline")
            {
                order.Status = "Declined";
            }
            else if(status=="completed")
            {
                order.Status = "completed";
            }
            db.SaveChanges();


            return RedirectToAction("MyOrder");
        }

    }

}