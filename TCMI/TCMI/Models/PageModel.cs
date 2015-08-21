using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCMI.Models
{
    public class PageModel
    {
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<Prayer> Prayers { get; set; }
        public Prayer Prayer { get; set; }
    }
}