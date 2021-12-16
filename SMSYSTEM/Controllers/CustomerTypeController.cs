using Newtonsoft.Json;
using SSS.BLL.Setups;
using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSS.Utility;

namespace SMSYSTEM.Controllers
{
    public class CustomerTypeController : Controller
    {
        // GET: CustomerType
        CustomerType_BLL objCustomerTypeBLL;
        CustomerType_Property objCustomerTypeProperty;
        public ActionResult ViewCustomerType()
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

        public JsonResult GetAllCustomerTypes()
        {
            try
            {
                objCustomerTypeProperty = new CustomerType_Property();
                //objProductCategoryProperty.branchIdx = 1;//user logged in session branchIdx
                objCustomerTypeBLL = new CustomerType_BLL(objCustomerTypeProperty);
                var Data = JsonConvert.SerializeObject(objCustomerTypeBLL.ViewAll());
                return Json(new { data = Data, success = true, statuscode = 200, count = Data.Length }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AddNewCustomerType(int? id)
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string pagename = @"/" + controllerName + @"/" + actionName;
            var page = (List<LP_Pages_Property>)Session["PageList"];
            if (Session["LoggedIn"] != null && Helper.CheckPageAccess(pagename, page) && Session["ISADMIN"] != null )
            {
                objCustomerTypeProperty = new CustomerType_Property();
                objCustomerTypeProperty.idx = Convert.ToInt32(id);
                objCustomerTypeBLL = new CustomerType_BLL(objCustomerTypeProperty);

                if (id != null && id != 0)
                {

                    var dt = objCustomerTypeBLL.SelectById();
                    objCustomerTypeProperty.idx = int.Parse(dt.Rows[0]["idx"].ToString());
                    objCustomerTypeProperty.customerType = dt.Rows[0]["customerType"].ToString();
                    //objProductCategoryProperty.HSCodeCat = dt.Rows[0]["HSCodeCat"].ToString();
                    //objProductCategoryProperty.firstName = dt.Rows[0]["firstName"].ToString();
                    //objProductCategoryProperty.lastName = dt.Rows[0]["lastName"].ToString();
                    //objProductCategoryProperty.CNIC = (dt.Rows[0]["CNIC"].ToString());
                    //objProductCategoryProperty.cellNumber = (dt.Rows[0]["cellNumber"].ToString());
                    //objProductCategoryProperty.loginId = (dt.Rows[0]["loginId"].ToString());
                    //objProductCategoryProperty.password = dt.Rows[0]["password"].ToString();
                }

                return PartialView("_AddNewCustomerType", objCustomerTypeProperty);
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
        public JsonResult AddUpdate(CustomerType_Property objProductCategory)
        {
            try
            {
                if (objProductCategory.idx > 0)
                {

                    objProductCategory.lastModifiedByUserIdx = 1;
                    objProductCategory.lastModificationDate = DateTime.Now.ToString("dd/MM/yyyy");
                    objCustomerTypeBLL = new CustomerType_BLL(objProductCategory);

                    bool flag = objCustomerTypeBLL.Update();
                    return Json(new { data = "Updated", success = flag, statuscode = 200 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    //objProductCategory.companyIdx = 1;
                    objProductCategory.createdByUserIdx = 1;
                    objCustomerTypeBLL = new CustomerType_BLL(objProductCategory);
                    //if (objProductCategory.isMainBranch == 1)
                    //{
                    //    var check = objProductCategory.MainBranch();
                    //    if (check.Rows.Count > 0)
                    //    {
                    //        return Json(new { data = "Main Branch Already Exist", success = false, statuscode = 500 }, JsonRequestBehavior.AllowGet);
                    //    }
                    //}

                    bool flag = objCustomerTypeBLL.Insert();
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

                    CustomerType_Property branchProperty = new CustomerType_Property();
                    branchProperty.idx = int.Parse(id.ToString());
                    objCustomerTypeBLL = new CustomerType_BLL(id);
                    CustomerType_BLL branhcBll = new CustomerType_BLL(branchProperty);
                    var flag1 = branhcBll.Delete(id);
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