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
    public class PurchaseController : BaseController
    {
        PurchaseVM_Property objPurchaseVM_Property;
        LP_Purchase_Master_Property objPurchaseProperty;
        LP_Purchase_BLL objpurchaseBll;
        // GET: Purchase
        public ActionResult ViewPurchase()
        {
            if (Session["LOGGEDIN"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public JsonResult GetAllPurchase()
        {
            try
            {
                objPurchaseVM_Property = new PurchaseVM_Property();
                objpurchaseBll = new LP_Purchase_BLL(objPurchaseProperty);
                var Data = JsonConvert.SerializeObject(objpurchaseBll.SelectAll());
                return Json(new { data = Data, success = true, statuscode = 200, count = Data.Length }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult AddNewPurchase(int? id)
        {
            if (Session["LOGGEDIN"] != null)
            {
                objPurchaseVM_Property = new PurchaseVM_Property();
                Vendors_Property vendor = new Vendors_Property();
                Product_Property product = new Product_Property();
                Vendors_BLL objvendorbll = new Vendors_BLL();
                Product_BLL objProductbll = new Product_BLL();
                LP_MRN_BLL objMRNbll = new LP_MRN_BLL();
                objPurchaseVM_Property.MRList = Helper.ConvertDataTable<LP_MRN_Master_Property>(objMRNbll.SelectMRN());
                objPurchaseVM_Property.VendorLST = Helper.ConvertDataTable<Vendors_Property>(objvendorbll.ViewAll());
                objPurchaseVM_Property.DepartmentList = Helper.ConvertDataTable<Departments_property>(GetAllDepartments());

                objPurchaseVM_Property.ProductList = Helper.ConvertDataTable<Product_Property>(objProductbll.ViewAll());
                objPurchaseVM_Property.purchaseDate =DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                //objPurchaseVM_Property.poNumber = "Po-001";
                if (id > 0)
                {
                    LP_Purchase_Detail_Property objmpurchasedetail;
                    objPurchaseProperty = new LP_Purchase_Master_Property();
                    objPurchaseProperty.idx = Convert.ToInt16(id);

                    objpurchaseBll = new LP_Purchase_BLL(objPurchaseProperty);
                    DataTable dt = objpurchaseBll.SelectOne();
                    objPurchaseVM_Property.idx = Convert.ToInt16(dt.Rows[0]["purchaseIdx"].ToString());
                    objPurchaseVM_Property.vendorIdx = Convert.ToInt16(dt.Rows[0]["vendorIdx"].ToString());
                    objPurchaseVM_Property.poNumber = dt.Rows[0]["poNumber"].ToString();
                    objPurchaseVM_Property.description = dt.Rows[0]["description"].ToString();
                    objPurchaseVM_Property.MRNIdx =Convert.ToInt16(dt.Rows[0]["MRNIdx"].ToString());
                    objPurchaseVM_Property.DepartmentID = Convert.ToInt16(dt.Rows[0]["DepartmentID"].ToString());
                    objPurchaseVM_Property.totalAmount = Convert.ToDecimal(dt.Rows[0]["totalAmount"].ToString());
                    string pdate = (dt.Rows[0]["purchaseDate"].ToString()).ToString();
                    string ndate = DateTime.Parse(pdate).ToString("yyyy-MM-dd");
                    objPurchaseVM_Property.purchaseDate =Convert.ToDateTime( ndate);// DateTime.Parse(dt.Rows[0]["mrnDate"].ToString()).ToString("yyyy-MM-dd");
                    //DateTime.Parse(dt.Rows[0]["mrnDate"].ToString()).ToString("yyyy-MM-dd");
                    //foreach(DataRow dr in dt.Rows)
                    //{
                    //    objmrndetail

                    //}
                    ViewBag.DetailData = Helper.ConvertDataTable<PurchaseVM_Property>(dt);
                    //update
                    return View("AddNewPurchase", objPurchaseVM_Property);
                }
                else
                {
                    //objPurchaseProperty = new LP_Purchase_Master_Property();
                    objPurchaseVM_Property.createdByUserIdx = Convert.ToInt16(Session["UID"].ToString());
                     objpurchaseBll = new LP_Purchase_BLL();
                    LP_GenerateTransNumber_Property objtrans = new LP_GenerateTransNumber_Property();
                    objtrans.TableName = "purchase";
                    objtrans.Identityfieldname = "idx";
                    objtrans.userid = Session["UID"].ToString();
                    objPurchaseVM_Property.poNumber = objpurchaseBll.GeneratePO(objtrans);
                    //objPurchaseProperty.poNumber = "";
                    //objpurchaseBll = new LP_Purchase_BLL(objPurchaseProperty);
                    //objPurchaseVM_Property.poNumber = objpurchaseBll.GeneratePO();// "PO-001";
                    // string po = objpurchaseBll.GeneratePO();

                    return View("AddNewPurchase", objPurchaseVM_Property);

                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
           
        }
        [HttpPost]
        public JsonResult AddUpdate(PurchaseVM_Property objpurchase)
        {
            try
            {
                bool flag = false;
                int mrnIdx;
                int.TryParse(objpurchase.MRNIdx.ToString() , out mrnIdx);
                objPurchaseProperty = new LP_Purchase_Master_Property();
                objPurchaseProperty.poNumber = objpurchase.poNumber;
                objPurchaseProperty.vendorIdx = objpurchase.vendorIdx;
                objPurchaseProperty.purchaseTypeIdx = objpurchase.purchaseTypeIdx;
                objPurchaseProperty.purchaseDate = objpurchase.purchaseDate;
                objPurchaseProperty.description = objpurchase.description;
                objPurchaseProperty.totalAmount = objpurchase.totalAmount;
                objPurchaseProperty.netAmount = objpurchase.netAmount;
                objPurchaseProperty.paidAmount = objpurchase.paidAmount;
                objPurchaseProperty.balanceAmount = objpurchase.balanceAmount;
               
                objPurchaseProperty.MRNIdx = mrnIdx;
                objPurchaseProperty.DepartmentID = objpurchase.DepartmentID;
                //  objPurchaseProperty.paidDate = ;// objpurchase.paidDate;

                objPurchaseProperty.DetailData =Helper.ToDataTable<PurchaseDetails_Property>(objpurchase.PurchaseDetailLST);
                if (objpurchase.idx > 0)
                {
                    objPurchaseProperty.idx = objpurchase.idx;
                    objPurchaseProperty.creationDate = DateTime.Now;
                    objPurchaseProperty.visible = 1;
                    objPurchaseProperty.createdByUserIdx = Convert.ToInt16(Session["UID"].ToString());
                    objPurchaseProperty.visible = 1;
                    objPurchaseProperty.status = "0";
                    objPurchaseProperty.TableName = "purchaseDetails";
                    objpurchaseBll = new LP_Purchase_BLL(objPurchaseProperty);
                    flag = objpurchaseBll.Insert();
                    //update
                }
                else
                {
                    //add
                    objPurchaseProperty.creationDate = DateTime.Now;
                    objPurchaseProperty.visible =1;
                    objPurchaseProperty.createdByUserIdx =Convert.ToInt16(Session["UID"].ToString());
                    objPurchaseProperty.visible = 1;
                    objPurchaseProperty.status = "0";
                    objPurchaseProperty.TableName = "purchaseDetails";
                    objpurchaseBll = new LP_Purchase_BLL(objPurchaseProperty);
                    flag = objpurchaseBll.Insert();

                }
                return Json(new { data = "", success = flag,msg=flag==true?"Successfull":"Failed" ,statuscode = flag == true ? 200 : 401 }, JsonRequestBehavior.AllowGet);
               
            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }
        }

        // Delete PO
        public JsonResult Delete(int? id)
        {
            if (Session["LOGGEDIN"] != null)
            {
                try
                {
                    objPurchaseProperty = new LP_Purchase_Master_Property();
                    objPurchaseProperty.idx = int.Parse(id.ToString());

                    objpurchaseBll = new LP_Purchase_BLL(objPurchaseProperty);
                    var flag1 = objpurchaseBll.Delete();
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

        public JsonResult SelectPOById(int id)
        {
            if (Session["LOGGEDIN"] != null)
            {
                try
                {
                    objPurchaseProperty = new LP_Purchase_Master_Property();
                    objPurchaseProperty.idx = id;

                    objpurchaseBll = new LP_Purchase_BLL(objPurchaseProperty);
                    var Data = JsonConvert.SerializeObject(objpurchaseBll.SelectOne());
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
        public JsonResult SelectMRById(int id)
        {
            if (Session["LOGGEDIN"] != null)
            {
                try
                {
                   var objPurchaseProperty = new LP_MRN_Master_Property();
                    objPurchaseProperty.idx = id;

                    var objpurchaseBll = new LP_MRN_BLL(objPurchaseProperty);
                    var Data = JsonConvert.SerializeObject(objpurchaseBll.SelectById());
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
        public ActionResult Action()
        {
            return View();
        }
    }
}