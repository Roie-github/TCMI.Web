using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCMI.Models
{
    public class Prayer
    {

        [Required]
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Confidentiality { get; set; }
        [Required(ErrorMessage = "Prayer Request is required.")]
        public string PrayerRequest { get; set; }
        public System.DateTime Received { get; set; }
        public int Prayed { get; set; }
        public Nullable<bool> Answered { get; set; }

    }
}