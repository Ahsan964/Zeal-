using Newtonsoft.Json;
using SSS.BLL.Transactions;
using SSS.Property.Setups;
using SSS.Property.Setups.Accounts;
using SSS.Property.Transactions;
using SSS.Property.Transactions.ViewModels;
using SSS.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSYSTEM.Controllers
{
    public class ReceiptController : BaseController
    {
        // GET: Receipt
        LP_Voucher_ViewModel objvoucherVM;
        LP_Voucher_BLL objVoucherBll;
        LP_Voucher_Property objvouchermaster;
        public ActionResult Receipts()
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
        public JsonResult GetAllReceiptVoucher()
        {
            try
            {
                objvouchermaster = new LP_Voucher_Property();
                objVoucherBll = new LP_Voucher_BLL(objvouchermaster);

                var Data = JsonConvert.SerializeObject(objVoucherBll.SelectAllReceiptVoucher());
                return Json(new { data = Data, success = true, statuscode = 200, count = Data.Length }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }
        }


        #region Add Voucher
        public ActionResult AddReceipt(int? id)
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string pagename = @"/" + controllerName + @"/" + actionName;
            var page = (List<LP_Pages_Property>)Session["PageList"];
            if (Session["LoggedIn"] != null && Helper.CheckPageAccess(pagename, page) && Session["ISADMIN"] != null)
            {
                // Added By Ahsan
                objvoucherVM = new LP_Voucher_ViewModel();
                objvoucherVM.BranchList = Helper.ConvertDataTable<Branch_Property>(ViewAllBranches());

                objvoucherVM.idx = Convert.ToInt32(id);
                if (objvoucherVM.idx > 0)
                {
                    objvoucherVM.BankList = Helper.ConvertDataTable<Company_Bank_Property>(GetAllCompanyBanks());
                    objvoucherVM.customerlist = Helper.ConvertDataTable<Customers_Property>(GetAllCustomers());

                    objvouchermaster = new LP_Voucher_Property();
                    objvouchermaster.idx = Convert.ToInt32(id);
                    objVoucherBll = new LP_Voucher_BLL(objvouchermaster);
                    DataTable dt = objVoucherBll.SelectOneReceiptVoucher();

                    objvoucherVM.idx = Convert.ToInt16(dt.Rows[0]["idxx"].ToString());
                    objvoucherVM.voucher_no = dt.Rows[0]["invoiceNoIdx"].ToString();
                    objvoucherVM.date_created = Convert.ToDateTime(dt.Rows[0]["dated"].ToString());
                   // objvoucherVM.reference = dt.Rows[0]["reference"].ToString();
                    objvoucherVM.customer_id = Convert.ToInt16(dt.Rows[0]["customerIdx"].ToString());
                    //objvoucherVM.paidAmount = Convert.ToDecimal(dt.Rows[0]["paidAmount"].ToString());
                    
                    //objvouchermaster.customer_id = objvoucherVM.customer_id;
                    //objVoucherBll = new LP_Voucher_BLL(objvouchermaster);
                    //DataTable dt = objVoucherBll.SelectOneSalesInvoice();
                    //var Data = Helper.ConvertDataTable<LP_SalesOrder_Master_Property>(GetAllSIByDate(objvoucherVM.customer_id));//JsonConvert.SerializeObject(GetAllPIByDate(objsearchPI));

                    objvoucherVM.AccountGJLST = Helper.ConvertDataTable<AccountGJ>(dt);
                }
                else
                {
                    objvoucherVM.date_created = DateTime.Now;
                    //objvoucherVM.vouchertypelist = Helper.ConvertDataTable<LP_Transaction_Type_Property>(GetAllTransactionType());
                    objvoucherVM.voucher_amount = 0.00m;
                    objvoucherVM.description = "";
                    objvoucherVM.BankList = Helper.ConvertDataTable<Company_Bank_Property>(GetAllCompanyBanks());
                    objvoucherVM.customerlist = Helper.ConvertDataTable<Customers_Property>(GetAllCustomers());

                    LP_GenerateTransNumber_Property objtransnumber = new LP_GenerateTransNumber_Property();
                    objtransnumber.TableName = "accountMasterGL";
                    objtransnumber.Identityfieldname = "idxx";
                    objtransnumber.userid = Session["UID"].ToString();
                    objtransnumber.tranTypeIdx = "5";//for Receipt
                    objVoucherBll = new LP_Voucher_BLL();
                    objvoucherVM.voucher_no = objVoucherBll.GenerateTransNo(objtransnumber);

                }

                return View("_AddReceipt", objvoucherVM);
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

        public JsonResult AddUpdate(LP_Voucher_ViewModel objVoucher)
        {
            try
            {
                bool flag = false;
                objvouchermaster = new LP_Voucher_Property();
                objvouchermaster.idx = objVoucher.idx;
                objvouchermaster.voucher_no = objVoucher.voucher_no;
                objvouchermaster.customer_id = objVoucher.customer_id;
                objvouchermaster.branchIdx = objVoucher.branchIdx;
                //objvouchermaster.voucher_type = objVoucher.voucher_type;
                objvouchermaster.date_created = objVoucher.date_created.ToString("yyyy-MM-dd");
                if (objVoucher.description != null)
                {
                    objvouchermaster.description = objVoucher.description;
                }
                else
                {
                    objvouchermaster.description = "";
                }
                // objMRNProperty.description = objMRN.description.Length>0? objMRN.description : "";

                //  objMRNProperty.paidDate = ;// objMRN.paidDate;

                
                if (objVoucher.idx > 0)
                {
                    objvouchermaster.status = 0;
                    objvouchermaster.accorChequeNumber = objVoucher.accorChequeNumber;
                    objvouchermaster.bankIdx = objVoucher.bankIdx;
                    objvouchermaster.paymentModeIdx = objVoucher.paymentModeIdx;
                    objvouchermaster.voucher_amount = objVoucher.voucher_amount;
                    objvouchermaster.DetailData = Helper.ToDataTable<AccountGJ>(objVoucher.AccountGJLST);
                    objvouchermaster.u_id = Convert.ToInt16(Session["UID"].ToString());

                    objvouchermaster.TableName = "accountGJ";
                    objVoucherBll = new LP_Voucher_BLL(objvouchermaster);
                    flag = objVoucherBll.InsertReceipt();
                    //update
                }
                else
                {
                    //add

                    objvouchermaster.status = 0;
                    objvouchermaster.accorChequeNumber = objVoucher.accorChequeNumber;
                    objvouchermaster.bankIdx = objVoucher.bankIdx;
                    objvouchermaster.paymentModeIdx = objVoucher.paymentModeIdx;
                    objvouchermaster.voucher_amount = objVoucher.voucher_amount;
                    objvouchermaster.DetailData = Helper.ToDataTable<AccountGJ>(objVoucher.AccountGJLST);
                    objvouchermaster.u_id = Convert.ToInt16(Session["UID"].ToString());

                    objvouchermaster.TableName = "accountGJ";
                    objVoucherBll = new LP_Voucher_BLL(objvouchermaster);
                    flag = objVoucherBll.InsertReceipt();

                }
                return Json(new { data = "", success = flag, msg = flag == true ? "Successfull" : "Failed", statuscode = flag == true ? 200 : 401 }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult SearchSaleInvoice(LP_Voucher_ViewModel objsearchPI)
        {
            if (Session["LOGGEDIN"] != null)
            {
                try
                {
                    //DataTable Data = GetAllPIByDate(objsearchPI);
                    var Data = Helper.ConvertDataTable<LP_SalesOrder_Master_Property>(GetAllSIByDate(objsearchPI));//JsonConvert.SerializeObject(GetAllPIByDate(objsearchPI));
                    return Json(new { data = Data, success = true, statuscode = 200 }, JsonRequestBehavior.AllowGet);

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

        public JsonResult getCustomerBalance(int id)
        {
            try
            {
                objvoucherVM = new LP_Voucher_ViewModel();
                LP_Voucher_BLL objBLL = new LP_Voucher_BLL();
                var Data = JsonConvert.SerializeObject(objBLL.getcustomerInvoices(id));
                return Json(new { data = Data, success = true, statuscode = 200, count = Data.Length }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }
        }

        // Added By Ahsan
        public JsonResult getCustomerPaidAmount(int id)
        {
            try
            {
                objvoucherVM = new LP_Voucher_ViewModel();
                LP_Voucher_BLL objBLL = new LP_Voucher_BLL();
                var Data = JsonConvert.SerializeObject(objBLL.getcustomerPaidAmount(id));
                return Json(new { data = Data, success = true, statuscode = 200, count = Data.Length }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Delete(int? id)
        {
            if (Session["LOGGEDIN"] != null)
            {
                try
                {
                    objvouchermaster = new LP_Voucher_Property();
                    objvouchermaster.idx = int.Parse(id.ToString());

                    LP_Voucher_BLL obj = new LP_Voucher_BLL(objvouchermaster);
                    var flag1 = obj.DeleteReceipt();
                    if (flag1)
                    {
                        return Json(new { data = "Deleted", success = flag1, statuscode = 200 }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { data = "Error", success = flag1, statuscode = 200 }, JsonRequestBehavior.DenyGet);
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
        #endregion
    }
}