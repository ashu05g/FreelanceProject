using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace freelancerPlatform.Models
{
    public class Customer
    {
    [Key]
    public int CId { get; set; }

    [Required]
    [StringLength(255)]
    public string FullName { get; set; }
    public string City { get; set; }

    
    public string Phone { get; set; }

    public string Image { get; set; }
    [NotMapped]
    public HttpPostedFileBase ImageFile { get; set; }
    [Required]
    public string Email { get; set; }
    public virtual ICollection<Order> Orders { get; set; }

    }
}