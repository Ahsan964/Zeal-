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
    public class MRNController : Controller
    {
        #region Changes
        MRNVM_Property objMRNVM_Property;
        LP_MRN_Master_Property objMRNProperty;
        LP_MRN_BLL objMRNBll;
        // GET: MRN
        public ActionResult ViewMRN()
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
        public JsonResult GetAllMRN()
        {
            try
            {
                objMRNProperty = new LP_MRN_Master_Property();
                objMRNBll = new LP_MRN_BLL(objMRNProperty);
                
                var Data = JsonConvert.SerializeObject(objMRNBll.SelectAll());
                return Json(new { data = Data, success = true, statuscode = 200, count = Data.Length }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult AddNewMRN(int? id)
        {
            if (Session["LOGGEDIN"] != null)
            {
                objMRNVM_Property = new MRNVM_Property();
                Vendors_Property vendor = new Vendors_Property();
                Product_Property product = new Product_Property();
                Vendors_BLL objvendorbll = new Vendors_BLL();
                Product_BLL objProductbll = new Product_BLL();
                
                //objMRNVM_Property.VendorLST = Helper.ConvertDataTable<Vendors_Property>(objvendorbll.ViewAll());
                objMRNVM_Property.ProductList = Helper.ConvertDataTable<Product_Property>(objProductbll.ViewAll());
                objMRNVM_Property.mrnDate = DateTime.Now.ToString("yyyy-MM-dd");
               
                if (id > 0)
                {
                    //update
                    LP_MRN_Detail_Property objmrndetail;
                    objMRNProperty = new LP_MRN_Master_Property();
                    objMRNProperty.idx = Convert.ToInt16(id);

                    objMRNBll = new LP_MRN_BLL(objMRNProperty);
                    DataTable dt= objMRNBll.SelectById();
                    objMRNVM_Property.idx =Convert.ToInt16(dt.Rows[0]["mrnIdx"].ToString());
                    objMRNVM_Property.description = dt.Rows[0]["description"].ToString();
                    objMRNVM_Property.mrNumber = dt.Rows[0]["mrNumber"].ToString();
                    objMRNVM_Property.mrnDate = DateTime.Parse(dt.Rows[0]["mrnDate"].ToString()).ToString("yyyy-MM-dd");
                    //foreach(DataRow dr in dt.Rows)
                    //{
                    //    objmrndetail

                    //}
                    ViewBag.DetailData = Helper.ConvertDataTable<MRNVM_Property>(dt);

                    return View("AddNewMRN", objMRNVM_Property);
                }
                else
                {
                    objMRNBll = new LP_MRN_BLL();
                    LP_GenerateTransNumber_Property objtrans = new LP_GenerateTransNumber_Property();
                    objtrans.TableName = "MRN";
                    objtrans.Identityfieldname = "idx";
                    objtrans.userid = Session["UID"].ToString();
                    objMRNVM_Property.mrNumber = objMRNBll.GenerateMRNNo(objtrans);
                    return View("AddNewMRN", objMRNVM_Property);

                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }
        [HttpPost]
        public JsonResult AddUpdate(MRNVM_Property objMRN)
        {
            try
            {
                bool flag = false;
                objMRNProperty = new LP_MRN_Master_Property();
                objMRNProperty.idx = objMRN.idx;
                objMRNProperty.mrNumber = objMRN.mrNumber;
                //objMRNProperty.vendorIdx = objMRN.vendorIdx;
                //objMRNProperty.MRNTypeIdx = objMRN.MRNTypeIdx;
                objMRNProperty.mrnDate = DateTime.Parse(objMRN.mrnDate);
                if (objMRN.description!=null)
                {
                    objMRNProperty.description = objMRN.description;
                }
                else
                {
                    objMRNProperty.description = "";
                }
               // objMRNProperty.description = objMRN.description.Length>0? objMRN.description : "";

                //  objMRNProperty.paidDate = ;// objMRN.paidDate;

                objMRNProperty.DetailData = Helper.ToDataTable<mrnDetails_Property>(objMRN.MrnDetailsLST);
                if (objMRN.idx > 0)
                {
                    //objMRNProperty.creationDate = DateTime.Now;
                    //objMRNProperty.visible = 1;
                    //// objMRNProperty.status = "0";
                    //objMRNProperty.createdByUserIdx = Convert.ToInt16(Session["UID"].ToString());
                    objMRNProperty.creationDate = DateTime.Now;
                    objMRNProperty.lastModificationDate = DateTime.Now;
                    objMRNProperty.lastModifiedByUserIdx = Convert.ToInt16(Session["UID"].ToString());
                  //  objMRNVM_Property.createdByUserIdx = DateTime.Now; ;
                    objMRNProperty.TableName = "MRNDetails";
                    objMRNBll = new LP_MRN_BLL(objMRNProperty);
                    flag = objMRNBll.Insert();
                    //update
                }
                else
                {
                    //add
                    objMRNProperty.creationDate = DateTime.Now;
                    objMRNProperty.visible = 1;
                    objMRNProperty.status = "0";
                    objMRNProperty.createdByUserIdx = Convert.ToInt16(Session["UID"].ToString());
                   
                    objMRNProperty.TableName = "MRNDetails";
                    objMRNBll = new LP_MRN_BLL(objMRNProperty);
                    flag = objMRNBll.Insert();

                }
                return Json(new { data = "", success = flag, msg = flag == true ? "Successfull" : "Failed", statuscode = flag == true ? 200 : 401 }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }
        }



        #endregion
    }
}