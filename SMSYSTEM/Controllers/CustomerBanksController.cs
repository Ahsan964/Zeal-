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
    public class CustomerBanksController : Controller
    {
        // GET: CustomerBanks
        LP_CustomerBanks_BLL objCustomerBanksBLL;
        LP_CustomerBanks_Property objCustomerBanksProperty;
        public ActionResult ViewCustomerBanks()
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

        public JsonResult GetAllCustomerBanks()
        {

            if (Session["LOGGEDIN"] != null)
            {
                try
                {


                    objCustomerBanksBLL = new LP_CustomerBanks_BLL();
                    var Data = JsonConvert.SerializeObject(objCustomerBanksBLL.ViewAll());
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



        public ActionResult AddNewCustomerBank(int? id)
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string pagename = @"/" + controllerName + @"/" + actionName;
            var page = (List<LP_Pages_Property>)Session["PageList"];
            if (Session["LoggedIn"] != null && Helper.CheckPageAccess(pagename, page) && Session["ISADMIN"] != null )
            {
                objCustomerBanksProperty = new LP_CustomerBanks_Property();

                Bank_BLL objBanlBLL = new Bank_BLL();
                Customers_BLL objVendorBLL = new Customers_BLL();
                objCustomerBanksProperty.BankList = Helper.ConvertDataTable<Bank_Property>(objBanlBLL.ViewAll());
                objCustomerBanksProperty.CustomerList = Helper.ConvertDataTable<Customers_Property>(objVendorBLL.ViewAllCustomers());
                if (id > 0)
                {
                    objCustomerBanksProperty.idx = Convert.ToInt32(id);
                    objCustomerBanksBLL = new LP_CustomerBanks_BLL(objCustomerBanksProperty);
                    DataTable dt = objCustomerBanksBLL.SelectOne();
                    objCustomerBanksProperty.bankIdx = int.Parse(dt.Rows[0]["bankIdx"].ToString());
                    objCustomerBanksProperty.customerIdx = int.Parse(dt.Rows[0]["customerIdx"].ToString());
                    objCustomerBanksProperty.accountTitle = dt.Rows[0]["accountTitle"].ToString();
                    objCustomerBanksProperty.accountNumber = dt.Rows[0]["accountNumber"].ToString();
                    objCustomerBanksProperty.ibanNumber = dt.Rows[0]["ibanNumber"].ToString();
                    return PartialView("AddNewCustomerBank", objCustomerBanksProperty);
                }
                else
                {
                    return PartialView("AddNewCustomerBank", objCustomerBanksProperty);
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
        public JsonResult AddUpdate(LP_CustomerBanks_Property objbank)
        {

            if (Session["LOGGEDIN"] != null)
            {
                try
                {
                    if (objbank.idx != 0)
                    {
                        objCustomerBanksProperty = new LP_CustomerBanks_Property();
                        objCustomerBanksProperty = objbank;
                        objCustomerBanksProperty.visible = 1;
                        objCustomerBanksProperty.customerIdx = objbank.customerIdx;
                        objCustomerBanksProperty.bankIdx = objbank.bankIdx;
                        objCustomerBanksProperty.accountTitle = objbank.accountTitle;
                        objCustomerBanksProperty.accountNumber = objbank.accountNumber;
                        objCustomerBanksProperty.ibanNumber = objbank.ibanNumber;
                        objCustomerBanksProperty.lastModifiedByUserIdx = Convert.ToInt32(Session["UID"].ToString());
                        objCustomerBanksProperty.lastModificationDate = DateTime.Now.ToString("yyyy-MM-dd");

                        objCustomerBanksBLL = new LP_CustomerBanks_BLL(objCustomerBanksProperty);


                        bool flag = objCustomerBanksBLL.Update();
                        return Json(new { data = objCustomerBanksProperty, success = flag, msg = "Success", statuscode = 200, count = 0 }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        objCustomerBanksProperty = new LP_CustomerBanks_Property();
                        objCustomerBanksProperty = objbank;
                        objCustomerBanksProperty.visible = 1;
                        objCustomerBanksProperty.customerIdx = objbank.customerIdx;
                        objCustomerBanksProperty.bankIdx = objbank.bankIdx;
                        objCustomerBanksProperty.accountTitle = objbank.accountTitle;
                        objCustomerBanksProperty.accountNumber = objbank.accountNumber;
                        objCustomerBanksProperty.ibanNumber = objbank.ibanNumber;
                        objCustomerBanksProperty.createdBy = Convert.ToInt32(Session["UID"].ToString());
                        objCustomerBanksProperty.creationDate = DateTime.Now.ToString("yyyy-MM-dd");

                        objCustomerBanksBLL = new LP_CustomerBanks_BLL(objCustomerBanksProperty);


                        bool flag = objCustomerBanksBLL.Insert();
                        return Json(new { data = objCustomerBanksProperty, success = flag, msg = "Success", statuscode = 200, count = 0 }, JsonRequestBehavior.AllowGet);

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

                    LP_CustomerBanks_Property branchProperty = new LP_CustomerBanks_Property();
                    branchProperty.idx = int.Parse(id.ToString());
                    objCustomerBanksBLL = new LP_CustomerBanks_BLL(branchProperty);

                    var flag1 = objCustomerBanksBLL.Delete(id);
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