using Newtonsoft.Json;
using SSS.BLL.Transactions;
using SSS.Property.Setups;
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
    public class PInvoiceController : BaseController
    {
        // GET: PInvoice
        LP_PI_ViewModel objPInvoiceVM;
        LP_P_Invoice_Property objPIProperty;
        LP_PInvoice_BLL objPIBLL;
        LP_Purchase_BLL objPurchaseBLL;
        LP_GRN_BLL objGRNBLL;

        public ActionResult ViewPI()
        {
            if (Session["LOGGEDIN"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult AddNewPI(int? id)
        {
            if (Session["LOGGEDIN"] != null)
            {
                objPInvoiceVM = new LP_PI_ViewModel();
                objPIBLL = new LP_PInvoice_BLL();
                objPurchaseBLL = new LP_Purchase_BLL();

                objPInvoiceVM.POLIST = Helper.ConvertDataTable<LP_Purchase_Master_Property>(objPurchaseBLL.SelectAll());
                objPInvoiceVM.TaxesList = Helper.ConvertDataTable<Taxes_Property>(GetAllTaxes());
                objPInvoiceVM.VendorList = Helper.ConvertDataTable<Vendors_Property>(Getvendors());
                objPInvoiceVM.ProductList = Helper.ConvertDataTable<Product_Property>(ViewAllProducts());
                objPInvoiceVM.BankList = Helper.ConvertDataTable<Company_Bank_Property>(GetAllCompanyBanks());
                //objGRNVM_Property.Doc_No = "GRN-001";
                if (id > 0)
                {
                    //update 
                    objPIProperty = new LP_P_Invoice_Property();
                    objPIProperty.idx =Convert.ToInt16(id);
                    objPIBLL = new LP_PInvoice_BLL(objPIProperty);
                    DataSet DS= objPIBLL.SelectByID();
                    objPInvoiceVM.InvoiceProperty = Helper.ConvertDataTable<LP_P_Invoice_Property>(DS.Tables[0]);
                    objPInvoiceVM.InvoiceDetails = Helper.ConvertDataTable<LP_P_Invoice_Details>(DS.Tables[1]);
                    objPInvoiceVM.PITAXLIST = Helper.ConvertDataTable<LP_PI_Taxes_Property>(DS.Tables[2]);

                    //
                    objPInvoiceVM.ParentDocID = objPInvoiceVM.InvoiceProperty[0].ParentDocID;
                    objPInvoiceVM.InvoiceNo = objPInvoiceVM.InvoiceProperty[0].InvoiceNo;
                    objPInvoiceVM.VendorID = objPInvoiceVM.InvoiceProperty[0].VendorID;
                    objPInvoiceVM.CreatedDate = objPInvoiceVM.InvoiceProperty[0].CreatedDate;
                    objPInvoiceVM.Reference = objPInvoiceVM.InvoiceProperty[0].Reference;
                    objPInvoiceVM.Description = objPInvoiceVM.InvoiceProperty[0].Description;
                    objPInvoiceVM.NetAmount = objPInvoiceVM.InvoiceProperty[0].NetAmount;
                    objPInvoiceVM.TotalAmount = objPInvoiceVM.InvoiceProperty[0].TotalAmount;
                    objPInvoiceVM.TaxAmount = objPInvoiceVM.InvoiceProperty[0].TaxAmount;
                    objPInvoiceVM.BalanceAmount = objPInvoiceVM.InvoiceProperty[0].BalanceAmount;
                    objPInvoiceVM.PaidAmount = objPInvoiceVM.InvoiceProperty[0].PaidAmount;
                    objPInvoiceVM.PaymentType = objPInvoiceVM.InvoiceProperty[0].PaymentType;
                    objPInvoiceVM.bankIdx = objPInvoiceVM.InvoiceProperty[0].BankId;
                    objPInvoiceVM.accorChequeNumber = objPInvoiceVM.InvoiceProperty[0].AccountChequeNo;
                    ViewBag.update = true;
                    
                    return PartialView("_AddNewPI", objPInvoiceVM);
                }
                else
                {
                    objPInvoiceVM.InvoiceProperty = Helper.ConvertDataTable<LP_P_Invoice_Property>(new DataTable());
                    objPInvoiceVM.InvoiceDetails = Helper.ConvertDataTable<LP_P_Invoice_Details>(new DataTable());
                    objPInvoiceVM.PITAXLIST = Helper.ConvertDataTable<LP_PI_Taxes_Property>(new DataTable());
                    LP_GenerateTransNumber_Property objtrans = new LP_GenerateTransNumber_Property();
                    objtrans.TableName = "P_Invoice";
                    objtrans.Identityfieldname = "idx";
                    objtrans.userid = Session["UID"].ToString();
                    objPInvoiceVM.InvoiceNo = objPIBLL.GeneratePINo(objtrans);
                    //objPInvoiceVM.CreatedDate =DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy"));
                    return PartialView("_AddNewPI", objPInvoiceVM);

                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }
        [HttpPost]
        public JsonResult AddUpdate(LP_PI_ViewModel objPI)
        {
            try
            {
                bool flag = false;
                if (objPI.idx > 0)
                {
                    //update
                }
                else
                {
                    //add
                    objPIProperty = new LP_P_Invoice_Property();
                    objPIProperty.InvoiceNo = objPI.InvoiceNo;
                    objPIProperty.InvoiceType = objPI.InvoiceType;
                    objPIProperty.IsPaid = objPI.IsPaid;
                    objPIProperty.NetAmount = objPI.NetAmount;
                    objPIProperty.PaidAmount = objPI.PaidAmount;
                    objPIProperty.BalanceAmount = objPI.BalanceAmount;
                    
                    objPIProperty.PaymentType = objPI.PaymentType;
                    objPIProperty.Status = objPI.Status;
                    objPIProperty.Taxable = objPI.Taxable;
                    objPIProperty.TotalAmount = objPI.TotalAmount;
                    objPIProperty.Description = objPI.Description;
                    objPIProperty.CreatedBy= Convert.ToInt16(Session["UID"].ToString());
                    objPIProperty.Description = objPI.Description;
                    objPIProperty.Reference = objPI.Reference;
                    objPIProperty.BankId = objPI.bankIdx;
                    objPIProperty.AccountChequeNo = objPI.accorChequeNumber;
                    objPIProperty.CreatedDate = DateTime.Now;
                    objPIProperty.Status = 0;
                    if (objPI.Description == null)
                    {
                        objPIProperty.Description = "";
                    }
                    else
                    {
                        objPIProperty.Description = objPI.Description;
                    }
                    if (objPI.PITAXLIST.Count() > 0)
                    {
                        objPIProperty.Taxable = true;
                    }
                    else
                    {
                        objPIProperty.Taxable = false;
                    }
                    //objPIProperty.Taxable= ((objPI.TaxesList.Count()>0)==true?true:false);
                    objPIProperty.VendorID = objPI.VendorID;
                    objPIProperty.ParentDocID = objPI.ParentDocID;
                    //tax
                    objPIProperty.TaxData = Helper.ToDataTable<LP_PI_Taxes_Property>(objPI.PITAXLIST);
                    objPIProperty.InvoiceDetails = Helper.ToDataTable<LP_P_Invoice_Details>(objPI.InvoiceDetails);

                    objPIBLL = new LP_PInvoice_BLL(objPIProperty);
                    flag = objPIBLL.Insert();

                }
                return Json(new { data = "", success = flag, msg = flag == true ? "Successfull" : "Failed", statuscode = flag == true ? 200 : 401 }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { data = ex.InnerException, success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetAllPI()
        {

            if (Session["LOGGEDIN"] != null)
            {
                try
                {


                    objPIBLL = new LP_PInvoice_BLL();
                    var Data = JsonConvert.SerializeObject(objPIBLL.SelectAll());
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

        public JsonResult SelectGRNById(int id)
        {
            if (Session["LOGGEDIN"] != null)
            {
                try
                {
                    LP_GRN_Master_Property objPurchaseProperty = new LP_GRN_Master_Property();
                    objPurchaseProperty.ID = id;

                    objGRNBLL = new LP_GRN_BLL(objPurchaseProperty);
                    var Data = JsonConvert.SerializeObject(objGRNBLL.SelectOne());
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

        public JsonResult SelectPOById(int id)
        {
            if (Session["LOGGEDIN"] != null)
            {
                try
                {
                    LP_GRN_Master_Property objPurchaseProperty = new LP_GRN_Master_Property();
                    objPurchaseProperty.ID = id;

                    objGRNBLL = new LP_GRN_BLL(objPurchaseProperty);

                    LP_Purchase_Master_Property objpurchase = new LP_Purchase_Master_Property();
                    objpurchase.idx = id;
                    objPurchaseBLL = new LP_Purchase_BLL(objpurchase);
                    var Data = JsonConvert.SerializeObject(objPurchaseBLL.SelectOne());
                    //var Data = JsonConvert.SerializeObject(objGRNBLL.SelectOne());
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