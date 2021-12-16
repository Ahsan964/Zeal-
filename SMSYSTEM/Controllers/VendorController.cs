using Newtonsoft.Json;
using SSS.BLL.Setups;
using SSS.BLL.Transactions;
using SSS.Property.Setups;
using SSS.Property.Transactions;
using SSS.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSYSTEM.Controllers
{
    public class VendorController : BaseController
    {
        // GET: Vendor
        Vendors_BLL objVendorsBLL;
        Vendor_Category_BLL objVendorCategoryBLL;
        Vendors_Property objVendorsProperty;
        VendorProcessVM_Property objVendorProcessVM_Property;
        Product_BLL objProductbll;


        public ActionResult ViewVendors()
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

        public JsonResult GetAllVendors()
        {
            try
            {
                objVendorsProperty = new Vendors_Property();
                //objVendorsProperty.branchIdx = 1;//user logged in session branchIdx
                objVendorsBLL = new Vendors_BLL(objVendorsProperty);
                var Data = JsonConvert.SerializeObject(objVendorsBLL.ViewAllVendors());
                return Json(new { data = Data, success = true, statuscode = 200, count = Data.Length }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AddNewVendors(int? id)
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string pagename = @"/" + controllerName + @"/" + actionName;
            var page = (List<LP_Pages_Property>)Session["PageList"];

            if (Session["LoggedIn"] != null && Helper.CheckPageAccess(pagename, page))
            {
                objVendorsProperty = new Vendors_Property();
                objVendorsProperty.idx = Convert.ToInt32(id);
                //objVendorsProperty.branchIdx = 1;//It will have the value of session branchIdx
                objVendorsBLL = new Vendors_BLL(objVendorsProperty);
                DataTable categories = objVendorsBLL.ddlCategory();
                List<Vendor_Category_Property> catLST = new List<Vendor_Category_Property>();

                DataTable VendorTypes = objVendorsBLL.ddlVendorsType();
                List<VendorType_Property> VendorTypeLST = new List<VendorType_Property>();

                foreach (DataRow dr in categories.Rows)
                {
                    Vendor_Category_Property objVendorsCat = new Vendor_Category_Property();
                    objVendorsCat.vendorCategory = dr["vendorCategory"].ToString();
                    objVendorsCat.idx = Convert.ToInt32(dr["idx"].ToString());
                    catLST.Add(objVendorsCat);
                }

                ViewBag.catLST = catLST;

                foreach (DataRow dr in VendorTypes.Rows)
                {
                    VendorType_Property objVendorsCat = new VendorType_Property();
                    objVendorsCat.vendorType = dr["vendorType"].ToString();
                    objVendorsCat.idx = Convert.ToInt32(dr["idx"].ToString());
                    VendorTypeLST.Add(objVendorsCat);
                }

                ViewBag.VendorsTypeLST = VendorTypeLST;
                if (id != null && id != 0)
                {
                    var dt = objVendorsBLL.GetById(id);
                    //objVendorsProperty.companyIdx = 1;
                    objVendorsProperty.idx = int.Parse(dt.Rows[0]["idx"].ToString());
                    objVendorsProperty.vendorTypeIdx = int.Parse(dt.Rows[0]["vendorTypeIdx"].ToString());
                    objVendorsProperty.vendorCatIdx = int.Parse(dt.Rows[0]["vendorCatIdx"].ToString());

                    objVendorsProperty.contact = (dt.Rows[0]["contact"].ToString());
                    objVendorsProperty.vendorCode = (dt.Rows[0]["vendorCode"].ToString());
                    objVendorsProperty.vendorName = (dt.Rows[0]["vendorName"].ToString());
                    objVendorsProperty.address = (dt.Rows[0]["address"].ToString());
                    return PartialView("_AddNewVendors", objVendorsProperty);
                }

                else
                {
                    objVendorsProperty.createdByUserIdx = Convert.ToInt16(Session["UID"].ToString());
                    objVendorsBLL = new Vendors_BLL();
                    LP_GenerateTransNumber_Property objtrans = new LP_GenerateTransNumber_Property();
                    objtrans.TableName = "vendors";
                    objtrans.Identityfieldname = "idx";
                    objtrans.userid = Session["UID"].ToString();

                    objVendorsProperty.vendorCode = objVendorsBLL.GenerateSO(objtrans);
                    return PartialView("_AddNewVendors", objVendorsProperty);
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
        public JsonResult AddUpdate(Vendors_Property objVendorsCategory)
        {
            try
            {
                if (objVendorsCategory.idx > 0)
                {

                    objVendorsCategory.lastModifiedByUserIdx = 1;
                    objVendorsCategory.lastModificationDate = DateTime.Now.ToString("dd/MM/yyyy");
                    objVendorsBLL = new Vendors_BLL(objVendorsCategory);

                    bool flag = objVendorsBLL.Update();
                    return Json(new { data = "Updated", success = flag, statuscode = 200 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    //objVendorsCategory.companyIdx = 1;
                    objVendorsCategory.createdByUserIdx = 1;
                    objVendorsBLL = new Vendors_BLL(objVendorsCategory);
                    //if (objVendorsCategory.isMainBranch == 1)
                    //{
                    //    var check = objVendorsCategory.MainBranch();
                    //    if (check.Rows.Count > 0)
                    //    {
                    //        return Json(new { data = "Main Branch Already Exist", success = false, statuscode = 500 }, JsonRequestBehavior.AllowGet);
                    //    }
                    //}

                    bool flag = objVendorsBLL.Insert();
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

                    Vendors_Property branchProperty = new Vendors_Property();
                    branchProperty.idx = int.Parse(id.ToString());
                    objVendorsBLL = new Vendors_BLL(id);
                    Vendors_BLL branhcBll = new Vendors_BLL(branchProperty);
                    var flag1 = branhcBll.Delete(id);
                    //if (flag1.Rows.Count > 0)
                    //{
                    if (true)
                    {
                        bool flag = objVendorsBLL.Delete(id);
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

        #region VendorProcess

        public ActionResult ViewVendorProcess()
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

        // Vendor Process List
        public JsonResult GetAllVendorProcess()
        {
            try
            {
                objVendorProcessVM_Property = new VendorProcessVM_Property();
                VendorProcess_BLL objBLL = new VendorProcess_BLL(objVendorProcessVM_Property);
                var Data = JsonConvert.SerializeObject(objBLL.ViewAll());
                return Json(new { data = Data, success = true, statuscode = 200, count = Data.Length }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }
        }

        // Single product vendor process list
        public JsonResult GetoneVendorProcess(int id)
        {
            try
            {
                objVendorProcessVM_Property = new VendorProcessVM_Property();
                objVendorProcessVM_Property.itemIdx = id;

                VendorProcess_BLL objBLL = new VendorProcess_BLL(objVendorProcessVM_Property);
                var Data = JsonConvert.SerializeObject(objBLL.singlevendorProcess());
                return Json(new { data = Data, success = true, statuscode = 200, count = Data.Length }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult VendorProcess(int? id)
        {
            if (Session["LOGGEDIN"] != null)
            {
                objVendorProcessVM_Property = new VendorProcessVM_Property();

                if(id > 0)
                {
                    objVendorProcessVM_Property = new VendorProcessVM_Property();
                    objVendorProcessVM_Property.ID = Convert.ToInt32(id);
                    VendorProcess_BLL objBll = new VendorProcess_BLL(objVendorProcessVM_Property);

                    objProductbll = new Product_BLL();
                    objVendorProcessVM_Property.ProductList = Helper.ConvertDataTable<Product_Property>(objProductbll.ViewAll());

                    objVendorCategoryBLL = new Vendor_Category_BLL();
                    objVendorProcessVM_Property.VendorCatList = Helper.ConvertDataTable<Vendor_Category_Property>(objVendorCategoryBLL.ViewAll());

                    objVendorsBLL = new Vendors_BLL();
                    objVendorProcessVM_Property.VendorLST = Helper.ConvertDataTable<Vendors_Property>(GetVendorByVendorCat(objVendorProcessVM_Property.vendorCatIdx));

                    objVendorProcessVM_Property.vendorDetailList = Helper.ConvertDataTable<VendorProcessVM_Property>(objBll.viewOne());

                    objVendorProcessVM_Property.ID = objVendorProcessVM_Property.vendorDetailList[0].ID;
                    objVendorProcessVM_Property.itemIdx = objVendorProcessVM_Property.vendorDetailList[0].itemIdx;
                    objVendorProcessVM_Property.vendorIdx = objVendorProcessVM_Property.vendorDetailList[0].vendorIdx;
                    objVendorProcessVM_Property.vendorCatIdx = objVendorProcessVM_Property.vendorDetailList[0].vendorCatIdx;
                    objVendorProcessVM_Property.activityPrice = objVendorProcessVM_Property.vendorDetailList[0].activityPrice;

                    ViewBag.update = true;
                }
                else
                {
                    // Products Dropdown
                    Product_BLL objProductbll = new Product_BLL();
                    Product_Property product = new Product_Property();
                    objVendorProcessVM_Property.ProductList = Helper.ConvertDataTable<Product_Property>(objProductbll.ViewAll());

                    // Vendors Droprdown
                    Vendors_Property vendor = new Vendors_Property();
                    Vendors_BLL objvendorbll = new Vendors_BLL();
                    objVendorProcessVM_Property.VendorLST = Helper.ConvertDataTable<Vendors_Property>(GetVendorByVendorCat(objVendorProcessVM_Property.vendorCatIdx));

                    // Vendor Categories List
                    Vendor_Category_Property vendorCat = new Vendor_Category_Property();
                    Vendor_Category_BLL objvendorcatbll = new Vendor_Category_BLL();
                    objVendorProcessVM_Property.VendorCatList = Helper.ConvertDataTable<Vendor_Category_Property>(objvendorcatbll.ViewAll());

                    objVendorProcessVM_Property.vendorDetailList = new List<VendorProcessVM_Property>();

                    ViewBag.update = false;
                }
               
                return View(objVendorProcessVM_Property);
                
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public JsonResult VendorProcessPrice(VendorProcessVM_Property objvendor)
        {
            try
            {
                bool flag = false;
                if (objvendor.ID > 0)
                {
                    VendorProcessVM_Property objVendor = new VendorProcessVM_Property();
                    objVendor.ID = objvendor.ID;
                    objVendor.itemIdx = objvendor.itemIdx;
                    objVendor.vendorCatIdx = objvendor.vendorCatIdx;
                    objVendor.vendorIdx = objvendor.vendorIdx;
                    objVendor.activityPrice = objvendor.activityPrice;
                    objVendor.creationDate = DateTime.Now;
                    objVendor.CreatedBy = Convert.ToInt16(Session["UID"].ToString());
                    objVendor.visible = true;
                    objVendor.DetailData = Helper.ToDataTable<VendorProcessVM_Property>(objvendor.vendorDetailList);

                    VendorProcess_BLL objBLL = new VendorProcess_BLL(objVendor);

                    flag = objBLL.DeleteAndInsert();
                }

                else
                {
                    VendorProcessVM_Property objVendor = new VendorProcessVM_Property();
                    objVendor.ID = objvendor.ID;
                    objVendor.itemIdx = objvendor.itemIdx;
                    objVendor.vendorCatIdx = objvendor.vendorCatIdx;
                    objVendor.vendorIdx = objvendor.vendorIdx;
                    objVendor.activityPrice = objvendor.activityPrice;
                    objVendor.creationDate = DateTime.Now;
                    objVendor.CreatedBy = Convert.ToInt16(Session["UID"].ToString());
                    objVendor.visible = true;
                    objVendor.DetailData = Helper.ToDataTable<VendorProcessVM_Property>(objvendor.vendorDetailList);

                    VendorProcess_BLL objBLL = new VendorProcess_BLL(objVendor);

                    flag = objBLL.Insert();
                }

                    if (flag)
                    {
                        return Json(new { data = "Inserted", success = flag, msg = flag == true ? "Successfull" : "Success", statuscode = flag == true ? 200 : 401 }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { data = "", success = flag, msg = flag == true ? "Failure" : "Failure", statuscode = flag == true ? 200 : 401 }, JsonRequestBehavior.AllowGet);
                    }
                
            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult DeleteVendorProcess(int? id)
        {
            if (Session["LOGGEDIN"] != null)
            {
                try
                {
                    objVendorProcessVM_Property = new VendorProcessVM_Property();
                    objVendorProcessVM_Property.ID = int.Parse(id.ToString());

                    VendorProcess_BLL objBll = new VendorProcess_BLL(objVendorProcessVM_Property);
                    var flag1 = objBll.Delete();
                    if (flag1)
                    {
                        return Json(new { data = "Deleted", success = flag1, statuscode = 200 }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { data = "Error", success = flag1, statuscode = 200 }, JsonRequestBehavior.DenyGet);
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

        public JsonResult SearchVendorsOnCatIdx(int Id)
        {
            try
            {
                if (Id > 0)
                {
                    var Data = Helper.ConvertDataTable<Vendors_Property>(GetVendorByVendorCat(Id));
                    return Json(new { data = Data, success = true, statuscode = 200 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { data = "Error Occured", success = false, statuscode = 500 }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {

                return Json(new { data = "Session Expired", success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult SearchPrice(int id)
        {
            try
            {
                Vendors_BLL objbll = new Vendors_BLL(id);
                //DataTable tblFiltered;
                if (id != 0)
                {
                    var Data = Helper.ConvertDataTable<Vendors_Property>(objbll.getVendorPrice(id));
                    return Json(new { data = Data, success = true, statuscode = 200 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { data = "Error Occured", success = false, statuscode = 500 }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {

                return Json(new { data = "Session Expired", success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion
    }
}