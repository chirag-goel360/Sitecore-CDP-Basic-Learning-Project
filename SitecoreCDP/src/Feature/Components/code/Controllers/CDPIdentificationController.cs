using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SitecoreCDP.Feature.Components.Models;

namespace SitecoreCDP.Feature.Components.Controllers
{
    public class CDPIdentificationController : Controller
    {
        public ActionResult GetIdentification()
        {
            VisitorInformation visitorInformation = new VisitorInformation();
            return View(visitorInformation);
        }
    }
}