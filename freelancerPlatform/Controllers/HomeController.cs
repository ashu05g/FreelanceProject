using freelancerPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace freelancerPlatform.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var frees = _context.Freelancers.ToList();
            var srs = _context.Services.ToList();
            var FSViewModel1 = new FSViewModel
            {
                Freelancers = frees,
                Services = srs
            };
            return View(FSViewModel1);
        }
        [HttpPost]
        public ActionResult Index(string search)
        {
            var freelancers = _context.Freelancers.Where(f => f.FullName == search).Select(s=>s.FId);
            if (freelancers != null)
            {
                foreach (var i in freelancers)
                {
                    if (i != 0)
                    {
                        //string url = string.Format("/Customers/Home/{0}", ser);
                        //return Redirect(url);
                        return RedirectToAction("Freelancers", "Customers", new { id = i });

                    }
                    //  Console.WriteLine(freelancers);
                }
            }
            else
            {
                var ser = _context.Services.Where(s => s.ServiceName == search).Select(i => i.SerId);
                foreach(var i in ser)
                {
                    if (i != 0)
                    {
                        //string url = string.Format("/Customers/Home/{0}", ser);
                        //return Redirect(url);
                        return RedirectToAction("Home", "Customers", new { id = i });
                    }
                }
                ViewBag.msg = "not found";
            }
            return View(freelancers);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}