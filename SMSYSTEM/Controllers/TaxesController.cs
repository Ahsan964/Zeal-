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
    public class TaxesController : Controller
    {
        // GET: Taxes
        Taxes_BLL objTaxes;
        Taxes_Property objTaxesProperty;
        public ActionResult ViewTaxes()
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string pagename = @"/" + controllerName + @"/" + actionName;
            var page = (List<LP_Pages_Property>)Session["PageList"];

            if (Session["LoggedIn"] != null && Helper.CheckPageAccess(pagename, page))
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

        public JsonResult GetAllTaxes()
        {
            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                    objTaxesProperty = new Taxes_Property();
                    objTaxes = new Taxes_BLL(objTaxesProperty);
                    var Data = JsonConvert.SerializeObject(objTaxes.ViewAll());
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

        public ActionResult AddNewTaxes(int? id)
        {

            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string pagename = @"/" + controllerName + @"/" + actionName;
            var page = (List<LP_Pages_Property>)Session["PageList"];

            if (Session["LOGGEDIN"] != null && Helper.CheckPageAccess(pagename, page))
            {

                objTaxesProperty = new Taxes_Property();
                objTaxesProperty.idx = Convert.ToInt32(id);
                objTaxes = new Taxes_BLL(objTaxesProperty);
                if (id > 0 && id != null)
                {
                    var dt = objTaxes.GetById();
                    //objTaxesProperty.companyIdx = 1;
                    objTaxesProperty.idx = int.Parse(dt.Rows[0]["idx"].ToString());
                    objTaxesProperty.taxName = (dt.Rows[0]["taxName"].ToString());
                    objTaxesProperty.shortName = (dt.Rows[0]["shortName"].ToString());
                    objTaxesProperty.taxPercent = decimal.Parse(dt.Rows[0]["taxPercent"].ToString());
                    objTaxesProperty.IsClaimble = Convert.ToBoolean(dt.Rows[0]["IsClaimble"].ToString());
                    //objTaxesProperty.contactNumber = dt.Rows[0]["contactNumber"].ToString();
                    //objTaxesProperty.isMainBranch = int.Parse(dt.Rows[0]["isMainBranch"].ToString());
                    //objTaxesProperty.address = dt.Rows[0]["address"].ToString();
                }


                return PartialView("_AddNewTaxes", objTaxesProperty);
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
        public JsonResult AddUpdate(Taxes_Property obj_Taxes)
        {
            if (Session["LOGGEDIN"] != null)
            {
                try
                {
                    if (obj_Taxes.idx > 0)
                    {

                        obj_Taxes.lastModifiedByUserIdx = Convert.ToInt32(Session["UID"].ToString());
                        obj_Taxes.lastModificationDate = DateTime.Now.ToString("dd/MM/yyyy");
                        objTaxes = new Taxes_BLL(obj_Taxes);

                        bool flag = objTaxes.Update();
                        return Json(new { data = "Updated", success = flag, statuscode = 200 }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        //obj_Taxes.companyIdx = 1;
                        obj_Taxes.createdByUserIdx = Convert.ToInt32(Session["UID"].ToString());
                        objTaxes = new Taxes_BLL(obj_Taxes);


                        bool flag = objTaxes.Insert();
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

        public JsonResult DeleteTaxes(int? id)
        {

            if (Session["LOGGEDIN"] != null)
            {
                try
                {
                    if (id > 0)
                    {

                        Taxes_Property branchProperty = new Taxes_Property();
                        branchProperty.idx = int.Parse(id.ToString());
                        objTaxes = new Taxes_BLL(id);
                        Taxes_BLL branhcBll = new Taxes_BLL(branchProperty);
                        //var flag1 = branhcBll.GetById();
                        //if (flag1.Rows.Count > 0)
                        //{
                        //    if (int.Parse(flag1.Rows[0]["isMainBranch"].ToString()) == 0)
                        //    {
                        bool flag = objTaxes.Delete(id);
                        return Json(new { data = "Deleted", success = flag, statuscode = 200 }, JsonRequestBehavior.AllowGet);
                        //}
                        //else
                        //{
                        //    return Json(new { data = "Mian Branch Cannot be Delete ", success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
                        //}

                    }
                    return Json(new { data = "Process Completed ", success = true, statuscode = 200 }, JsonRequestBehavior.AllowGet);





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