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
    public class Product_CategoryController : Controller
    {
        // GET: Product_Category
        Product_Category_BLL objProductCategoryBLL;
        Product_Category_Property objProductCategoryProperty;
        public ActionResult ViewProductCategory()
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

        public JsonResult GetAllProductCategories()
        {
            if (Session["LOGGEDIN"] != null)
            {
                try
                {
                    objProductCategoryProperty = new Product_Category_Property();
                    //objProductCategoryProperty.branchIdx = 1;//user logged in session branchIdx
                    objProductCategoryBLL = new Product_Category_BLL(objProductCategoryProperty);
                    var Data = JsonConvert.SerializeObject(objProductCategoryBLL.ViewAll());
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

        public ActionResult AddNewProductCategory(int? id)
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string pagename = @"/" + controllerName + @"/" + actionName;
            var page = (List<LP_Pages_Property>)Session["PageList"];

            if (Session["LoggedIn"] != null && Helper.CheckPageAccess(pagename, page))
            {
                objProductCategoryProperty = new Product_Category_Property();
                objProductCategoryProperty.idx = Convert.ToInt32(id);
                //objProductCategoryProperty.branchIdx = 1;//It will have the value of session branchIdx
                objProductCategoryBLL = new Product_Category_BLL(objProductCategoryProperty);
                //DataTable dtt = objProductCategory.SelectBranch();
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
                    var dt = objProductCategoryBLL.GetById(id);
                    //objProductCategoryProperty.companyIdx = 1;
                    objProductCategoryProperty.idx = int.Parse(dt.Rows[0]["idx"].ToString());
                    objProductCategoryProperty.Category = dt.Rows[0]["Category"].ToString();
                    objProductCategoryProperty.HSCodeCat = dt.Rows[0]["HSCodeCat"].ToString();
                    //objProductCategoryProperty.firstName = dt.Rows[0]["firstName"].ToString();
                    //objProductCategoryProperty.lastName = dt.Rows[0]["lastName"].ToString();
                    //objProductCategoryProperty.CNIC = (dt.Rows[0]["CNIC"].ToString());
                    //objProductCategoryProperty.cellNumber = (dt.Rows[0]["cellNumber"].ToString());
                    //objProductCategoryProperty.loginId = (dt.Rows[0]["loginId"].ToString());
                    //objProductCategoryProperty.password = dt.Rows[0]["password"].ToString();
                }


                return PartialView("_AddNewProductCategory", objProductCategoryProperty);
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
        public JsonResult AddUpdate(Product_Category_Property objProductCategory)
        {
            if (Session["LOGGEDIN"] != null)
            {
                try
                {
                    if (objProductCategory.idx > 0)
                    {

                        //objProductCategory.lastModifiedByUserIdx = 1;
                        //objProductCategory.lastModificationDate = DateTime.Now.ToString("dd/MM/yyyy");
                        objProductCategoryBLL = new Product_Category_BLL(objProductCategory);
                        if (objProductCategoryBLL.CheckForUpdate().Rows.Count>0)
                        {
                            return Json(new { data = "Already Exist ", success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
                            //show error
                        }
                        else
                        {
                            bool flag = objProductCategoryBLL.Update();
                            return Json(new { data = "Updated", success = flag, statuscode = 200 }, JsonRequestBehavior.AllowGet);
                        }
                        
                    }
                    else
                    {


                        objProductCategory.CreatedByUserIdx = Convert.ToInt32(Session["UID"].ToString());
                        objProductCategoryBLL = new Product_Category_BLL(objProductCategory);
                        if (objProductCategoryBLL.CheckForInsert().Rows.Count > 0)
                        {
                            return Json(new { data = "Already Exist ", success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
                            //show error
                        }
                        else
                        {
                            bool flag = objProductCategoryBLL.Insert();
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

        public JsonResult DeleteProductCat(int? id)
        {
            if (Session["LOGGEDIN"] != null)
            {
                try
                {
                    if (id > 0)
                    {

                        Product_Category_Property branchProperty = new Product_Category_Property();
                        branchProperty.idx = int.Parse(id.ToString());
                        objProductCategoryBLL = new Product_Category_BLL(id);
                        Product_Category_BLL branhcBll = new Product_Category_BLL(branchProperty);
                        var flag1 = branhcBll.Delete(id);
                        //if (flag1.Rows.Count > 0)
                        //{
                        if (true)
                        {
                            bool flag = objProductCategoryBLL.Delete(id);
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