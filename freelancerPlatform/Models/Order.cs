using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace freelancerPlatform.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OId { get; set; }

        public int? CId { get; set; }

        public int? FId { get; set; }
        [Column("SId")]
        public int? Id { get; set; }

        [Required]
        public string Description { get; set; }
        public string Status { get; set; }

        [ForeignKey("CId")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("FId")]
        public virtual Freelancer Freelancer { get; set; }
        [ForeignKey("Id")]
        public virtual Specialisation Specialisation { get; set; }

    }
}