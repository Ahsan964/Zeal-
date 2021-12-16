using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SSS.BLL.Setups;
using SSS.Property.Setups;
using SSS.Utility;

namespace SMSYSTEM.Controllers
{
    public class SalesPersonController : BaseController
    {
        SalesPerson_BLL objSalesPerson;
        SalesPerson_Property objSalesPersonPropertyProperty;

        // GET: SalesPerson
        public ActionResult ViewSalesPerson()
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
        
        public JsonResult GetAllSalesPerson()
        {
            try
            {
                objSalesPersonPropertyProperty = new SalesPerson_Property();
                objSalesPerson = new SalesPerson_BLL(objSalesPersonPropertyProperty);
                var Data = JsonConvert.SerializeObject(objSalesPerson.ViewAllCustomers());
                return Json(new { data = Data, success = true, statuscode = 200, count = Data.Length }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }
        }

        // Add New Sales Persons

        public ActionResult AddNewSalesPerson(int? id)
        {
            if (Session["LoggedIn"] != null)
            {
                objSalesPersonPropertyProperty = new SalesPerson_Property();
                objSalesPersonPropertyProperty.idx = Convert.ToInt32(id);
                objSalesPerson = new SalesPerson_BLL(objSalesPersonPropertyProperty);
                

                if (id != null || id > 0)
                {
                    var dt = objSalesPerson.GetSalesPersonById();
                    objSalesPersonPropertyProperty.idx = int.Parse(dt.Rows[0]["idx"].ToString());

                    objSalesPersonPropertyProperty.contact = (dt.Rows[0]["contact"].ToString());
                    objSalesPersonPropertyProperty.SalesPersonName = (dt.Rows[0]["SalesPersonName"].ToString());
                    objSalesPersonPropertyProperty.address = (dt.Rows[0]["address"].ToString());
                    objSalesPersonPropertyProperty.IsActive = bool.Parse(dt.Rows[0]["IsActive"].ToString());
                    objSalesPersonPropertyProperty.BranchList = Helper.ConvertDataTable<Branch_Property>(ViewAllBranches());

                    objSalesPersonPropertyProperty.WareHouseList = Helper.ConvertDataTable<WareHouse_Property>(ViewWareHouses());
                    objSalesPersonPropertyProperty.branchIdx = int.Parse(dt.Rows[0]["branchIdx"].ToString());

                    return View(objSalesPersonPropertyProperty);
                }
                else
                {
                    objSalesPersonPropertyProperty.createdByUserIdx = Convert.ToInt16(Session["UID"].ToString());
                    objSalesPerson = new SalesPerson_BLL();

                    SalesPerson_Property objSalesPersonProperty = new SalesPerson_Property();
                    objSalesPersonProperty.BranchList = Helper.ConvertDataTable<Branch_Property>(ViewAllBranches());
                    
                    objSalesPersonProperty.WareHouseList = Helper.ConvertDataTable<WareHouse_Property>(ViewWareHouses());

                    return View(objSalesPersonProperty);
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

        // AddUpdate 
        [HttpPost]
        public JsonResult AddUpdate(SalesPerson_Property objSales)
        {
            try
            {
                if (objSales.idx > 0)
                {
                    objSales.visible = 1;
                    objSales.lastModifiedByUserIdx = 1;//Session Idx
                    objSales.lastModificationDate = DateTime.Now.ToString("yyyy-MM-dd");
                    objSalesPerson = new SalesPerson_BLL(objSales);
                    bool flag = objSalesPerson.Update();
                    return Json(new { data = "updated", success = flag, statuscode = 200 }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    objSales.visible = 1;
                    objSales.createdByUserIdx = 1;//Session Idx
                    objSalesPerson = new SalesPerson_BLL(objSales);
                    bool flag = objSalesPerson.Insert();
                    return Json(new { data = "Inserted", success = flag, statuscode = 200 }, JsonRequestBehavior.AllowGet);

                }

            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }
        }

        // Delete
        public JsonResult Delete(int? id)
        {
            try
            {
                if (id > 0)
                {

                    objSalesPersonPropertyProperty = new SalesPerson_Property();
                    objSalesPersonPropertyProperty.idx = int.Parse(id.ToString());
                    objSalesPerson = new SalesPerson_BLL(id);
                    var flag = objSalesPerson.Delete(id);
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
    }
}