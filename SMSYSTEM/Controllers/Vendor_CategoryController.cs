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
    public class Vendor_CategoryController : Controller
    {
        // GET: Vendor_Category
        Vendor_Category_BLL objVendorCategoryBLL;
        Vendor_Category_Property objVendorCategoryProperty;
        public ActionResult ViewVendorCategory()
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string pagename = @"/" + controllerName + @"/" + actionName;
            var page = (List<LP_Pages_Property>)Session["PageList"];

            if (Session["LoggedIn"] != null && Helper.CheckPageAccess(pagename, page))
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


        public JsonResult GetAllVendorCategories()
        {

            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                objVendorCategoryProperty = new Vendor_Category_Property();
                //objVendorCategoryProperty.branchIdx = 1;//user logged in session branchIdx
                objVendorCategoryBLL = new Vendor_Category_BLL(objVendorCategoryProperty);
                var Data = JsonConvert.SerializeObject(objVendorCategoryBLL.ViewAll());
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

        public ActionResult AddNewVendorCategory(int? id)
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string pagename = @"/" + controllerName + @"/" + actionName;
            var page = (List<LP_Pages_Property>)Session["PageList"];

            if (Session["LoggedIn"] != null && Helper.CheckPageAccess(pagename, page))
            {
                objVendorCategoryProperty = new Vendor_Category_Property();
                objVendorCategoryProperty.idx = Convert.ToInt32(id);
                //objVendorCategoryProperty.branchIdx = 1;//It will have the value of session branchIdx
                objVendorCategoryBLL = new Vendor_Category_BLL(objVendorCategoryProperty);
                //DataTable dtt = objVendorCategory.SelectBranch();
                //List<Branch_Property> BranchList = new List<Branch_Property>();
                //foreach (DataRow dr in dtt.Rows)
                //{
                //    Branch_Property objbranch = new Branch_Property();
                //    objbranch.branchName = dr["branchname"].ToString();
                //    objbranch.idx = Convert.ToInt32(dr["idx"].ToString());
                //    BranchList.Add(objbranch);
                //}
                //ViewBag.branchList = BranchList;

                if (id != null && id != 0)
                {
                    var dt = objVendorCategoryBLL.GetById(id);
                    //objVendorCategoryProperty.companyIdx = 1;
                    objVendorCategoryProperty.idx = int.Parse(dt.Rows[0]["idx"].ToString());
                    objVendorCategoryProperty.vendorCategory = dt.Rows[0]["vendorCategory"].ToString();
                 
                    //objVendorCategoryProperty.firstName = dt.Rows[0]["firstName"].ToString();
                    //objVendorCategoryProperty.lastName = dt.Rows[0]["lastName"].ToString();
                    //objVendorCategoryProperty.CNIC = (dt.Rows[0]["CNIC"].ToString());
                    //objVendorCategoryProperty.cellNumber = (dt.Rows[0]["cellNumber"].ToString());
                    //objVendorCategoryProperty.loginId = (dt.Rows[0]["loginId"].ToString());
                    //objVendorCategoryProperty.password = dt.Rows[0]["password"].ToString();
                }


                return PartialView("_AddNewVendorCategory", objVendorCategoryProperty);
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
        public JsonResult AddUpdate(Vendor_Category_Property objVendorCategory)
        {
            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                if (objVendorCategory.idx > 0)
                {

                    objVendorCategory.lastModifiedByUserIdx = Convert.ToInt32(Session["UID"].ToString());
                        objVendorCategory.lastModificationDate = DateTime.Now.ToString("dd/MM/yyyy");
                    objVendorCategoryBLL = new Vendor_Category_BLL(objVendorCategory);

                    bool flag = objVendorCategoryBLL.Update();
                    return Json(new { data = "Updated", success = flag, statuscode = 200 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    //objVendorCategory.companyIdx = 1;
                    objVendorCategory.createdByUserIdx = Convert.ToInt32(Session["UID"].ToString());
                        objVendorCategoryBLL = new Vendor_Category_BLL(objVendorCategory);
                    //if (objVendorCategory.isMainBranch == 1)
                    //{
                    //    var check = objVendorCategory.MainBranch();
                    //    if (check.Rows.Count > 0)
                    //    {
                    //        return Json(new { data = "Main Branch Already Exist", success = false, statuscode = 500 }, JsonRequestBehavior.AllowGet);
                    //    }
                    //}

                    bool flag = objVendorCategoryBLL.Insert();
                    return Json(new { data = "Inserted", success = flag, statuscode = 200 }, JsonRequestBehavior.AllowGet);
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

        public JsonResult DeleteVendorCat(int? id)
        {
            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                if (id > 0)
                {

                    Vendor_Category_Property branchProperty = new Vendor_Category_Property();
                    branchProperty.idx = int.Parse(id.ToString());
                    objVendorCategoryBLL = new Vendor_Category_BLL(id);
                    Vendor_Category_BLL branhcBll = new Vendor_Category_BLL(branchProperty);
                    var flag1 = branhcBll.Delete(id);
                    //if (flag1.Rows.Count > 0)
                    //{
                    if (true)
                    {
                        bool flag = objVendorCategoryBLL.Delete(id);
                        return Json(new { data = "Deleted", success = flag, statuscode = 200 }, JsonRequestBehavior.AllowGet);
                    }
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
            else
            {
                return Json(new { data = "Session Expired", success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}