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
            ViewBag.eventNav = BuildNav(events);
            ViewBag.eventlist = BuildEvents(events);

            return View();
        }

        public string BuildNav(IEnumerable<TCMIContentServices.Event> events)
        {
            StringBuilder result = new StringBuilder();

            int i = 0;
            foreach (var item in events)
            {
                if (i == 0)
                {
                    result.Append("<li data-target='#myCarousel' data-slide-to='"+ i.ToString() +"' class='active'></li>");
                }
                else
                {
                    result.Append("<li data-target='#myCarousel' data-slide-to='" + i.ToString() + "'></li>");
                }

                i++;
            }


            return result.ToString();
        }

        public string BuildEvents(IEnumerable<TCMIContentServices.Event> events)
        {
            StringBuilder result = new StringBuilder();
            
            int i = 0;
            foreach (var item in events)
            {
                if (i == 0)
                {
                    result.Append("<div class='active item'>");
                }
                else
                {
                    result.Append("<div class='item'>");
                }


                result.Append("     <div class='box'>");
                result.Append("             <div class='ddshadow'><h2>" + item.Title + "</h2></div>");
                result.Append("             <div class='carousel-caption'>");
                result.Append("                     <p><h3>" + item.Description + "</h3></p>");
                result.Append("                     <p><i class='fa fa-map-marker'></i> "+ item.Venue +"</p>");
                result.Append("                     <p><i class='fa fa-calendar'></i> " + item.DateOfEvent.ToLongDateString() + "</p>");
                result.Append("                     <p><i class='fa fa-clock-o'></i> " + item.Time + "</p>");
                result.Append("             </div>");
                result.Append("     </div>");
                result.Append("</div>");


                i++;
            }
           

            return result.ToString();
        }

    }
}
