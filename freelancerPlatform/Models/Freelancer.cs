using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace freelancerPlatform.Models
{
    public class Freelancer
    {
        [Key]
        public int FId { get; set; }
        [Required]
        [StringLength(255)]
        public string FullName { get; set; }
        public string City { get; set; }

        //[Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        public string About { get; set; }

        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Specialisation> Specialisations { get; set; }
    }
        
}