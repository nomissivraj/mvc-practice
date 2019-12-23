using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class ProfileViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        [MaxLength(1000, ErrorMessage = "{1} Max Characters")]
        public string Hobby { get; set; }
    }
}