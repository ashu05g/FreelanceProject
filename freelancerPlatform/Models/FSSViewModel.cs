using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace freelancerPlatform.Models
{
    public class FSSViewModel
    {
        public IEnumerable<Freelancer> Freelancers { get; set; }
        public IEnumerable<Specialisation> Specialisations { get; set; }
        public Service Service { get; set; }
    }
}