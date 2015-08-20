using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCMI.Models
{
    public class Event
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Venue { get; set; }
        public System.DateTime DateOfEvent { get; set; }
        public string Time { get; set; }
        public bool Expired { get; set; }
    }
}