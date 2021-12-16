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
    public class BranchController : Controller
    {
        // GET: Branch
        // GET: Company
        // GET: Customer
        Branch_BLL objBranch;
        Branch_Property objBranchProperty;
        public ActionResult ViewBranch()
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

        public JsonResult GetAllBranches()
        {
            if (Session["LOGGEDIN"] != null)
            {
                try
                {
                    objBranchProperty = new Branch_Property();
                    objBranch = new Branch_BLL(objBranchProperty);
                    var Data = JsonConvert.SerializeObject(objBranch.ViewAll());
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

        public ActionResult AddNewBranch(int? id)
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string pagename = @"/" + controllerName + @"/" + actionName;
            var page = (List<LP_Pages_Property>)Session["PageList"];

            if (Session["LoggedIn"] != null && Helper.CheckPageAccess(pagename, page) && Session["ISADMIN"] != null )
            {
                objBranchProperty = new Branch_Property();
                objBranchProperty.idx = Convert.ToInt32(id);
                objBranch = new Branch_BLL(objBranchProperty);
                if (id > 0 && id != null)
                {
                    var dt = objBranch.GetById();
                    objBranchProperty.companyIdx = 1;
                    objBranchProperty.idx = int.Parse(dt.Rows[0]["idx"].ToString());
                    objBranchProperty.companyIdx = int.Parse(dt.Rows[0]["companyIdx"].ToString());
                    objBranchProperty.branchName = dt.Rows[0]["branchName"].ToString();
                    objBranchProperty.address = dt.Rows[0]["address"].ToString();
                    objBranchProperty.contactNumber = dt.Rows[0]["contactNumber"].ToString();
                    objBranchProperty.isMainBranch = int.Parse(dt.Rows[0]["isMainBranch"].ToString());
                    //objBranchProperty.address = dt.Rows[0]["address"].ToString();
                }


                return PartialView("_AddNewBranch", objBranchProperty);
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
        public JsonResult AddUpdate(Branch_Property objbranch)
        {
            if (Session["LOGGEDIN"] != null)
            {
                try
                {
                   
                    if (objbranch.idx > 0)
                    {

                        objbranch.lastModifiedByUserIdx = Convert.ToInt32(Session["UID"].ToString());
                        objbranch.lastModificationDate = DateTime.Now.ToString("dd/MM/yyyy");
                        objBranch = new Branch_BLL(objbranch);

                        bool flag = objBranch.Update();
                        return Json(new { data = "Updated", success = flag, statuscode = 200 }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        objbranch.companyIdx = 1;
                        objbranch.createdByUserIdx = Convert.ToInt32(Session["UID"].ToString());
                        objBranch = new Branch_BLL(objbranch);
                        if (objbranch.isMainBranch == 1)
                        {
                            var check = objBranch.MainBranch();
                            if (check.Rows.Count > 0)
                            {

                                return Json(new { data = "Main Branch Already Exist", success = false, msg="failed", statuscode = 500 }, JsonRequestBehavior.AllowGet);
                            }
                        }

                        bool flag = objBranch.Insert();
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

        public JsonResult DeleteBranch(int? id)
        {
            if (Session["LOGGEDIN"] != null)
            {
                try
                {
                    if (id > 0)
                    {

                        Branch_Property branchProperty = new Branch_Property();
                        branchProperty.idx = int.Parse(id.ToString());
                        objBranch = new Branch_BLL(id);
                        Branch_BLL branhcBll = new Branch_BLL(branchProperty);
                        var flag1 = branhcBll.GetById();
                        if (flag1.Rows.Count > 0)
                        {
                            if (int.Parse(flag1.Rows[0]["isMainBranch"].ToString()) == 0)
                            {
                                bool flag = objBranch.Delete(id);
                                return Json(new { data = "Deleted", success = flag, statuscode = 200 }, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                return Json(new { data = "Mian Branch Cannot be Delete ", success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
                            }

                        }
                        return Json(new { data = "Process Completed ", success = true, statuscode = 200 }, JsonRequestBehavior.AllowGet);


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