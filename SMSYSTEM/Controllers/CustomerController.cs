using Newtonsoft.Json;
using SSS.BLL.Setups;
using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSS.Utility;

namespace SMSYSTEM.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        Customers_BLL objCustomer;
        Customers_Property objCustomerProperty;
        public ActionResult ViewCustomers()
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

        public JsonResult GetAllCustomers()
        {
            try
            {
                objCustomerProperty = new Customers_Property();
                objCustomer = new Customers_BLL(objCustomerProperty);
                var Data = JsonConvert.SerializeObject(objCustomer.ViewAllCustomers());
                return Json(new { data = Data, success = true, statuscode = 200, count = Data.Length }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AddNewCustomer(int? id)
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string pagename = @"/" + controllerName + @"/" + actionName;
            var page = (List<LP_Pages_Property>) Session["PageList"];
            if (Session["LoggedIn"] != null && Helper.CheckPageAccess(pagename, page) && Session["ISADMIN"] != null)
            {
                int customerTypeIdx;
                objCustomerProperty = new Customers_Property();
                objCustomerProperty.idx = Convert.ToInt32(id);
                objCustomer = new Customers_BLL(objCustomerProperty);
                DataTable customerTypes = objCustomer.GetCustomerType();
                List<CustomerType_Property> CustomersLST = new List<CustomerType_Property>();
                foreach (DataRow dr in customerTypes.Rows)
                {
                    CustomerType_Property objVendorsCat = new CustomerType_Property();
                    objVendorsCat.customerType = dr["customerType"].ToString();
                    objVendorsCat.idx = Convert.ToInt32(dr["idx"].ToString());
                    CustomersLST.Add(objVendorsCat);
                }

                ViewBag.CustomersLST = CustomersLST;
                if (id != null || id > 0)
                {
                    var dt = objCustomer.GetCustomerById();
                    objCustomerProperty.idx = int.Parse(dt.Rows[0]["idx"].ToString());
                    int.TryParse(dt.Rows[0]["customerTypeIdx"].ToString(), out customerTypeIdx);
                    objCustomerProperty.customerTypeIdx = customerTypeIdx;
                    //objCustomerProperty.vendorCatIdx = int.Parse(dt.Rows[0]["vendorCatIdx"].ToString());

                    //objVendorsProperty.unitIdx = int.Parse(dt.Rows[0]["unitIdx"].ToString());
                    objCustomerProperty.contact = (dt.Rows[0]["contact"].ToString());
                    objCustomerProperty.customerCode = (dt.Rows[0]["customerCode"].ToString());
                    objCustomerProperty.customerName = (dt.Rows[0]["customerName"].ToString());
                    objCustomerProperty.address = (dt.Rows[0]["address"].ToString());
                    objCustomerProperty.ntn = (dt.Rows[0]["ntn"].ToString());
                    objCustomerProperty.strnNo = (dt.Rows[0]["strnNo"].ToString());

                    return View(objCustomerProperty);
                }
                else
                {
                    objCustomerProperty.createdByUserIdx = Convert.ToInt16(Session["UID"].ToString());
                    objCustomer = new Customers_BLL();
                    LP_GenerateTransNumber_Property objtrans = new LP_GenerateTransNumber_Property();
                    objtrans.TableName = "customers";
                    objtrans.Identityfieldname = "idx";
                    objtrans.userid = Session["UID"].ToString();

                    objCustomerProperty.customerCode = objCustomer.GenerateSO(objtrans);
                    return View(objCustomerProperty);
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
        public JsonResult AddUpdate(Customers_Property objcustomer)
        {
            try
            {
                if (objcustomer.idx > 0)
                {
                    
                    objcustomer.lastModifiedByUserIdx = Convert.ToInt32(Session["UID"].ToString()); //Session Idx
                    objcustomer.lastModificationDate = DateTime.Now.ToString("yyyy-MM-dd");
                    objCustomer = new Customers_BLL(objcustomer);
                    bool flag = objCustomer.Update();
                    return Json(new { data = "updated", success = flag, statuscode = 200 }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    objcustomer.createdByUserIdx = Convert.ToInt32(Session["UID"].ToString());//Session Idx
                    objCustomer = new Customers_BLL(objcustomer);
                    bool flag = objCustomer.Insert();
                    return Json(new { data = "Inserted", success = flag, statuscode = 200 }, JsonRequestBehavior.AllowGet);

                }

            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult Delete(int? id)
        {
            try
            {
                if (id > 0)
                {

                    Customers_Property branchProperty = new Customers_Property();
                    branchProperty.idx = int.Parse(id.ToString());
                    objCustomer = new Customers_BLL(id);
                    Customers_BLL branhcBll = new Customers_BLL(branchProperty);
                    var flag = branhcBll.Delete(id);
                    return Json(new { data = "Deleted", success = flag, statuscode = 200 }, JsonRequestBehavior.AllowGet);
                    //if (flag1.Rows.Count > 0)
                    //{
                    //if (true)
                    //{
                    //    bool flag = objVendorsBLL.Delete(id);
                    //    return Json(new { data = "Deleted", success = flag, statuscode = 200 }, JsonRequestBehavior.AllowGet);
                    //}
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