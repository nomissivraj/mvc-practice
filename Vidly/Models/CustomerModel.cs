using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class CustomerModel
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime? DoB { get; set; }

        [MaxLength(1000, ErrorMessage = "{1} Max Characters")]
        public string Hobby { get; set; }

        public bool IsSubbedNewsletter { get; set; }

        public MembershipType MembershipType { get; set; } // Relating membership to customer

        [Display(Name="Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}