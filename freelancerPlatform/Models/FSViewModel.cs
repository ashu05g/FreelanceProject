using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace freelancerPlatform.Models
{
    public class FSViewModel
    {
        public List<Freelancer> Freelancers { get; set; }
        public List<Service> Services { get; set; }
    }
}