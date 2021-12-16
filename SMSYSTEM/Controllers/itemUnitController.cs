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
    public class itemUnitController : Controller
    {
        // GET: itemUnit
        itemUnit_BLL objItemUnitBLL;
        itemUnit_Property objItemUnitProperty;
        public ActionResult ViewItemUnit()
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

        public JsonResult GetAllItemUnits()
        {
            try
            {
                objItemUnitProperty = new itemUnit_Property();
                //objItemUnitProperty.branchIdx = 1;//user logged in session branchIdx
                objItemUnitBLL = new itemUnit_BLL(objItemUnitProperty);
                var Data = JsonConvert.SerializeObject(objItemUnitBLL.ViewAll());
                return Json(new { data = Data, success = true, statuscode = 200, count = Data.Length }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AddNewItemUnit(int? id)
        {
            objItemUnitProperty = new itemUnit_Property();
            objItemUnitProperty.idx = Convert.ToInt32(id);
            //objItemUnitProperty.branchIdx = 1;//It will have the value of session branchIdx
            objItemUnitBLL = new itemUnit_BLL(objItemUnitProperty);
            //DataTable dtt = objItemUnitProperty.SelectBranch();
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
                var dt = objItemUnitBLL.GetById(id);
                //objItemUnitProperty.companyIdx = 1;
                objItemUnitProperty.idx = int.Parse(dt.Rows[0]["idx"].ToString());
                objItemUnitProperty.itemUnit = dt.Rows[0]["itemUnit"].ToString();
                //objItemUnitProperty.c = dt.Rows[0]["HSCodeCat"].ToString();
                //objItemUnitProperty.firstName = dt.Rows[0]["firstName"].ToString();
                //objItemUnitProperty.lastName = dt.Rows[0]["lastName"].ToString();
                //objItemUnitProperty.CNIC = (dt.Rows[0]["CNIC"].ToString());
                //objItemUnitProperty.cellNumber = (dt.Rows[0]["cellNumber"].ToString());
                //objItemUnitProperty.loginId = (dt.Rows[0]["loginId"].ToString());
                //objItemUnitProperty.password = dt.Rows[0]["password"].ToString();
            }


            return PartialView("_AddNewItemUnit", objItemUnitProperty);
        }

        [HttpPost]
        public JsonResult AddUpdate(itemUnit_Property objItemUnitProperty)
        {
            try
            {
                if (objItemUnitProperty.idx > 0)
                {

                    objItemUnitProperty.lastModifiedByUserIdx = 1;
                    objItemUnitProperty.lastModificationDate = DateTime.Now.ToString("dd/MM/yyyy");
                    objItemUnitBLL = new itemUnit_BLL(objItemUnitProperty);

                    bool flag = objItemUnitBLL.Update();
                    return Json(new { data = "Updated", success = flag, statuscode = 200 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    //objItemUnitProperty.companyIdx = 1;
                    objItemUnitProperty.createdByUserIdx = 1;
                    objItemUnitBLL = new itemUnit_BLL(objItemUnitProperty);
                    //if (objItemUnitProperty.isMainBranch == 1)
                    //{
                    //    var check = objItemUnitProperty.MainBranch();
                    //    if (check.Rows.Count > 0)
                    //    {
                    //        return Json(new { data = "Main Branch Already Exist", success = false, statuscode = 500 }, JsonRequestBehavior.AllowGet);
                    //    }
                    //}

                    bool flag = objItemUnitBLL.Insert();
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

                    itemUnit_Property branchProperty = new itemUnit_Property();
                    branchProperty.idx = int.Parse(id.ToString());
                    objItemUnitBLL = new itemUnit_BLL(id);
                    itemUnit_BLL branhcBll = new itemUnit_BLL(branchProperty);
                    var flag1 = branhcBll.Delete(id);
                    //if (flag1.Rows.Count > 0)
                    //{
                    if (true)
                    {
                        bool flag = objItemUnitBLL.Delete(id);
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
    }
}