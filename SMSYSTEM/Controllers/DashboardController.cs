using SSS.Property.Setups;
using SSS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSYSTEM.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
       

        public ActionResult Dashboard()
        {
            //string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            //string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            //string pagename = @"/" + controllerName + @"/" + actionName;
            //var page = (List<LP_Pages_Property>)Session["PageList"];
            if (Session["LoggedIn"] != null )
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
                
            }
        }
    }
}