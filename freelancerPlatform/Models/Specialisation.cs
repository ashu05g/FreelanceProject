using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace freelancerPlatform.Models
{
    public class Specialisation
    {
        public int Id { get; set; }
        
        public int? FId { get; set; }

        public string Name { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        public string About { get; set; }
        public string Description { get; set; }

        public int Price { get; set; }
        public int Days { get; set; }
        [ForeignKey("FId")]
        public virtual Freelancer Freelancer { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}