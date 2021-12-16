using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SSS.BLL.Setups;
using SSS.Property.Setups;
using Newtonsoft.Json;
using SSS.Utility;

namespace SMSYSTEM.Controllers
{
    public class DepartmentsController : Controller
    {
        // GET: Departments
     
       Departments_BLL objDepartmentsBLL;
       Departments_property objDepartmentsProperty;
       public ActionResult ViewDepartments()
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

        public JsonResult GetAllDepartments()
        {

            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                    objDepartmentsProperty = new Departments_property();
                    //objVendorCategoryProperty.branchIdx = 1;//user logged in session branchIdx
                    objDepartmentsBLL = new Departments_BLL(objDepartmentsProperty);
                    var Data = JsonConvert.SerializeObject(objDepartmentsBLL.ViewAll());
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

        public ActionResult AddNewDepartments(int? id)
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string pagename = @"/" + controllerName + @"/" + actionName;
            var page = (List<LP_Pages_Property>)Session["PageList"];
            if (Session["LoggedIn"] != null && Helper.CheckPageAccess(pagename, page) && Session["ISADMIN"] != null )
            {
                objDepartmentsProperty = new Departments_property();
                objDepartmentsProperty.idx = Convert.ToInt32(id);
               
                 objDepartmentsBLL = new Departments_BLL(objDepartmentsProperty);
                

                if (id != null && id != 0)
                {
                    var dt = objDepartmentsBLL.GetById(id);
                  
                    objDepartmentsProperty.idx = int.Parse(dt.Rows[0]["idx"].ToString());
                    objDepartmentsProperty.Department = dt.Rows[0]["Department"].ToString();

                   
                }


                return PartialView("_AddNewDepartments", objDepartmentsProperty);
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
        public JsonResult AddUpdate(Departments_property objDepartmentsProperty)
        {
            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                    objDepartmentsProperty.lastModificationByUserIdx = Convert.ToInt32(Session["UID"].ToString());
                    objDepartmentsProperty.lastModificationDate = DateTime.Now.ToString("dd/MM/yyyy");
                    objDepartmentsProperty.createdByUserIdx = Convert.ToInt32(Session["UID"].ToString());
                    objDepartmentsProperty.creationDate = DateTime.Now;
                    objDepartmentsProperty.visible = 1;
                    if (objDepartmentsProperty.idx> 0)
                    {

                       
                        objDepartmentsBLL = new Departments_BLL(objDepartmentsProperty);

                        bool flag = objDepartmentsBLL.Update();
                        return Json(new { data = "Updated", success = flag, statuscode = 200 }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        //objVendorCategory.companyIdx = 1;
                        //objDepartmentsProperty.createdByUserIdx = Convert.ToInt32(Session["UID"].ToString());
                        objDepartmentsBLL = new Departments_BLL(objDepartmentsProperty);
                        //if (objVendorCategory.isMainBranch == 1)
                        //{
                        //    var check = objVendorCategory.MainBranch();
                        //    if (check.Rows.Count > 0)
                        //    {
                        //        return Json(new { data = "Main Branch Already Exist", success = false, statuscode = 500 }, JsonRequestBehavior.AllowGet);
                        //    }
                        //}

                        bool flag = objDepartmentsBLL.Insert();
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

        public JsonResult DeleteDepartments(int? id)
        {
            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                    if (id > 0)
                    {

                        Departments_property Depart_Property = new Departments_property();
                        Depart_Property.idx = int.Parse(id.ToString());
                        //objDepartmentsBLL = new Departments_BLL(id);
                        Departments_BLL depart_BLL = new Departments_BLL(Depart_Property);
                       
                            bool flag = depart_BLL.DeleteDepartment();
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
            else
            {
                return Json(new { data = "Session Expired", success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
