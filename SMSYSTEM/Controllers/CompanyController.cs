using Newtonsoft.Json;
using SSS.BLL.Setups;
using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSS.Utility;

namespace SMSYSTEM.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        // GET: Customer
        Company_BLL objCompany;
        Company_Property objCompanyProperty;
        public ActionResult ViewCompany()
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

        public JsonResult GetAllCoompanies()
        {
            if (Session["LOGGEDIN"] != null)
            {
                try
                {
                    objCompanyProperty = new Company_Property();
                    objCompany = new Company_BLL(objCompanyProperty);
                    var Data = JsonConvert.SerializeObject(objCompany.ViewAll());
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

        public ActionResult AddNewCompany(int? id)
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string pagename = @"/" + controllerName + @"/" + actionName;
            var page = (List<LP_Pages_Property>)Session["PageList"];
            if (Session["LoggedIn"] != null && Helper.CheckPageAccess(pagename, page) && Session["ISADMIN"] != null )
            {

                objCompanyProperty = new Company_Property();
                objCompanyProperty.idx = Convert.ToInt32(id);
                objCompany = new Company_BLL(objCompanyProperty);
                if (id > 0 && id != null)
                {
                    var dt = objCompany.GetCompanyById();
                    objCompanyProperty.idx = int.Parse(dt.Rows[0]["idx"].ToString());
                    objCompanyProperty.companyName = dt.Rows[0]["companyName"].ToString();
                    objCompanyProperty.ownerName = dt.Rows[0]["ownerName"].ToString();
                    objCompanyProperty.STRN = dt.Rows[0]["STRN"].ToString();
                    objCompanyProperty.NTN = dt.Rows[0]["NTN"].ToString();
                    objCompanyProperty.address = dt.Rows[0]["address"].ToString();
                    objCompanyProperty.country = dt.Rows[0]["country"].ToString();
                    objCompanyProperty.city = dt.Rows[0]["city"].ToString();
                    objCompanyProperty.state = dt.Rows[0]["state"].ToString();
                    objCompanyProperty.email = dt.Rows[0]["email"].ToString();
                    objCompanyProperty.contactNumber = dt.Rows[0]["contactNumber"].ToString();
                    objCompanyProperty.financialYearFrom = dt.Rows[0]["financialYearFrom"].ToString();
                    objCompanyProperty.financialYearTo = dt.Rows[0]["financialYearTo"].ToString();
                    objCompanyProperty.taxYearFrom = dt.Rows[0]["taxYearFrom"].ToString();
                    objCompanyProperty.taxYearTo = dt.Rows[0]["taxYearTo"].ToString();
                }


                return View(objCompanyProperty);
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
        public JsonResult AddUpdate(Company_Property objcompany)
        {
            if (Session["LOGGEDIN"] != null)
            {
                try
                {
                    if (objcompany.idx > 0)
                    {
                        objcompany.lastModifiedByUserIdx = 1;
                        objCompany = new Company_BLL(objcompany);

                        bool flag = objCompany.Update();
                        return Json(new { data = "Updated", success = flag, statuscode = 200 }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {   
                        objCompany = new Company_BLL(objcompany);
                        bool flag = objCompany.Insert();
                        return Json(new { data = "Inserted", success = flag, statuscode = 200 }, JsonRequestBehavior.AllowGet);
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
    }
}