using SSS.BLL;
using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SSS.Utility;

namespace SMSYSTEM.Controllers
{
    public class AccountController : Controller
    {
        User_Property objuserproperty;
        User_BLL objUserBll;
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(User_Property objuser)
        {
            try
            {
                
                objUserBll = new User_BLL(objuser);
                var data = objUserBll.SelectByIDPassword();
                if (data.Rows.Count > 0)
                {
                    for (int i = 0; i <data.Rows.Count;i++)
                    {
                        Session["UID"] = data.Rows[0]["idx"].ToString();
                        Session["LOGINID"] = data.Rows[0]["loginId"].ToString();
                        Session["COMPANYID"] = data.Rows[0]["companyIdx"].ToString();
                        Session["BRANCHID"] = data.Rows[0]["branchIdx"].ToString();
                        Session["LOGGEDIN"] = true;
                        Session["ISADMIN"] = data.Rows[0]["Is_Admin"].ToString(); 
                    }
                    int userid = Convert.ToInt32(Session["UID"].ToString());
                    objuserproperty = new User_Property();
                    objuserproperty.idx = userid;
                    objUserBll = new User_BLL(objuserproperty);

                    List<LP_Pages_Property> pagelist = new List<LP_Pages_Property>();
                    //Added By Ahsan
                    if (Session["LoggedIn"] != null && Session["ISADMIN"] != null && Convert.ToBoolean(Session["ISADMIN"].ToString()) == true)
                    {
                        pagelist = Helper.ConvertDataTable<LP_Pages_Property>(objUserBll.GetUserPagsAccess());
                    }
                    else
                    {
                        pagelist = Helper.ConvertDataTable<LP_Pages_Property>(objUserBll.GetPagsAccess());

                    }
                    Session["PageList"] = pagelist;

                    return Json(new { data = "",msg="Login Successfull", success = true, statuscode = 200, count = data.Rows.Count }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return Json(new { data = "", msg = "Login Failed", success = true, statuscode = 200, count = 0 }, JsonRequestBehavior.AllowGet);

                }

            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);

            }
        }
        
        public ActionResult LogOff()
        {

            Session.Clear();
            Session.Abandon();
            // Redirecting to Login page after deleting Session
            return RedirectToAction("Login", "Account");
        }


        #region PageManegemrnt

        public ActionResult PageUser()
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string pagename = @"/" + controllerName + @"/" + actionName;
            var page = (List<LP_Pages_Property>)Session["PageList"];
            if (Session["LoggedIn"] != null && Helper.CheckPageAccess(pagename, page) && Session["ISADMIN"] != null && Convert.ToBoolean(Session["ISADMIN"].ToString()) == true)
            // if (Session["LOGGEDIN"] != null)

            {
                LP_PageUser_Property objpage = new LP_PageUser_Property();
                objUserBll = new User_BLL();
                objpage.PageList = Helper.ConvertDataTable<LP_Pages_Property>(objUserBll.GetAllPages());



                User_Property objUserProperty = new User_Property();
                objUserProperty.branchIdx = 1;//user logged in session branchIdx
                User_BLL objUser = new User_BLL(objUserProperty);
                var Data = JsonConvert.SerializeObject(objUser.ViewAll());

                objpage.UserList = Helper.ConvertDataTable<User_Property>(objUser.ViewAll());
                ViewBag.Pagelist = objpage.PageList;
                return View(objpage);
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
        public JsonResult AddUpdatePageUser(LP_PageUser_Property objpageuser)
        {

            try
            {
                int userid = Convert.ToInt16(Session["UID"].ToString());
                List<LP_PageUser_Property> pageserlist = new List<LP_PageUser_Property>();

                //DBClass.db.Database.ExecuteSqlCommand("Delete from PageUsers where UserID={0}", timeline.UserID);
                //DBClass.db.SaveChanges();
                for (int i = 0; i < objpageuser.PageList.Count; i++)
                {

                    LP_PageUser_Property objpguser = new LP_PageUser_Property();
                    objpguser.UserID = objpageuser.UserID;
                    objpguser.PageID = objpageuser.PageList[i].ID;
                    objpguser.CreatedDate = DateTime.Now;
                    objpguser.status = true;
                    objpguser.CreatedBy = userid;
                    pageserlist.Add(objpguser);

                }
                objpageuser.DetailData = Helper.ToDataTable<LP_PageUser_Property>(pageserlist);
                objUserBll = new User_BLL();
                bool flag = objUserBll.UpdatePageUser(objpageuser);


                return Json(new { success = flag, statuscode = 200, url = "/Account/PageUser" }, JsonRequestBehavior.AllowGet);
            }

            catch (Exception ex)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }


        }

        public JsonResult GetUserAccesspages(int id)
        {
            try
            {
                int userid = id;
                objuserproperty = new User_Property();
                objuserproperty.idx = id;
                objUserBll = new User_BLL(objuserproperty);


                var useraccesspages = JsonConvert.SerializeObject(objUserBll.GetUserPagsAccess());

                return Json(new { success = true, statuscode = 200, url = "/Pages/Index", data = useraccesspages }, JsonRequestBehavior.AllowGet);
            }

            catch (Exception ex)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }

        }


        //public bool CheckPageAccess(string pagename, List<LP_Pages_Property> PGlst)
        //{

        //    bool flg = false;

        //    for (int i = 0; i < PGlst.Count; i++)
        //    {
        //        if (PGlst[i].PagePath == pagename)
        //        {
        //            flg = true;
        //        }

        //    }

        //    return flg;
    }
    #endregion

}