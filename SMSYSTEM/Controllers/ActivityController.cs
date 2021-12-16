using Newtonsoft.Json;
using SSS.BLL.Transactions;
using SSS.Property.Setups;
using SSS.Property.Transactions;
using SSS.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSYSTEM.Controllers
{
    public class ActivityController : BaseController
    {
        // GET: Activity
        #region Activity
        public ActionResult ViewActivity()
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string pagename = @"/" + controllerName + @"/" + actionName;
            var page = (List<LP_Pages_Property>)Session["PageList"];

            if (Session["LOGGEDIN"] != null && Helper.CheckPageAccess(pagename, page) && Session["ISADMIN"] != null)
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

        public JsonResult GetAllActivity()
        {
            var Data =JsonConvert.SerializeObject(GetAllActivityData());
            return Json(new {data=Data,success=true,code=200 },JsonRequestBehavior.AllowGet);
        }


        public ActionResult Activity(int? id)
        {   // GET: Payment
            LP_Activity_Property objActivityVM;
            LP_Activity_BLL objVoucherBll;
            LP_Voucher_Property objActivityMaster;

            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string pagename = @"/" + controllerName + @"/" + actionName;
            var page = (List<LP_Pages_Property>)Session["PageList"];

            if (Session["LOGGEDIN"] != null && Helper.CheckPageAccess(pagename, page) && Session["ISADMIN"] != null )
            {
                objActivityVM = new LP_Activity_Property();

              
                if (id > 0)
                {
                    objActivityVM = new LP_Activity_Property();
                    objActivityVM.orderIdx = Convert.ToInt32(id);
                 //   objActivityVM.idx = Convert.ToInt32(id);

                    objVoucherBll = new LP_Activity_BLL(objActivityVM);
                    objActivityVM.ActivityDetailLST= Helper.ConvertDataTable<LP_Activity_Property>(objVoucherBll.SelectAll());


                    objActivityVM.salesOrderLST = Helper.ConvertDataTable<LP_SalesOrder_Master_Property>(GetAllSalesInvoice());
                    objActivityVM.vendorCatLST = Helper.ConvertDataTable<Vendor_Category_Property>(GetAllVendorsCategory());
                    objActivityVM.productLST = Helper.ConvertDataTable<Product_Property>(ViewAllProducts());


                    objActivityVM.vendorIdx = objActivityVM.ActivityDetailLST[0].vendorIdx;
                    objActivityVM.vendorCatIdx = objActivityVM.ActivityDetailLST[0].vendorCatIdx;
                    objActivityVM.idx = objActivityVM.ActivityDetailLST[0].idx;
                    objActivityVM.activityPrice = objActivityVM.ActivityDetailLST[0].activityPrice;
                    // Added By Ahsan
                    objActivityVM.description = objActivityVM.ActivityDetailLST[0].description;
                    objActivityVM.reference = objActivityVM.ActivityDetailLST[0].reference;
                    objActivityVM.size = objActivityVM.ActivityDetailLST[0].size;
                    objActivityVM.qty = objActivityVM.ActivityDetailLST[0].qty;
                    objActivityVM.DeliveryDate = objActivityVM.ActivityDetailLST[0].DeliveryDate;
                    objActivityVM.orderIdx = objActivityVM.ActivityDetailLST[0].orderIdx;
                    objActivityVM.TotalPrice = objActivityVM.ActivityDetailLST[0].TotalPrice;

                    objActivityVM.typeIdx = objActivityVM.ActivityDetailLST[0].typeIdx;
                    objActivityVM.orderIdx = objActivityVM.ActivityDetailLST[0].orderIdx;
                    objActivityVM.vendorLST = Helper.ConvertDataTable<Vendors_Property>(GetVendorByVendorCat(objActivityVM.vendorCatIdx));
                    if (objActivityVM.ActivityDetailLST[0].typeIdx == 1)
                    {
                        objActivityVM.salesOrderLST = Helper.ConvertDataTable<LP_SalesOrder_Master_Property>(GetAllSalesInvoiceForDropDown());
                    }
                    else
                    {
                        DataTable dt = GetAllDisplayOrderForDropDown();
                        dt.Columns["doNumber"].ColumnName = "soNumber";
                        objActivityVM.salesOrderLST= Helper.ConvertDataTable<LP_SalesOrder_Master_Property>(dt);
                    }
                    ViewBag.update = 1;
                    //ViewBag.update = true;
                }
                else
                {
                    LP_Activity_BLL objbll = new LP_Activity_BLL();
                    objActivityVM.salesOrderLST = Helper.ConvertDataTable<LP_SalesOrder_Master_Property>(GetAllSalesInvoice());
                    objActivityVM.vendorCatLST = Helper.ConvertDataTable<Vendor_Category_Property>(GetAllVendorsCategory());
                    objActivityVM.ActivityDetailLST = new List<LP_Activity_Property>();
                    ViewBag.update = 0;
                }

                return View("Activity", objActivityVM);
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

        [HttpGet]
        public JsonResult SearchProductsInDetail(int Id)
        {
            try
            {
                LP_PInvoice_BLL objbll = new LP_PInvoice_BLL();
                //DataTable tblFiltered;
                if (Id != 0)
                {



                    var Data = Helper.ConvertDataTable<LP_SalesOrder_Detail_Property>(GetAllSalesInvoiceDetails(Id));//JsonConvert.SerializeObject(GetAllPIByDate(objsearchPI));
                    return Json(new { data = Data, success = true, statuscode = 200 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { data = "Error Occured", success = false, statuscode = 500 }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {

                return Json(new { data = "Session Expired", success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpGet]
        public JsonResult SearchProductsInDODetail(int Id)
        {
            try
            {
                LP_PInvoice_BLL objbll = new LP_PInvoice_BLL();
                //DataTable tblFiltered;
                if (Id != 0)
                {



                    var Data = Helper.ConvertDataTable<LP_DisplayOrder_Details_Property>(GetAllSalesInvoiceDODetails(Id));//JsonConvert.SerializeObject(GetAllPIByDate(objsearchPI));
                    return Json(new { data = Data, success = true, statuscode = 200 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { data = "Error Occured", success = false, statuscode = 500 }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {

                return Json(new { data = "Session Expired", success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpGet]
        public JsonResult SearchPrice(int id)
        {
            try
            {
                LP_Activity_BLL objbll = new LP_Activity_BLL(id);
                //DataTable tblFiltered;
                if (id != 0)
                {
                    
                    var Data = Helper.ConvertDataTable<Vendors_Property>(objbll.getVendorPrice(id));//JsonConvert.SerializeObject(GetAllPIByDate(objsearchPI));
                    return Json(new { data = Data, success = true, statuscode = 200 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { data = "Error Occured", success = false, statuscode = 500 }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {

                return Json(new { data = "Session Expired", success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult SearchVendorsOnCatIdx(int Id)
        {
            try
            {

                if (Id > 0)
                {
                    var Data = Helper.ConvertDataTable<Vendors_Property>(GetVendorByVendorCat(Id));//JsonConvert.SerializeObject(GetAllPIByDate(objsearchPI));
                    return Json(new { data = Data, success = true, statuscode = 200 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { data = "Error Occured", success = false, statuscode = 500 }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {

                return Json(new { data = "Session Expired", success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult AddUpdate(LP_Activity_Property objVoucher)
        {
            try
            {
                bool flag = false;
                if (objVoucher.idx > 0)
                {
                    LP_Activity_Property obj = new LP_Activity_Property();
                    obj.idx = objVoucher.idx;
                    obj.activityDate = DateTime.Now.ToString("yyyy-MM-dd");
                    obj.creationDate = DateTime.Now.ToString("yyyy-MM-dd");
                    obj.lastModificationDate = DateTime.Now.ToString("yyyy-MM-dd");
                    obj.createdBy = Convert.ToInt16(Session["UID"].ToString());
                    obj.lastModifiedByUserIdx = Convert.ToInt16(Session["UID"].ToString());
                    obj.typeIdx = objVoucher.typeIdx;
                    obj.orderIdx = objVoucher.orderIdx;
                    obj.productIdx = objVoucher.productIdx;
                    obj.vendorCatIdx = objVoucher.vendorCatIdx;
                    obj.vendorIdx = objVoucher.vendorIdx;
                    obj.size = objVoucher.size;
                    obj.qty = objVoucher.qty;
                    obj.activityPrice = objVoucher.activityPrice;
                    obj.description = objVoucher.description;
                    obj.reference = objVoucher.reference;
                    obj.DeliveryDate = DateTime.Now;
                    obj.TotalPrice = objVoucher.TotalPrice;
                    obj.DetailData = Helper.ToDataTable<LP_Activity_Property>(objVoucher.ActivityDetailLST);

                    LP_Activity_BLL objBLL = new LP_Activity_BLL(obj);

                    flag = objBLL.DeleteAndInsert();
                }
                else
                {
                    LP_Activity_Property obj = new LP_Activity_Property();
                    obj.idx = objVoucher.idx;
                    obj.activityDate = DateTime.Now.ToString("yyyy-MM-dd");
                    obj.creationDate = DateTime.Now.ToString("yyyy-MM-dd");
                    obj.createdBy = Convert.ToInt16(Session["UID"].ToString());
                    obj.typeIdx = objVoucher.typeIdx;
                    obj.orderIdx = objVoucher.orderIdx;
                    obj.productIdx = objVoucher.productIdx;
                    obj.vendorCatIdx = objVoucher.vendorCatIdx;
                    obj.vendorIdx = objVoucher.vendorIdx;
                    obj.size = objVoucher.size;
                    obj.qty = objVoucher.qty;
                    obj.activityPrice = objVoucher.activityPrice;
                    obj.description = objVoucher.description;
                    obj.reference = objVoucher.reference;
                    obj.DeliveryDate = DateTime.Now;
                    obj.Price = objVoucher.Price;
                    obj.TotalPrice = objVoucher.TotalPrice;
                
                    obj.DetailData = Helper.ToDataTable<LP_Activity_Property>(objVoucher.ActivityDetailLST);

                    LP_Activity_BLL objBLL = new LP_Activity_BLL(obj);

                    flag = objBLL.Insert();
                }
                if (flag)
                {
                    return Json(new { data = "Inserted", success = flag, msg = flag == true ? "Successfull" : "Success", statuscode = flag == true ? 200 : 401 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { data = "", success = flag, msg = flag == true ? "Failure" : "Failure", statuscode = flag == true ? 200 : 401 }, JsonRequestBehavior.AllowGet);
                }


            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public virtual JsonResult getSalesOrders()
        {

            var Data = Helper.ConvertDataTable<LP_SalesOrder_Master_Property>(GetAllSalesInvoiceForDropDown());
            return Json(new { data = Data, success = true, statuscode = 200 }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public virtual JsonResult getDisplayOrder()
        {
            var Data = Helper.ConvertDataTable<LP_DisplayOrder_Master_Property>(GetAllDisplayOrderForDropDown());
            return Json(new { data = Data, success = true, statuscode = 200 }, JsonRequestBehavior.AllowGet);
        }

        // Delete
        public JsonResult Delete(int? id)
        {
            if (Session["LOGGEDIN"] != null)
            {
                try
                {
                    LP_Activity_Property obj = new LP_Activity_Property();
                   
                    obj.idx = int.Parse(id.ToString());

                    LP_Activity_BLL objBLL = new LP_Activity_BLL(obj);
                    var flag1 = objBLL.Delete();
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
        #region Local Finish Good
        public ActionResult FinsihProducts(int? id)
        {  // GET: Payment

            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string pagename = @"/" + controllerName + @"/" + actionName;
            var page = (List<LP_Pages_Property>)Session["PageList"];
            if (Session["LoggedIn"] != null && Helper.CheckPageAccess(pagename, page) && Session["ISADMIN"] != null)
            {
                LP_FinsihProduct_Property objPInvoiceVM = new LP_FinsihProduct_Property();
                objPInvoiceVM.BranchList = Helper.ConvertDataTable<Branch_Property>(ViewAllBranches());
                objPInvoiceVM.WareHouseList = Helper.ConvertDataTable<WareHouse_Property>(ViewWareHouses());
                LP_FinishProduct_BLL objFPBLL = new LP_FinishProduct_BLL();
               

                objPInvoiceVM.salesOrderLST = Helper.ConvertDataTable<LP_SalesOrder_Master_Property>(objFPBLL.SelectAll());
                
                objPInvoiceVM.ProductLST = Helper.ConvertDataTable<Product_Property>(ViewAllProducts());
                

                if (id > 0)
                {
                    //update 


                    return View("FinsihProducts", objPInvoiceVM);
                }
                else
                {

                    return View("FinsihProducts", objPInvoiceVM);

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

        public JsonResult GetAllAcitvityBYOrderId(int id )
        {

            if (Session["LOGGEDIN"] != null)
            {
                try
                {


                    LP_FinishProduct_BLL objPIBLL = new LP_FinishProduct_BLL();
                    var Data = JsonConvert.SerializeObject(objPIBLL.SelectAllActivityOnSoNumber(id));
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

        [HttpPost]
        public JsonResult AddUpdateFP(LP_FinsihProduct_Property objPI)
        {
            try
            {
                bool flag = false;

                LP_FinsihProduct_Property obj = new LP_FinsihProduct_Property();

                //List<LP_FinsihProduct_Property> objlistfinishprdct = new List<LP_FinsihProduct_Property>();
                 obj.orderIdx = objPI.orderIdx;
                 obj.typeIdx = objPI.typeIdx;


                if (objPI.InventoryDetails.Count > 0)
                {

                    for (int i = 0; i < objPI.InventoryDetails.Count; i++)
                    {
                        obj.productIdx = objPI.InventoryDetails[i].productIdx;
                        obj.stock = objPI.InventoryDetails[i].stock;
                        obj.unitPrice = objPI.InventoryDetails[i].unitPrice;
                        obj.totalAmount = objPI.InventoryDetails[i].totalAmount;
                        obj.branchIdx = objPI.branchIdx;
                        obj.warehouseIdx = objPI.warehouseIdx;

                        //objlistfinishprdct.Add(obj);


                        obj.DetailData = Helper.ToDataTable<LP_InventoryLogs_Property>(objPI.InventoryDetails);
                        LP_FinishProduct_BLL objBLL = new LP_FinishProduct_BLL(obj);
                        flag = objBLL.Insert();
                    }

                    if (flag)
                    {
                        return Json(new { data = "Inserted", success = flag, msg = flag == true ? "Successfull" : "Success", statuscode = flag == true ? 200 : 401 }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { data = "", success = flag, msg = flag == true ? "Failure" : "Failure", statuscode = flag == true ? 200 : 401 }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { data = "", success = flag, msg = flag == true ? "Failure" : "Failure", statuscode = flag == true ? 200 : 401 }, JsonRequestBehavior.AllowGet);
                }
                //obj.activityDate = DateTime.Now.ToString("yyyy-MM-dd");
                //obj.creationDate = DateTime.Now.ToString("yyyy-MM-dd");
                //obj.createdBy = Convert.ToInt16(Session["UID"].ToString());
                //obj.orderIdx = objVoucher.orderIdx;
                //obj.productIdx = objVoucher.productIdx;
                //obj.vendorCatIdx = objVoucher.vendorCatIdx;
                //obj.vendorIdx = objVoucher.vendorIdx;
                //obj.size = objVoucher.size;
                //obj.qty = objVoucher.qty;
                //obj.activityPrice = objVoucher.activityPrice;
                //obj.description = objVoucher.description;
               


            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

    }
}