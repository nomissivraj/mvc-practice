using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DTOs
{
    public class CustomerDTO
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        //[AgeLimit]
        public DateTime? DoB { get; set; }

        [MaxLength(1000, ErrorMessage = "{1} Max Characters")]
        public string Hobby { get; set; }

        public bool IsSubbedNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }

        public MembershipTypeDTO MembershipType { get; set; }
    }
}