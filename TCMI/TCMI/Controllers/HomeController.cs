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
            p.Prayers = setPrayers(prayers);
            p.Prayer = new Models.Prayer();
            return View(p);
        }
        
        public ActionResult IPray(int id)
        {
            ViewBag.MsgResult= client.Prayed(id);
            IEnumerable<TCMIContentServices.Prayer> prayers = client.GetPrayers();
            IEnumerable<Models.Prayer> plist = setPrayers(prayers);
            ViewBag.MyId = id.ToString();
            return PartialView("_ViewAllPrayers", plist);
        }
        [ValidateInput(false)]
        public ActionResult Create(Models.Prayer prayer)
        {
            string retValue = string.Empty;
            if (ModelState.IsValid)
            {
                retValue = client.AddPrayer(HttpUtility.HtmlEncode(prayer.Name), prayer.Email, HttpUtility.HtmlEncode(prayer.Phone), prayer.Confidentiality, HttpUtility.HtmlEncode(prayer.PrayerRequest));
                ViewBag.ReturnMessage = retValue;
            }
            ViewBag.ReturnMessage = retValue;

            IEnumerable<TCMIContentServices.Prayer> prayers = client.GetPrayers();
            IEnumerable<Models.Prayer> plist = setPrayers(prayers);
            return PartialView("_ViewAllPrayers", plist);
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

        public IEnumerable<TCMI.Models.Prayer> setPrayers(IEnumerable<TCMIContentServices.Prayer> prayer)
        {
            List<Models.Prayer> result = new List<Models.Prayer>();
            foreach (var item in prayer)
            {
                if (item.Confidentiality.Equals("Anonymous"))
                {
                    item.Name = "Anonymous";
                }
                Models.Prayer p = new Models.Prayer
                {
                    id = item.id,
                    Name = item.Name,
                    Email = item.Email,
                    Phone = item.Phone,
                    Prayed = item.Prayed,
                    Answered = item.Answered,
                    Confidentiality = item.Confidentiality,
                    PrayerRequest = item.PrayerRequest,
                    Received = item.Received
                };
                if (!item.Confidentiality.Equals("Private"))
                {
                    result.Add(p);
                }
                
            }
            return result;
        }


    }
}

