using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace freelancerPlatform.Models
{
    public class Service
    {
        [Key]
        public int SerId { get; set; }
        [Required]
        [StringLength(255)]
        public string ServiceName { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public virtual ICollection<Freelancer> Freelancers { get; set; }
    }
}