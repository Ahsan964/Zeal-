using Newtonsoft.Json;
using SSS.BLL.Transactions;
using SSS.BLL.Transactions.GDN;
using SSS.BLL.Transactions.ViewModels;
using SSS.Property.Setups;
using SSS.Property.Setups.GDN;
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
    public class GDNController : BaseController
    {
        LP_GDN_VM objGDNVM;
        LP_GDNMaster_Property objGDNProperty;
        LP_SalesOrder_BLL objSalesBLL;
        LP_GDN_BLL objGDNBLL;
        // GET: GDN
        #region Good Delivery Note
        public ActionResult ViewGDN()
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

        public ActionResult AddNewGDN(int? id)
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string pagename = @"/" + controllerName + @"/" + actionName;
            var page = (List<LP_Pages_Property>)Session["PageList"];
            if (Session["LoggedIn"] != null && Helper.CheckPageAccess(pagename, page) && Session["ISADMIN"] != null)
            {

                objGDNVM = new LP_GDN_VM();
                objSalesBLL = new LP_SalesOrder_BLL();
                objGDNBLL = new LP_GDN_BLL();
                objGDNVM.SalesOrderList = Helper.ConvertDataTable<LP_SalesOrder_Master_Property>(objSalesBLL.SelectAll());
                //objGRNVM_Property.Doc_No = "GRN-001";
                if (id > 0)
                {
                    //update 
                    LP_GDNDetail_Property objdetail;
                    objGDNProperty = new LP_GDNMaster_Property();
                    objGDNProperty.ID = Convert.ToInt16(id);

                    objGDNBLL = new LP_GDN_BLL(objGDNProperty);
                    DataTable dt = objGDNBLL.SelectOne();
                    objGDNVM.DriverName = dt.Rows[0]["Driver_Name"].ToString();
                    objGDNVM.DriverCnic = dt.Rows[0]["DriverCnic"].ToString();
                    objGDNVM.memo = dt.Rows[0]["memo"].ToString();
                    objGDNVM.DriverAddress = dt.Rows[0]["DriverAddress"].ToString();
                    objGDNVM.ID = Convert.ToInt16(dt.Rows[0]["ID"].ToString());
                    //objGRNVM_Property.vendorIdx = Convert.ToInt16(dt.Rows[0]["vendorIdx"].ToString());

                    objGDNVM.Doc_No = dt.Rows[0]["Doc_No"].ToString();
                    objGDNVM.Narration = dt.Rows[0]["Narration"].ToString();
                    objGDNVM.Parent_DocID = Convert.ToInt16(dt.Rows[0]["Parent_DocID"].ToString());
                    objGDNVM.Total_Amount = Convert.ToDecimal(dt.Rows[0]["Total_Amount"].ToString());
                    //objPurchaseVM_Property.purchaseDate = DateTime.Parse(dt.Rows[0]["mrnDate"].ToString()).ToString("yyyy-MM-dd");
                    //foreach(DataRow dr in dt.Rows)
                    //{
                    //    objmrndetail

                    //}
                    ViewBag.DetailData = Helper.ConvertDataTable<LP_GDN_VM>(dt);
                    //update
                    return View("AddNewGDN", objGDNVM);
                }
                else
                {
                    LP_GenerateTransNumber_Property objtrans = new LP_GenerateTransNumber_Property();
                    objtrans.TableName = "GDN_Master";
                    objtrans.Identityfieldname = "ID";
                    objtrans.userid = Session["UID"].ToString();
                    objGDNVM.Doc_No = objGDNBLL.GenerateMRNNo(objtrans);
                    return View("AddNewGDN", objGDNVM);

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
        public JsonResult AddUpdate(LP_GDN_VM objGDN)
        {
            try
            {
                bool flag = false;
                objGDNProperty = new LP_GDNMaster_Property();
                objGDNProperty.Doc_No = objGDN.Doc_No;
                objGDNProperty.Parent_DocID = objGDN.Parent_DocID;
                objGDNProperty.DriverName = objGDN.DriverName;
                objGDNProperty.DriverCnic = objGDN.DriverCnic;
                objGDNProperty.DriverAddress = objGDN.DriverAddress;
                objGDNProperty.memo = objGDN.memo;

                objGDNProperty.Date_Created = objGDN.Date_Created;
                objGDNProperty.Narration = objGDN.Narration;
                objGDNProperty.Total_Amount = objGDN.Total_Amount;
                objGDNProperty.User_ID = Convert.ToInt16(Session["UID"].ToString());
                //  objGRNProperty.paidDate = ;// objGRN.paidDate;

                objGDNProperty.DetailData = Helper.ToDataTable<LP_GDNDetail_Property>(objGDN.GDNDetailList);
                if (objGDN.ID > 0)
                {
                    //update
                    objGDNProperty.ID = objGDN.ID;

                    objGDNProperty.TableName = "GDN_Detail";
                    objGDNProperty.Status = "Active";
                    objGDNBLL = new LP_GDN_BLL(objGDNProperty);
                    flag = objGDNBLL.Insert();
                }
                else
                {
                    //add
                    objGDNProperty.Date_Created = DateTime.Now;
                    objGDNProperty.Status = "Active";
                    objGDNProperty.User_ID = Convert.ToInt16(Session["UID"].ToString());
                    // objGRNProperty.visible = objGRN.visible;
                    objGDNProperty.TableName = "GDN_Detail";
                    objGDNBLL = new LP_GDN_BLL(objGDNProperty);
                    flag = objGDNBLL.Insert();

                }
                return Json(new { data = "", success = flag, msg = flag == true ? "Successfull" : "Failed", statuscode = flag == true ? 200 : 401 }, JsonRequestBehavior.AllowGet);

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
                    objGDNProperty = new LP_GDNMaster_Property();
                    objGDNProperty.ID = int.Parse(id.ToString());

                    LP_GDN_BLL objBll = new LP_GDN_BLL(objGDNProperty);
                    var flag1 = objBll.Delete();
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

        public JsonResult GetAllGDN()
        {

            if (Session["LOGGEDIN"] != null)
            {
                try
                {


                    objGDNBLL = new LP_GDN_BLL();
                    var Data = JsonConvert.SerializeObject(objGDNBLL.SelectAll());
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

        public JsonResult ProcessGDN(int id)
        {

            if (Session["LOGGEDIN"] != null)
            {
                bool flag = false;
                try
                {

                    objGDNProperty = new LP_GDNMaster_Property();
                    objGDNProperty.ID = id;
                    objGDNBLL = new LP_GDN_BLL(objGDNProperty);
                    flag = objGDNBLL.ProcessGDN();
                    return Json(new { data = "", success = flag, msg = flag == true ? "Successfull" : "Failed", statuscode = flag == true ? 200 : 401 }, JsonRequestBehavior.AllowGet);

                }
                catch (Exception ex)
                {
                    return Json(new { data = "", success = flag, msg = flag == true ? "Successfull" : "Failed", statuscode = flag == true ? 200 : 401 }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { data = "Session Expired", success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult GenerateGDNReport(int? id, int? query, string ReportName, string driver, string vhcl)
        {
            Session["driver"] = driver;
            Session["vhcl"] = vhcl;

            return GenerateReport(id, query, ReportName);

        }
        #endregion
    }
}
