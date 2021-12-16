using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

using SSS.Utility;
using SSS.BLL.Setups;
using SSS.Property.Setups;
using System.Data;

namespace SMSYSTEM.Controllers
{
    public class companyCurrencyController : Controller
    {
        CompanyCurrency_BLL objcompanyCurrencybll;
        companyCurrency_Property objcompanyCurrencyproperty;


        public ActionResult ViewCompanyCurrency()
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string pagename = @"/" + controllerName + @"/" + actionName;
            var page = (List<LP_Pages_Property>)Session["PageList"];
            if (Session["LoggedIn"] != null && Helper.CheckPageAccess(pagename, page) && Session["ISADMIN"] != null)
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
                    //return View();
                }

            }

        }

        public JsonResult GetAllCompanyCurrency()
        {

            if (Session["LOGGEDIN"] != null)
            {
                try
                {


                     objcompanyCurrencybll = new CompanyCurrency_BLL(objcompanyCurrencyproperty);
                    var Data = JsonConvert.SerializeObject(objcompanyCurrencybll.ViewAll());
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

        public ActionResult AddCompanyNewCurrency(int? id)
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string pagename = @"/" + controllerName + @"/" + actionName;
            var page = (List<LP_Pages_Property>)Session["PageList"];
            if (Session["LoggedIn"] != null && Helper.CheckPageAccess(pagename, page) && Session["ISADMIN"] != null )
            {
                objcompanyCurrencyproperty = new companyCurrency_Property();
                objcompanyCurrencybll = new CompanyCurrency_BLL(objcompanyCurrencyproperty);
               // objcompanyCurrencybll.SelectAllCurrency()
                objcompanyCurrencyproperty.CurrencyLST = Helper.ConvertDataTable<currency_Property>(objcompanyCurrencybll.SelectAllCurrency());
                try
                {
                    if (id > 0)
                    {
                        int currecyId;
                        decimal exchangeRate;
                        objcompanyCurrencyproperty.idx = Convert.ToInt32(id);
                        objcompanyCurrencybll = new CompanyCurrency_BLL(objcompanyCurrencyproperty);
                        DataTable dt = new DataTable();
                        dt= objcompanyCurrencybll.SelectOne();                        
                        int.TryParse(dt.Rows[0]["currencyIdx"].ToString(),out currecyId);
                        objcompanyCurrencyproperty.currencyIdx = currecyId;
                        decimal.TryParse(dt.Rows[0]["exhangeRate"].ToString(), out exchangeRate);
                        objcompanyCurrencyproperty.exhangeRate = exchangeRate;
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {

                }
                return PartialView("_AddCompanyNewCurrency", objcompanyCurrencyproperty);
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

        [HttpPost]
        public JsonResult AddComapnyUpdate(companyCurrency_Property objcomapnyCurrency)
        {
            bool flag;

            if (Session["LOGGEDIN"] != null)
            {
                try
                {
                    objcompanyCurrencyproperty = new companyCurrency_Property();
                    objcompanyCurrencyproperty = objcomapnyCurrency;
                    objcompanyCurrencyproperty.visble = 1;
                    objcompanyCurrencyproperty.createdByUserIdx = Convert.ToInt32(Session["UID"].ToString());
                    objcompanyCurrencyproperty.creationDate = DateTime.Now;
                    objcompanyCurrencyproperty.lastModifiedByUserIdx = Convert.ToInt32(Session["UID"].ToString());
                    objcompanyCurrencyproperty.lastModificationDate = DateTime.Now.ToString("yyyy-MM-dd");

                    objcompanyCurrencybll = new CompanyCurrency_BLL(objcompanyCurrencyproperty);
                    ////check existing name
                  
                   
                     
                        if (objcomapnyCurrency.idx > 0)
                        {
                            //update
                            flag = objcompanyCurrencybll.Update();
                            return Json(new { data = objcomapnyCurrency, success = flag, msg = "Success", statuscode = 200, count = 0 }, JsonRequestBehavior.AllowGet);


                        }
                        else
                        {
                            //add
                            flag = objcompanyCurrencybll.Insert();
                            return Json(new { data = "", success = flag, msg = "Success", statuscode = 200, count = 0 }, JsonRequestBehavior.AllowGet);

                        }
                    


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

        public JsonResult Delete(int? id)
        {
            if (Session["LOGGEDIN"] != null)
            {
                try
                {
                    objcompanyCurrencyproperty = new companyCurrency_Property();

                    objcompanyCurrencyproperty.idx = int.Parse(id.ToString());

                    objcompanyCurrencybll = new CompanyCurrency_BLL(objcompanyCurrencyproperty);
                        var flag1 = objcompanyCurrencybll.Delete();
                    if (flag1)
                    {
                        return Json(new { data = "Deleted", success = flag1, statuscode = 200 }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { data = "Error", success = flag1, statuscode = 200 }, JsonRequestBehavior.DenyGet);
                    }

                        //else
                        //{
                        //    return Json(new { data = "Mian Branch Cannot be Delete ", success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
                        //}

                        //}
                        // return Json(new { data = "Process Completed ", success = true, statuscode = 200 }, JsonRequestBehavior.AllowGet);



                   


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