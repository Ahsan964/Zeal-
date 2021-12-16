using CrystalDecisions.CrystalReports.Engine;
using Newtonsoft.Json;
using SSS.BLL.Report;
using SSS.Property.Report;
using SSS.Property.Setups;
using SSS.Property.Transactions;
using SSS.Property.Transactions.ViewModels;
using SSS.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSYSTEM.Controllers
{
    public class InventoryController : BaseController
    {
        // GET: Inventory
        LP_Inventory_BLL objLP_Inventory_BLL;
        public ActionResult ViewInventory()
        {
            LP_Inv_Report objinvrprt = new LP_Inv_Report();
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string pagename = @"/" + controllerName + @"/" + actionName;
            var page = (List<LP_Pages_Property>)Session["PageList"];

            if (Session["LoggedIn"] != null && Helper.CheckPageAccess(pagename, page))
            {
                objinvrprt.BranchList = Helper.ConvertDataTable<Branch_Property>(ViewAllBranches());
                objinvrprt.ProductList = Helper.ConvertDataTable<Product_Property>(ViewAllProduct());
                return View(objinvrprt);
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

        public JsonResult SelectAllInventory()

        {
            if (Session["LOGGEDIN"] != null)
            {
                try
                {

                    objLP_Inventory_BLL = new LP_Inventory_BLL();
                    var Data = JsonConvert.SerializeObject(objLP_Inventory_BLL.SelectAll());
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
        public JsonResult GenerateDetailReport(LP_Inv_Report objrprtparam)

        {
            try
            {
                objLP_Inventory_BLL = new LP_Inventory_BLL(objrprtparam);
                DataTable dt = objLP_Inventory_BLL.GetInventoryReport().Tables[0];

                //List<Customer> allCustomer = new List<Customer>();
                //allCustomer = context.Customers.ToList();


                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "InventoryReport.rpt"));

                rd.SetDataSource(dt);

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();


                rd.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Path.Combine(Server.MapPath("~/Reports"), "InventoryReport.Pdf"));
                //stream.Seek(0, SeekOrigin.Begin);
                //return File(stream, "application/pdf", "CustomerList.pdf");
                return Json(new { data = "/Reports/InventoryReport.Pdf", success = true, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { data = "/Reports/InventoryReport.Pdf", success = true, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);

            }
        }

        [HttpPost]
        public new JsonResult GetInventoryInfo(LP_Inv_Report objrprtparam)
        {
            if (Session["LOGGEDIN"] != null)
            {
                try
                {
                    string stock = base.GetInventoryInfo(objrprtparam).Compute("SUM(stock)", string.Empty).ToString();


                    return Json(new { data = stock, success = true, statuscode = 200, count = stock }, JsonRequestBehavior.AllowGet);

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

        public FileResult Download(string fpath)
        {

            string fullName = Server.MapPath("~" + fpath);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullName);
            string fileName = Path.GetFileName(fullName);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }



        #region Iventory Moment

        public ActionResult InventoryMovement()
        {
            //LP_Inventory_Movement objinvrprt = new LP_Inventory_Movement();
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string pagename = @"/" + controllerName + @"/" + actionName;
            var page = (List<LP_Pages_Property>)Session["PageList"];
            if (Session["LoggedIn"] != null && Helper.CheckPageAccess(pagename, page) && Session["ISADMIN"] != null )
            {
                LP_Inventory_Movement objinvrprt = new LP_Inventory_Movement();
                objinvrprt.BranchList = Helper.ConvertDataTable<Branch_Property>(ViewAllBranches());
                objinvrprt.ProductList = Helper.ConvertDataTable<Product_Property>(ViewAllProduct());
                objinvrprt.WareHouseList = Helper.ConvertDataTable<WareHouse_Property>(ViewWareHouses());
                return View(objinvrprt);
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
        public JsonResult TransferInventory(LP_Inventory_Movement objINV)

        {
            try
            {
                objINV.TransactionType = 12;
                objINV.Useridx = Convert.ToInt32(Session["UID"].ToString());
                objINV.DateCreated = DateTime.Now;
                objINV.DetailData = Helper.ToDataTable<LP_InventoryLogs_Property>(objINV.InventoryLogs);

                objINV.Description = objINV.Description;
                objINV.ProdductID = objINV.ProdductID;
                objINV.Qty = objINV.Qty;

                    objLP_Inventory_BLL = new LP_Inventory_BLL();
                bool flag = objLP_Inventory_BLL.TransferInventory(objINV);
                return Json(new { data = "/Reports/InventoryReport.Pdf", success = flag, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { data = "/Reports/InventoryReport.Pdf", success = true, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);

            }
        }

        // Getting Available Quantity In Inventory Movement from Inventory
        [HttpGet]
        public JsonResult SearchAvailableQty(int id)
        {
            try
            {
                LP_Inventory_BLL objLP_Inventory_BLL = new LP_Inventory_BLL();
                //DataTable tblFiltered;
                if (id != 0)
                {
                    LP_Inv_Report obj = new LP_Inv_Report();
                    obj.productid = id;

                    var Data = Helper.ConvertDataTable<LP_Inv_Report>(objLP_Inventory_BLL.getAvailableQty(obj.productid));//JsonConvert.SerializeObject(GetAllPIByDate(objsearchPI));
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
        #endregion
    }
}