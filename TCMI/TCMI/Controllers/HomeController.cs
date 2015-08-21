using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TCMI.Models;
using TCMI.TCMIContentServices;

namespace TCMI.Controllers
{
    public class HomeController : Controller
    {
        public TCMIContentServices.TCMIContentSoapClient client = new TCMIContentSoapClient();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            IEnumerable<TCMIContentServices.Event> events = client.GetActiveEvents();
            IEnumerable<TCMIContentServices.Prayer> prayers = client.GetPrayers();
            PageModel p = new PageModel();
            p.Events = setEvent(events);

            return View(p);
        }

        public IEnumerable<TCMI.Models.Event> setEvent(IEnumerable<TCMIContentServices.Event> events)
        {
            List<Models.Event> result = new List<Models.Event>();
            foreach (var item in events)
            {
                Models.Event e = new Models.Event
                {
                    id = item.id,
                    Title = item.Title,
                    Venue = item.Venue,
                    Description = item.Description,
                    DateOfEvent = item.DateOfEvent,
                    Time = item.Time,
                    Expired = item.Expired
                };
                result.Add(e);
            }
            return result;

        }

       

    }
}
