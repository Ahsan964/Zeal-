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
    public class Product_SubCategoryController : Controller
    {
        // GET: Product_Category
        Product_SubCategory_BLL objProductSubCategoryBLL;
        Product_SubCategory_Property objProductCategoryProperty;
        public ActionResult ViewProductSubCategory()
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

        public JsonResult GetAllProductSubCategories()
        {

            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                objProductCategoryProperty = new Product_SubCategory_Property();
                //objProductCategoryProperty.branchIdx = 1;//user logged in session branchIdx
                objProductSubCategoryBLL = new Product_SubCategory_BLL(objProductCategoryProperty);
                var Data = JsonConvert.SerializeObject(objProductSubCategoryBLL.ViewAll());
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

        public ActionResult AddNewProductSubCategory(int? id)
        {

            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string pagename = @"/" + controllerName + @"/" + actionName;
            var page = (List<LP_Pages_Property>)Session["PageList"];

            if (Session["LoggedIn"] != null && Helper.CheckPageAccess(pagename, page))
            {

                objProductCategoryProperty = new Product_SubCategory_Property();
                objProductCategoryProperty.idx = Convert.ToInt32(id);
                //objProductCategoryProperty.branchIdx = 1;//It will have the value of session branchIdx
                objProductSubCategoryBLL = new Product_SubCategory_BLL(objProductCategoryProperty);
                DataTable dtt = objProductSubCategoryBLL.ViewAllCategories();
                List<Product_Category_Property> catLST = new List<Product_Category_Property>();
                foreach (DataRow dr in dtt.Rows)
                {
                    Product_Category_Property objProductCat = new Product_Category_Property();
                    objProductCat.Category = dr["Category"].ToString();
                    objProductCat.idx = Convert.ToInt32(dr["idx"].ToString());
                    catLST.Add(objProductCat);
                }
                ViewBag.catLST = catLST;

                if (id != null && id != 0)
                {
                    var dt = objProductSubCategoryBLL.GetById(id);
                    //objProductCategoryProperty.companyIdx = 1;
                    objProductCategoryProperty.idx = int.Parse(dt.Rows[0]["idx"].ToString());
                    objProductCategoryProperty.product_catIdx = int.Parse(dt.Rows[0]["product_catIdx"].ToString());
                    objProductCategoryProperty.subCategory = dt.Rows[0]["subCategory"].ToString();
                    objProductCategoryProperty.HS_CodeSub = dt.Rows[0]["HS_CodeSub"].ToString();
                    //objProductCategoryProperty.firstName = dt.Rows[0]["firstName"].ToString();
                    //objProductCategoryProperty.lastName = dt.Rows[0]["lastName"].ToString();
                    //objProductCategoryProperty.CNIC = (dt.Rows[0]["CNIC"].ToString());
                    //objProductCategoryProperty.cellNumber = (dt.Rows[0]["cellNumber"].ToString());
                    //objProductCategoryProperty.loginId = (dt.Rows[0]["loginId"].ToString());
                    //objProductCategoryProperty.password = dt.Rows[0]["password"].ToString();
                }


                return PartialView("_AddNewProductSubCategory", objProductCategoryProperty);
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
        public JsonResult AddUpdate(Product_SubCategory_Property objProductCategory)
        {
            if (Session["LOGGEDIN"] != null)
            {
                try
            {   
                if (objProductCategory.idx > 0)
                    {
                        objProductSubCategoryBLL = new Product_SubCategory_BLL(objProductCategory);
                        if (objProductSubCategoryBLL.CheckForUpdate().Rows.Count > 0)
                        {
                            return Json(new { data = "Already Exist ", success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
                            //show error
                        }
                        else
                        {
                            objProductSubCategoryBLL = new Product_SubCategory_BLL(objProductCategory);

                            bool flag = objProductSubCategoryBLL.Update();
                            return Json(new { data = "Updated", success = flag, statuscode = 200 }, JsonRequestBehavior.AllowGet);
                        }
                       
                }
                else
                {
                    //objProductCategory.companyIdx = 1;
                    objProductCategory.CreatedByUserIdx = Convert.ToInt32(Session["UID"].ToString());
                        objProductSubCategoryBLL = new Product_SubCategory_BLL(objProductCategory);
                        if (objProductSubCategoryBLL.CheckForInsert().Rows.Count > 0)
                        {
                            return Json(new { data = "Already Exist ", success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
                            //show error
                        }
                        else
                        {
                            bool flag = objProductSubCategoryBLL.Insert();
                            return Json(new { data = "Inserted", success = flag, statuscode = 200 }, JsonRequestBehavior.AllowGet);
                        }
                       
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

        public JsonResult DeleteProductSubCat(int? id)
        {
            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                if (id > 0)
                {

                    Product_SubCategory_Property branchProperty = new Product_SubCategory_Property();
                    branchProperty.idx = int.Parse(id.ToString());
                    objProductSubCategoryBLL = new Product_SubCategory_BLL(id);
                    Product_SubCategory_BLL branhcBll = new Product_SubCategory_BLL(branchProperty);
                    var flag1 = branhcBll.Delete(id);
                    //if (flag1.Rows.Count > 0)
                    //{
                    if (true)
                    {
                        bool flag = objProductSubCategoryBLL.Delete(id);
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