using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using freelancerPlatform.Models;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Net.Http;

namespace freelancerPlatform.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
       // public ActionResult Login()
        //{
//
  //      }

        public ActionResult Index()
        {
            var service = _context.Services.ToList();
            return View(service);
        }
        [Authorize(Roles ="Customer")]
        public ActionResult MyOrder()
        {

            var cust = _context.Customers.SingleOrDefault(f => f.Email == User.Identity.Name);
            var order = _context.Orders.Where(o => o.CId == cust.CId).ToList();
            return View(order);
        }
        [Authorize(Roles = "Customer")]
        public ActionResult MyProfile()
        {
            ViewBag.name = User.Identity.Name.ToString();
            var customer = _context.Customers.SingleOrDefault(f => f.Email == User.Identity.Name.ToString());
            //var free = freelancer.Include(c => c.Specialisations);

            return View(customer);
           
        }
        [Authorize(Roles = "Customer")]
        public ActionResult Modify(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                Customer customer = _context.Customers.Find(id);

                if (customer == null)
                {
                    return HttpNotFound();
                }
                TempData["image"] = customer.Image.ToString();
                return View(customer);
            }

            // var freelancer = db.Freelancers.SingleOrDefault(f => f.Email == User.Identity.Name.ToString());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public ActionResult Modify([Bind(Include = "CId,FullName,City,Phone,Email")]Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(customer).State = EntityState.Modified;

                if (TempData.ContainsKey("image"))
                    customer.Image = TempData["image"].ToString();
                _context.SaveChanges();

                return RedirectToAction("MyProfile", "Customers");
            }
            return View("Modify", customer);
        }

        public ActionResult Home(int? id)
        {
            if(id==null)
            {
                FSSViewModel fssvm = new FSSViewModel
                {
                    Specialisations =  _context.Specialisations.ToList(),
                    Freelancers = _context.Freelancers.ToList(),
                    Service = new Service()

                };
                return View(fssvm);
            }
            else
            {              
                var service = _context.Services.SingleOrDefault(s => s.SerId == id); 
                var speci = _context.Specialisations.Where(s => s.Name == service.ServiceName).ToList();
                var free = _context.Freelancers.ToList();
              
                FSSViewModel fssvm = new FSSViewModel
                {
                    Specialisations=speci,
                    Freelancers = free,
                    Service=service

                };
                return View(fssvm);
            }    
        }

        
        public ActionResult Details(int id)
        {
            //var freelancers = _context.Freelancers.Include(c=>c.Specialisations).SingleOrDefault(s=>s.Specialisations.Id.;
            var freelancers = from f in _context.Freelancers
                              where f.Specialisations.Any(c => c.Id == id)
                              select f;
            ViewBag.sid = id;
            return View(freelancers);
        }
        [Authorize(Roles = "Customer")]
        [HttpPost]
        public ActionResult Orders(int SId,int FId,string description)
        {
            var model1 = _context.Customers.SingleOrDefault(u => u.Email == User.Identity.Name.ToString());

            var order = new Order
            {

                Id = SId,
                FId = FId,
                Description = description,
                CId = model1.CId,
                Status = "pending"
            };
            _context.Orders.Add(order);
            _context.SaveChanges();
            return RedirectToAction("MyOrder");
        }
        public ActionResult Freelancers(int id)
        {
            var freelancer=_context.Freelancers.Where(f=>f.FId==id);
            var free = freelancer.Include(c => c.Specialisations);
           // var freelancer1 = _context.Freelancers.Include(c => c.Services).Select(f => f.Services.);

            // int count = _context.Specialisations.GroupBy(f => f.Freelancer.FId == id).Count(s => s.name);
            return View(freelancer);
        }
        [Authorize(Roles = "Customer")]
        public ActionResult OrderResponse(int id, string status)
        {
            var order = _context.Orders.SingleOrDefault(x => x.OId == id);
            if (status == "paid")
            {

                order.Status = "paid";
            }

            _context.SaveChanges();


            return RedirectToAction("MyOrder");
        }
        
    }
}