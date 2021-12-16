using Newtonsoft.Json;
using SSS.BLL.Setups.Accounts;
using SSS.Property.Setups.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSS.Property.Setups;
using SSS.Utility;

namespace SMSYSTEM.Controllers
{
    public class FirstTierController : Controller
    {
        // GET: FirstTier
        firstTier_BLL objfirstTier;
        firstTier_Property objfirstTierProperty;
        public ActionResult ViewfirstTier()
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string pagename = @"/" + controllerName + @"/" + actionName;
            var page = (List<LP_Pages_Property>)Session["PageList"];
            if (Session["LoggedIn"] != null && Helper.CheckPageAccess(pagename, page) && Session["ISADMIN"] != null )
            {
                return View();
            }
            else
            {
                if (Session["LoggedIn"] == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    return RedirectToAction("NotAuthorized", "Account");
                }

            }
        }

        public JsonResult GetAllAccounts()
        {
            if (Session["LOGGEDIN"] != null)
            {
                try
                {
                    objfirstTierProperty = new firstTier_Property();
                    objfirstTier = new firstTier_BLL(objfirstTierProperty);
                    var Data = JsonConvert.SerializeObject(objfirstTier.ViewAll());
                    return Json(new { data = Data, success = true, statuscode = 200, count = Data.Length }, JsonRequestBehavior.AllowGet);

                }
                catch (Exception ex)
                {
                    return Json(new { data = ex.Message, success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { data = "Session Expired", success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }
        }

     
      
    }
}