using Newtonsoft.Json;
using SSS.BLL.Setups;
using SSS.Property.Setups;
using SSS.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSYSTEM.Controllers
{
    public class VendorBanksController : Controller
    {
        // GET: VendorBanks
        LP_VendorBanks_BLL objVendorBanksBLL;
        LP_VendorBanks_Property objVendorBanksProperty;
        public ActionResult ViewVendorBanks()
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

        public JsonResult GetAllVendorBanks()
        {

            if (Session["LOGGEDIN"] != null)
            {
                try
                {


                    objVendorBanksBLL = new LP_VendorBanks_BLL();
                    var Data = JsonConvert.SerializeObject(objVendorBanksBLL.ViewAll());
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

        

        public ActionResult AddNewVendorBank(int? id)
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string pagename = @"/" + controllerName + @"/" + actionName;
            var page = (List<LP_Pages_Property>)Session["PageList"];

            if (Session["LoggedIn"] != null && Helper.CheckPageAccess(pagename, page))
            {
                objVendorBanksProperty = new LP_VendorBanks_Property();
             
                Bank_BLL objBanlBLL = new Bank_BLL();
                Vendors_BLL objVendorBLL = new Vendors_BLL();
                objVendorBanksProperty.BankList = Helper.ConvertDataTable<Bank_Property>(objBanlBLL.ViewAll());
                objVendorBanksProperty.VendorList = Helper.ConvertDataTable<Vendors_Property>(objVendorBLL.ViewAll());
                if (id > 0)
                {
                    objVendorBanksProperty.idx = Convert.ToInt32(id);
                    objVendorBanksBLL = new LP_VendorBanks_BLL(objVendorBanksProperty);
                    DataTable dt = objVendorBanksBLL.SelectOne();
                    objVendorBanksProperty.bankIdx = int.Parse(dt.Rows[0]["bankIdx"].ToString());
                    objVendorBanksProperty.vendorIdx = int.Parse(dt.Rows[0]["vendorIdx"].ToString());
                    objVendorBanksProperty.accountTitle = dt.Rows[0]["accountTitle"].ToString();
                    objVendorBanksProperty.accountNumber = dt.Rows[0]["accountNumber"].ToString();
                    objVendorBanksProperty.ibanNumber = dt.Rows[0]["ibanNumber"].ToString();
                    return PartialView("AddNewVendorBank", objVendorBanksProperty);
                }
                else
                {
                    return PartialView("AddNewVendorBank", objVendorBanksProperty);
                }
           
                
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
        public JsonResult AddUpdate(LP_VendorBanks_Property objbank)
        {

            if (Session["LOGGEDIN"] != null)
            {
                try
                {  if (objbank.idx != 0)
                    {
                        objVendorBanksProperty = new LP_VendorBanks_Property();
                        objVendorBanksProperty = objbank;
                        objVendorBanksProperty.visible = 1;
                        objVendorBanksProperty.vendorIdx = objbank.vendorIdx;
                        objVendorBanksProperty.bankIdx = objbank.bankIdx;
                        objVendorBanksProperty.accountTitle = objbank.accountTitle;
                        objVendorBanksProperty.accountNumber = objbank.accountNumber;
                        objVendorBanksProperty.ibanNumber = objbank.ibanNumber;
                        objVendorBanksProperty.lastModifiedByUserIdx = Convert.ToInt32(Session["UID"].ToString());
                        objVendorBanksProperty.lastModificationDate = DateTime.Now.ToString("yyyy-MM-dd");

                        objVendorBanksBLL = new LP_VendorBanks_BLL(objVendorBanksProperty);


                        bool flag = objVendorBanksBLL.Update();
                        return Json(new { data = objVendorBanksProperty, success = flag, msg = "Success", statuscode = 200, count = 0 }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        objVendorBanksProperty = new LP_VendorBanks_Property();
                        objVendorBanksProperty = objbank;
                        objVendorBanksProperty.visible = 1;
                        objVendorBanksProperty.vendorIdx = objbank.vendorIdx;
                        objVendorBanksProperty.bankIdx = objbank.bankIdx;
                        objVendorBanksProperty.accountTitle = objbank.accountTitle;
                        objVendorBanksProperty.accountNumber = objbank.accountNumber;
                        objVendorBanksProperty.ibanNumber = objbank.ibanNumber;
                        objVendorBanksProperty.createdBy = Convert.ToInt32(Session["UID"].ToString());
                        objVendorBanksProperty.creationDate = DateTime.Now.ToString("yyyy-MM-dd");

                        objVendorBanksBLL = new LP_VendorBanks_BLL(objVendorBanksProperty);


                        bool flag = objVendorBanksBLL.Insert();
                        return Json(new { data = objVendorBanksProperty, success = flag, msg = "Success", statuscode = 200, count = 0 }, JsonRequestBehavior.AllowGet);

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
        public JsonResult DeleteBank(int? id)
        {
            try
            {
                if (id > 0)
                {

                    LP_VendorBanks_Property branchProperty = new LP_VendorBanks_Property();
                    branchProperty.idx = int.Parse(id.ToString());
                    objVendorBanksBLL = new LP_VendorBanks_BLL(branchProperty);
                   
                    var flag1 = objVendorBanksBLL.Delete(id);
                    //if (flag1.Rows.Count > 0)
                    //{

                    //bool flag = objCustomerTypeBLL.Delete(id);
                    return Json(new { data = "Deleted", success = flag1, statuscode = 200 }, JsonRequestBehavior.AllowGet);

                    //else
                    //{
                    //    return Json(new { data = "Mian Branch Cannot be Delete ", success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
                    //}

                    //}
                    // return Json(new { data = "Process Completed ", success = true, statuscode = 200 }, JsonRequestBehavior.AllowGet);


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
        
    }
}