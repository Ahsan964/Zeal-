using Newtonsoft.Json;
using SSS.BLL.Setups.Accounts;
using SSS.Property.Setups.Accounts;
using SSS.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSS.Property.Setups;

namespace SMSYSTEM.Controllers
{
    public class FourthTierController : Controller
    {
        // GET: FourthTier
        // GET:fourthTier
       fourthTier_BLL objfourthTierbll;
       fourthTier_Property objfourthTierproperty;


        public ActionResult ViewfourthTiers()
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
                }

            }

        }

        public JsonResult GetAllfourthTiers()
        {

            if (Session["LOGGEDIN"] != null)
            {
                try
                {


                    objfourthTierbll = new fourthTier_BLL(objfourthTierproperty);
                    var Data = JsonConvert.SerializeObject(objfourthTierbll.ViewAll());
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

        public ActionResult AddNew(int? id)
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string pagename = @"/" + controllerName + @"/" + actionName;
            var page = (List<LP_Pages_Property>)Session["PageList"];
            if (Session["LoggedIn"] != null && Helper.CheckPageAccess(pagename, page) && Session["ISADMIN"] != null)
            {
                objfourthTierproperty = new fourthTier_Property();
                //objBanlBLL = new Bank_BLL();
                //firstTier_Property headAccounts = new firstTier_Property() ;
                thirdTier_BLL headAccountBLL = new thirdTier_BLL();
                var data = headAccountBLL.ViewAll();
                objfourthTierproperty.headLST = Helper.ConvertDataTable<thirdTier_Property>(data);
                try
                {
                    if (id > 0)
                    {
                        objfourthTierproperty.idx = Convert.ToInt32(id);
                        objfourthTierbll = new fourthTier_BLL(objfourthTierproperty);
                        var dt = objfourthTierbll.GetfourthTierById();
                        objfourthTierproperty.subHeadIdx = int.Parse(dt.Rows[0]["subHeadIdx"].ToString());
                        objfourthTierproperty.childHeadName = dt.Rows[0]["childHeadName"].ToString();
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {

                }
                return PartialView("_AddNew", objfourthTierproperty);
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
        public JsonResult AddUpdate(fourthTier_Property objcomapnybank)
        {

            if (Session["LOGGEDIN"] != null)
            {
                try
                {
                    objfourthTierproperty = new fourthTier_Property();
                    objfourthTierproperty = objcomapnybank;
                    objfourthTierproperty.visible = 1;
                    objfourthTierproperty.createdByUserIdx = Convert.ToInt32(Session["UID"].ToString());
                    objfourthTierproperty.creationDate = DateTime.Now;
                    objfourthTierproperty.lastModifiedByUserIdx = Convert.ToInt32(Session["UID"].ToString());
                    objfourthTierproperty.lasModificationDate = DateTime.Now.ToString("yyyy-MM-dd");
                    objfourthTierbll = new fourthTier_BLL(objfourthTierproperty);

                    bool flag;
                    if (objcomapnybank.idx > 0)
                    {
                        //update
                        flag = objfourthTierbll.Update();
                        return Json(new { data = objcomapnybank, success = flag, msg = "Success", statuscode = 200, count = 0 }, JsonRequestBehavior.AllowGet);


                    }
                    else
                    {
                        //add
                        flag = objfourthTierbll.Insert();
                        return Json(new { data = objcomapnybank, success = flag, msg = "Success", statuscode = 200, count = 0 }, JsonRequestBehavior.AllowGet);

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
                    if (id > 0)
                    {

                        objfourthTierproperty = new fourthTier_Property();
                        objfourthTierproperty.idx = int.Parse(id.ToString());
                        //objDepartmentsBLL = new Departments_BLL(id);
                        objfourthTierbll = new fourthTier_BLL(objfourthTierproperty);

                        bool flag = objfourthTierbll.DeleteAccount();
                        return Json(new { data = "Deleted", success = flag, statuscode = 200 }, JsonRequestBehavior.AllowGet);



                    }
                    else
                    {
                        return Json(new { data = "Error Occur", success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
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
        public DataTable removeAssetsAndLiability(DataTable dt)
        {
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dt.Rows[i];
                if (dr["accountName"].ToString() == "Asset" || dr["accountName"].ToString() == "Liability")
                    dr.Delete();
            }
            dt.AcceptChanges();
            return dt;
        }
    }
}