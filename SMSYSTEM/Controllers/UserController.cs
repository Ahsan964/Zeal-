using Newtonsoft.Json;
using SSS.BLL;
using SSS.Property;
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
    public class UserController : Controller
    {
        // GET: User
        User_BLL objUser;
        User_Property objUserProperty;
        public ActionResult ViewUser()
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

        public JsonResult GetAllUsers()
        {
            if (Session["LOGGEDIN"] != null)
            {
                try
                {
                    objUserProperty = new User_Property();
                    objUserProperty.branchIdx = 1;//user logged in session branchIdx
                    objUser = new User_BLL(objUserProperty);
                    var Data = JsonConvert.SerializeObject(objUser.ViewAll());
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

        public ActionResult AddNewUser(int? id)
        {
            if (Session["LOGGEDIN"] != null)
            {
                objUserProperty = new User_Property();
                objUserProperty.idx = Convert.ToInt32(id);
                objUserProperty.branchIdx = 1;//It will have the value of session branchIdx
                objUser = new User_BLL(objUserProperty);
                if (Session["LOGGEDIN"] != null && Session["ISADMIN"] != null)
                {
                    DataTable dtt = objUser.SelectBranch();
                    List<Branch_Property> BranchList = new List<Branch_Property>();
                    foreach (DataRow dr in dtt.Rows)
                    {
                        Branch_Property objbranch = new Branch_Property();
                        objbranch.branchName = dr["branchname"].ToString();
                        objbranch.idx = Convert.ToInt32(dr["idx"].ToString());
                        BranchList.Add(objbranch);
                    }
                    ViewBag.branchList = BranchList;

                }
                else
                {
                    DataTable dtt = objUser.SelectBranchByID();
                    List<Branch_Property> BranchList = new List<Branch_Property>();
                    foreach (DataRow dr in dtt.Rows)
                    {
                        Branch_Property objbranch = new Branch_Property();
                        objbranch.branchName = dr["branchname"].ToString();
                        objbranch.idx = Convert.ToInt32(dr["idx"].ToString());
                        BranchList.Add(objbranch);
                    }
                    ViewBag.branchList = BranchList;

                }

                if (id != null && id != 0)
                {
                    var dt = objUser.GetById();
                    objUserProperty.companyIdx = 1;
                    objUserProperty.idx = int.Parse(dt.Rows[0]["idx"].ToString());
                    objUserProperty.companyIdx = int.Parse(dt.Rows[0]["companyIdx"].ToString());
                    objUserProperty.branchIdx = int.Parse(dt.Rows[0]["branchIdx"].ToString());
                    objUserProperty.firstName = dt.Rows[0]["firstName"].ToString();
                    objUserProperty.lastName = dt.Rows[0]["lastName"].ToString();
                    objUserProperty.CNIC = (dt.Rows[0]["CNIC"].ToString());
                    objUserProperty.cellNumber = (dt.Rows[0]["cellNumber"].ToString());
                    objUserProperty.loginId = (dt.Rows[0]["loginId"].ToString());
                    objUserProperty.password = dt.Rows[0]["password"].ToString();
                    objUserProperty.Is_Admin = Convert.ToBoolean(dt.Rows[0]["Is_Admin"].ToString());

                }


                return PartialView("_AddNewUser", objUserProperty);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public JsonResult AddUpdate(User_Property objuser)
        {
            if (Session["LOGGEDIN"] != null)
            {
                try
                {
                    if (objuser.idx > 0)
                    {

                        objuser.lastModifiedByUserIdx = 1;
                        objuser.lastModificationDate = DateTime.Now.ToString("dd/MM/yyyy");
                        objUser = new User_BLL(objuser);

                        bool flag = objUser.Update();
                        return Json(new { data = "Updated", success = flag, statuscode = 200 }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        objuser.companyIdx = 1;
                        objuser.createdByUserIdx = 1;
                        objUser = new User_BLL(objuser);
                        //if (objUser.isMainBranch == 1)
                        //{
                        //    var check = objUser.MainBranch();
                        //    if (check.Rows.Count > 0)
                        //    {
                        //        return Json(new { data = "Main Branch Already Exist", success = false, statuscode = 500 }, JsonRequestBehavior.AllowGet);
                        //    }
                        //}

                        bool flag = objUser.Insert();
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

        public JsonResult DeleteUser(int? id)
        {
            if (Session["LOGGEDIN"] != null)
            {
                try
                {
                    if (id > 0)
                    {

                        User_Property branchProperty = new User_Property();
                        branchProperty.idx = int.Parse(id.ToString());
                        objUser = new User_BLL(id);
                        User_BLL branhcBll = new User_BLL(branchProperty);
                        var flag1 = branhcBll.GetById();
                        //if (flag1.Rows.Count > 0)
                        //{
                        if (true)
                        {
                            bool flag = objUser.Delete(id);
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