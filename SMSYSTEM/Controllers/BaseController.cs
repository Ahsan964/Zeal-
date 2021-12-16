using CrystalDecisions.CrystalReports.Engine;
using Newtonsoft.Json;
using SSS.BLL.Report;
using SSS.BLL.Setups;
using SSS.BLL.Setups.Accounts;
using SSS.BLL.Setups.Reporting;
using SSS.BLL.Transactions;
using SSS.Property.Report;
using SSS.Property.Setups;
using SSS.Property.Setups.Accounts;
using SSS.Property.Setups.Reports;
using SSS.Property.Transactions;
using SSS.Property.Transactions.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSYSTEM.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        LP_Purchase_Type_BLL objpurchasetypebll;
        Product_BLL objProduct;
        public DataTable GetAllPurchaseType()
        {
            objpurchasetypebll = new LP_Purchase_Type_BLL();
            return objpurchasetypebll.SelectAll();
        }
        public DataTable ViewAllProducts()
        {
            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                    Product_Property objProductProperty = new Product_Property();
                    //objProductProperty.branchIdx = 1;//user logged in session branchIdx
                    Product_BLL objProductBLL = new Product_BLL(objProductProperty);
                    return objProductBLL.ViewAll();

                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }

        }
        public DataTable GetAllTaxes()
        {
            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                    Taxes_BLL objTaxes = new Taxes_BLL();

                    return objTaxes.ViewAll();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }
        }
        public DataTable GetChildAccountsByheadIdx(int id)
        {
            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                    fourthTier_Property ObjCustomer_Property = new fourthTier_Property();
                    fourthTier_BLL objvendorbll = new fourthTier_BLL(ObjCustomer_Property);
                    ObjCustomer_Property.idx = id;//send subheadIdx in id
                    return objvendorbll.GetfourthTierByheadIdx();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }
        }
        public DataTable GetAllCompanyBanks()
        {
            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                    CompanyBank_BLL objcompanybll = new CompanyBank_BLL();

                    return objcompanybll.ViewAll();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }
        }
        public DataTable GetCompanyBankById(int id)
        {
            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                    CompanyBank_Property objcompany = new CompanyBank_Property();
                    objcompany.idx = id;
                    CompanyBank_BLL objcompanybll = new CompanyBank_BLL(objcompany);

                    return objcompanybll.SelectOne();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }
        }
        public DataTable GetAllTransactionType()
        {
            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                    LP_Transaction_Type_BLL objtransactiontypebll = new LP_Transaction_Type_BLL();

                    return objtransactiontypebll.SelectAll();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }
        }
        public DataTable GetAllPIByDate(LP_Voucher_ViewModel objvchr)
        {

            if (Session["LOGGEDIN"] != null)
            {
                try
                {


                    LP_PInvoice_BLL objPIBLL = new LP_PInvoice_BLL();

                    return objPIBLL.SelectPIByDate(objvchr);
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }

        }
        public DataTable GetAllSalesInvoiceForDropDown()
        {
            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                    LP_SalesOrder_Master_Property objProperty = new LP_SalesOrder_Master_Property();
                    LP_SalesOrder_BLL objvendorcatbll = new LP_SalesOrder_BLL();

                    return objvendorcatbll.SelectAllForDDL();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }
        }
        public DataTable GetAllSalesInvoice()
        {
            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                    LP_SalesOrder_Master_Property objProperty = new LP_SalesOrder_Master_Property();
                    LP_SalesOrder_BLL objvendorcatbll = new LP_SalesOrder_BLL();

                    return objvendorcatbll.SelectAll();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }
        }
        public DataTable GetAllDisplayOrderForDropDown()
        {
            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                    LP_DisplayOrder_Master_Property objProperty = new LP_DisplayOrder_Master_Property();
                    LP_DisplayOrder_BLL objvendorcatbll = new LP_DisplayOrder_BLL();

                    return objvendorcatbll.SelectAllForDDL();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }
        }
        public DataTable GetAllSalesInvoiceDetails(int id)
        {
            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                    LP_SalesOrder_Master_Property objProperty = new LP_SalesOrder_Master_Property();
                    LP_SalesOrder_BLL objvendorcatbll = new LP_SalesOrder_BLL();

                    return objvendorcatbll.SelectAllSalesInvoiceDetails(id);
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }
        }
        public DataTable GetAllSalesInvoiceDODetails(int id)
        {
            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                    LP_DisplayOrder_Master_Property objProperty = new LP_DisplayOrder_Master_Property();
                    LP_DisplayOrder_BLL objvendorcatbll = new LP_DisplayOrder_BLL();

                    return objvendorcatbll.SelectAllSalesInvoiceDODetails(id);
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }
        }
        public DataTable GetAllSIByDate(LP_Voucher_ViewModel objvchr)
        {

            if (Session["LOGGEDIN"] != null)
            {
                try
                {


                    LP_SalesOrder_BLL objPIBLL = new LP_SalesOrder_BLL();

                    return objPIBLL.SelectSIByDate(objvchr);
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }

        }
        public DataTable GetAllVendorsCategory()
        {
            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                    Vendor_Category_Property objProperty = new Vendor_Category_Property();
                    Vendor_Category_BLL objvendorcatbll = new Vendor_Category_BLL(objProperty);

                    return objvendorcatbll.ViewAll();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }
        }

        public DataTable Getvendors()
        {
            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                    Vendors_BLL objvendorbll = new Vendors_BLL();

                    return objvendorbll.ViewAll();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }
        }
        public DataTable GetVendorById(int id)
        {
            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                    Vendors_BLL objvendorbll = new Vendors_BLL();

                    return objvendorbll.GetById(id);
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }
        }
        public DataTable GetAllCustomers()
        {
            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                    Customers_BLL objvendorbll = new Customers_BLL();

                    return objvendorbll.ViewAllCustomers();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }
        }
        public DataTable GetVendorByVendorCat(int id)
        {
            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                    Vendors_BLL objvendorbll = new Vendors_BLL();

                    return objvendorbll.GetByCatId(id);
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }
        }
        public DataTable GetCustomerByID(int id)
        {
            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                    Customers_Property ObjCustomer_Property = new Customers_Property();
                    ObjCustomer_Property.idx = id;
                    Customers_BLL objvendorbll = new Customers_BLL(ObjCustomer_Property);

                    return objvendorbll.GetCustomerById();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }
        }
        public DataTable GetChildAccountsBySubheadIdx(int id)
        {
            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                    fourthTier_Property ObjCustomer_Property = new fourthTier_Property();
                    fourthTier_BLL objvendorbll = new fourthTier_BLL(ObjCustomer_Property);
                    ObjCustomer_Property.idx = id;//send subheadIdx in id
                    return objvendorbll.GetfourthTierBySubheadIdx();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }
        }
        public DataTable GetAllDepartments()
        {
            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                    Departments_BLL objDepartment = new Departments_BLL();

                    return objDepartment.ViewAll();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }
        }
        public DataTable GetAllStockAndPriceBranchWise(SalesOrderVM_Property objSale)
        {
            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                    LP_SalesOrder_BLL objSalesOrder = new LP_SalesOrder_BLL();

                    return objSalesOrder.GetStockandPriceBranchWise(objSale);
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }
        }

        public DataTable GetAllStockAndPrice(int productid)
        {
            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                    LP_SalesOrder_BLL objSalesOrder = new LP_SalesOrder_BLL();

                    return objSalesOrder.GetStockandPrice(productid);
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }
        }
        //public DataTable GetAllHSCodes()
        //{
        //    objProduct = new Product_BLL();
        //    return objProduct.ViewAll();
        //}
        public DataTable ViewAllProduct()
        {
            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                    Product_Property objProductProperty = new Product_Property();
                    //objProductProperty.branchIdx = 1;//user logged in session branchIdx
                    Product_BLL objProductBLL = new Product_BLL(objProductProperty);
                    return objProductBLL.ViewAll();


                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }

        }
        public DataTable ViewAllBranches()
        {
            if (Session["LOGGEDIN"] != null)
            {
                try
                {
                    Branch_Property objBranchProperty = new Branch_Property();
                    Branch_BLL objBranch = new Branch_BLL(objBranchProperty);
                    return objBranch.ViewAll();

                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }

        }

        [HttpPost]
        public DataTable GetAllSalesDetailsByIdx(int salesInvoiceIdx)
        {

            if (Session["LOGGEDIN"] != null)
            {
                try
                {


                    LP_SalesOrder_BLL objPIBLL = new LP_SalesOrder_BLL();

                    return objPIBLL.SelectSalesForSalesReturn(salesInvoiceIdx);
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }

        }


        public DataTable CheckProductInInventory(int salesInvoiceIdx)
        {

            if (Session["LOGGEDIN"] != null)
            {
                try
                {


                    LP_SalesOrder_BLL objPIBLL = new LP_SalesOrder_BLL();

                    return objPIBLL.CheckProductInInventory(salesInvoiceIdx);
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }

        }
        public DataTable GetInventoryInfo(LP_Inv_Report objrprtparam)

        {
            try
            {
                LP_Inventory_BLL objLP_Inventory_BLL = new LP_Inventory_BLL(objrprtparam);
                return objLP_Inventory_BLL.GetInventoryReport().Tables[0];


            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        #region WareHouse
        //public DataTable ViewWareHouses()
        //{
        //    if (Session["LOGGEDIN"] != null)
        //    {

        //        try
        //        {
        //            WareHouse_Property objproperty = new WareHouse_Property();
        //            objproperty.BranchIdx = Convert.ToInt32(Session["BRANCHID"].ToString());//user logged in session branchIdx
        //            WareHouse_BLL objBLL = new WareHouse_BLL(objproperty);
        //            return objBLL.SelectOne();


        //        }
        //        catch (Exception ex)
        //        {
        //            return new DataTable();
        //        }
        //    }
        //    else
        //    {
        //        return new DataTable();
        //    }

        //}

        public DataTable ViewWareHouses()
        {
            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                    WareHouse_Property objproperty = new WareHouse_Property();
                    objproperty.BranchIdx = Convert.ToInt32(Session["BRANCHID"].ToString());//user logged in session branchIdx
                    WareHouse_BLL objBLL = new WareHouse_BLL(objproperty);
                    return objBLL.SelectOne();


                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }

        }

        #endregion

        #region Activity

        public DataTable GetAllActivityData()
        {
            try
            {
                LP_Activity_BLL objbll = new LP_Activity_BLL(new LP_Activity_Property());
                return objbll.SelectAll();
            }
            catch (Exception ex)
            {
                using (var tw = new StreamWriter(Server.MapPath("/Reports/Error.txt"), true))
                {
                    tw.Write(ex.InnerException + DateTime.Now.ToString());
                }
                return new DataTable();
            }
        }

        #endregion

        #region Report
        public DataTable GetRecieptData(int? id, int? query)

        {
            try
            {
                Invoice_BLL objBLL = new Invoice_BLL();
                return objBLL.GenerateReport(id, query);
                // return new DataTable();


            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }


        public JsonResult GenerateReport(int? id, int? query, string ReportName)
        {
            try
            {
                DataTable dt = GetRecieptData(id, query);
                string datetime = DateTime.Now.ToFileTimeUtc().ToString();

                //List<Customer> allCustomer = new List<Customer>();
                //allCustomer = context.Customers.ToList();
                if (query == 1)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        dt.Rows[i]["drivername"] = Session["driver"].ToString();
                        dt.Rows[i]["Vehicle_number"] = Session["vhcl"].ToString();
                    }


                }

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), ReportName + ".rpt"));

                // rd.SetDatabaseLogon("sa", "leaptech#0");
                rd.SetDataSource(dt);

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();


                rd.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Path.Combine(Server.MapPath("~/Reports"), ReportName + datetime + ".Pdf"));
                //stream.Seek(0, SeekOrigin.Begin);
                //return File(stream, "application/pdf", "CustomerList.pdf");
                return Json(new { data = "/Reports/" + ReportName + datetime + ".Pdf", success = true, msg = "Successfull", statuscode = 200 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                using (var tw = new StreamWriter(Server.MapPath("/Reports/" + "Error.txt"), true))
                {
                    tw.WriteLine(DateTime.Now);
                    tw.WriteLine(ex.Message);
                    tw.WriteLine(ex.InnerException);
                    tw.WriteLine(ex);
                    tw.WriteLine(DateTime.Now);
                }
                return Json(new { data = "/Reports/MRNReport.Pdf", success = false, msg = "Failed", statuscode = 400 }, JsonRequestBehavior.AllowGet);

            }

        }
        public JsonResult SelectReportData(LP_Report_Property objreportprprty)
        {
            try
            {
                LP_Reporting_BLL objrprtbll = new LP_Reporting_BLL(objreportprprty);
                DataTable dt = objrprtbll.SelectReportData();
                string datetime = DateTime.Now.ToFileTimeUtc().ToString();
                string ReportName = objreportprprty.ReportName;
                //List<Customer> allCustomer = new List<Customer>();
                //allCustomer = context.Customers.ToList();
                if (objreportprprty.ReportID == 1)
                {




                }

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), ReportName + ".rpt"));

                // rd.SetDatabaseLogon("sa", "leaptech#0");
                rd.SetDataSource(dt);

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();


                rd.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Path.Combine(Server.MapPath("~/Reports"), ReportName + datetime + ".Pdf"));
                //stream.Seek(0, SeekOrigin.Begin);
                //return File(stream, "application/pdf", "CustomerList.pdf");
                return Json(new { data = "/Reports/" + ReportName + datetime + ".Pdf", success = true, msg = "Successfull", statuscode = 200 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                using (StreamWriter tr = new StreamWriter(Server.MapPath("/Reports/Error.txt"), true))
                {
                    tr.WriteLine("Exception at level Reporting Controller ADDUpdate Start" + DateTime.Now);
                    tr.WriteLine("Exception at level Reporting Controller ADDUpdate " + ex.InnerException + DateTime.Now);

                    tr.WriteLine("Exception at level Reporting Controller ADDUpdate " + ex.Message + DateTime.Now);
                    tr.WriteLine("Exception at level Reporting Controller ADDUpdate End" + DateTime.Now);
                }
                return Json(new { data = "/Reports/MRNReport.Pdf", success = false, msg = "Failed", statuscode = 400 }, JsonRequestBehavior.AllowGet);

            }




        }

        #endregion

        #region PictureSaving

        public string[] SavePicture(HttpPostedFileWrapper[] pics)
        {
            string[] profilepath = new string[pics.Length];
            try
            {
                if (pics.Length > 0)
                {
                    for (int i = 0; i < pics.Length; i++)
                    {
                        string filename = System.IO.Path.GetRandomFileName().Replace(".", "") + pics[0].FileName;

                        pics[i].SaveAs(Server.MapPath("/Product_Picture/" + filename));
                        profilepath[i] = "/Product_Picture/" + filename;
                    }
                }
                return profilepath;

            }
            catch (Exception ex)
            {
                return profilepath;
            }

        }



        #endregion
    }
}
