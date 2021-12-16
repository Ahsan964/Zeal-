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
    public class QuotationController : BaseController
    {
        // GET: Quotation
        QuotationVM_Property objQuotationVM_Property;
        LP_Quotation_Master_Property objQuotationProperty;
        LP_Quotation_BLL objquotationBll;
        public ActionResult ViewQuotation()
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
        public JsonResult GetAllQuotation()
        {
            try
            {
                objQuotationVM_Property = new QuotationVM_Property();
                objquotationBll = new LP_Quotation_BLL(objQuotationProperty);
                var Data = JsonConvert.SerializeObject(objquotationBll.SelectAll());
                return Json(new { data = Data, success = true, statuscode = 200, count = Data.Length }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }
        }
        
        public ActionResult AddQuotaion(int? id)
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string pagename = @"/" + controllerName + @"/" + actionName;
            var page = (List<LP_Pages_Property>)Session["PageList"];
            if (Session["LoggedIn"] != null && Helper.CheckPageAccess(pagename, page) && Session["ISADMIN"] != null)
            {
                // Added By Ahsan
                List<Product_Property> productList = new List<Product_Property>();
                DataTable products = ViewAllProducts();
                foreach (DataRow dr in products.Rows)
                {
                    Product_Property objproduct = new Product_Property();
                    objproduct.idx = Convert.ToInt32(dr["idx"].ToString());
                    objproduct.Reference = dr["Reference"].ToString();
                    objproduct.itemName = dr["itemName"].ToString();

                    productList.Add(objproduct);
                }
                ViewBag.productList = productList;

                objQuotationVM_Property = new QuotationVM_Property();

                Customers_Property customer = new Customers_Property();
                Product_Property product = new Product_Property();
                Customers_BLL objcustomerbll = new Customers_BLL();
                Product_BLL objProductbll = new Product_BLL();
                objQuotationVM_Property.CustomerLST = Helper.ConvertDataTable<Customers_Property>(objcustomerbll.ViewAllCustomers());
                objQuotationVM_Property.ProductList = Helper.ConvertDataTable<Product_Property>(objProductbll.ViewAll());
                Taxes_Property obj = new Taxes_Property();
                Taxes_BLL objtaxBLL = new Taxes_BLL(obj);
                ViewBag.TaxList = Helper.ConvertDataTable<Taxes_Property>(objtaxBLL.GetTaxesForCheckBox());
                //objQuotationVM_Property.QuotationDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                ////objQuotationVM_Property.poNumber = "Po-001";
                if (id > 0)
                {
                    LP_Quotation_Detail_Property objmQuotationdetail;
                    objQuotationProperty = new LP_Quotation_Master_Property();
                    objQuotationProperty.idx = Convert.ToInt16(id);

                    objquotationBll = new LP_Quotation_BLL(objQuotationProperty);
                    DataTable dt = objquotationBll.SelectOne();
                    objQuotationVM_Property.idx = Convert.ToInt16(dt.Rows[0]["quotationIdx"].ToString());
                    objQuotationVM_Property.customerIdx = Convert.ToInt16(dt.Rows[0]["customerIdx"].ToString());
                    objQuotationVM_Property.qsNumber = dt.Rows[0]["qsNumber"].ToString();
                    objQuotationVM_Property.description = dt.Rows[0]["description"].ToString();
                    objQuotationVM_Property.shippingCost = Convert.ToDecimal(dt.Rows[0]["shippingCost"].ToString());
                    objQuotationVM_Property.discount = Convert.ToDecimal(dt.Rows[0]["discount"].ToString());
                    objQuotationVM_Property.netAmount = Convert.ToDecimal(dt.Rows[0]["netAmount"].ToString());
                    objQuotationVM_Property.taxAount = Convert.ToDecimal(dt.Rows[0]["taxAount"].ToString());
                    objQuotationVM_Property.reference = dt.Rows[0]["reference"].ToString();

                    objQuotationVM_Property.totalAmount = Convert.ToDecimal(dt.Rows[0]["totalAmount"].ToString());
                    string pdate = (dt.Rows[0]["quotationDate"].ToString()).ToString();
                    string ndate = DateTime.Parse(pdate).ToString("yyyy-MM-dd");
                    objQuotationVM_Property.quotationDate = Convert.ToDateTime(ndate);// DateTime.Parse(dt.Rows[0]["mrnDate"].ToString()).ToString("yyyy-MM-dd");
                    //DateTime.Parse(dt.Rows[0]["mrnDate"].ToString()).ToString("yyyy-MM-dd");
                    //foreach(DataRow dr in dt.Rows)
                    //{
                    //    objmrndetail

                    //}
                    objQuotationVM_Property.QuotationDetailLST = Helper.ConvertDataTable<QuotationDetails_Property>(dt);

                    //update
                    return View("AddQuotaion", objQuotationVM_Property);//objQuotationVM_Property
                }
                else
                {
                    objQuotationVM_Property.createdByUserIdx = Convert.ToInt16(Session["UID"].ToString());
                    objquotationBll = new LP_Quotation_BLL();
                    LP_GenerateTransNumber_Property objtrans = new LP_GenerateTransNumber_Property();
                    objtrans.TableName = "quotation";
                    objtrans.Identityfieldname = "idx";
                    objtrans.userid = Session["UID"].ToString();
                    objQuotationVM_Property.qsNumber = objquotationBll.GeneratePO(objtrans);

                    return View("AddQuotaion", objQuotationVM_Property);//, objQuotationVM_Property

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

        public JsonResult AddUpdate(QuotationVM_Property objquotation)
        {
            try
            {
                bool flag = false;

                objQuotationProperty = new LP_Quotation_Master_Property();
                objQuotationProperty.qsNumber = objquotation.qsNumber;
                objQuotationProperty.customerIdx = objquotation.customerIdx;
               
                objQuotationProperty.quotationDate = objquotation.quotationDate;
                objQuotationProperty.description = objquotation.description;
                objQuotationProperty.totalAmount = objquotation.totalAmount;
                objQuotationProperty.netAmount = objquotation.netAmount;
                objQuotationProperty.paidAmount = objquotation.paidAmount;
                objQuotationProperty.balanceAmount = objquotation.balanceAmount;
                objQuotationProperty.taxAount = objquotation.taxAount;
                objQuotationProperty.reference = objquotation.reference;
                objQuotationProperty.shippingCost = objquotation.shippingCost;
                objQuotationProperty.discount = objquotation.discount;
                
                objQuotationProperty.salescheck = 0;
                //  objPurchaseProperty.paidDate = ;// objpurchase.paidDate;

                objQuotationProperty.DetailData = Helper.ToDataTable<QuotationDetails_Property>(objquotation.QuotationDetailLST);

                // Added By Ahsan
                //if (objquotation.salesTaxesLST != null)
                //{
                //    objQuotationProperty.SalesTaxData = Helper.ToDataTable<LP_salesTaxes_Property>(objquotation.salesTaxesLST);
                //}

                if (objquotation.idx > 0)
                {
                    objQuotationProperty.idx = objquotation.idx;
                    //objQuotationProperty.creationDate = DateTime.Now.ToString("dd/MM/yyyy");
                    objQuotationProperty.visible = 1;
                    objQuotationProperty.lastModificationDate = DateTime.Now.ToString("dd/MM/yyyy");

                    objQuotationProperty.createdByUserIdx = Convert.ToInt16(Session["UID"].ToString());
                    objQuotationProperty.lastModifiedByUserIdx = Convert.ToInt16(Session["UID"].ToString());
                    objQuotationProperty.visible = 1;
                    objQuotationProperty.status = "0";
                    objQuotationProperty.TableName = "quotaionDetails";
                    objquotationBll = new LP_Quotation_BLL(objQuotationProperty);
                    flag = objquotationBll.Insert();
                    //update
                }
                else
                {
                    //add
                    objQuotationProperty.creationDate = DateTime.Now;
                    objQuotationProperty.visible = 1;
                    objQuotationProperty.createdByUserIdx = Convert.ToInt16(Session["UID"].ToString());
                    objQuotationProperty.visible = 1;
                    objQuotationProperty.status = "0";
                    objQuotationProperty.TableName = "quotationDetails";
                    objquotationBll = new LP_Quotation_BLL(objQuotationProperty);
                    flag = objquotationBll.Insert();

                }
                return Json(new { data = "", success = flag, msg = flag == true ? "Successfull" : "Failed", statuscode = flag == true ? 200 : 401 }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }
        }

        // Delete function
        public JsonResult Delete(int? id)
        {
            if (Session["LOGGEDIN"] != null)
            {
                try
                {
                    objQuotationProperty = new LP_Quotation_Master_Property();
                    objQuotationProperty.idx = int.Parse(id.ToString());

                    LP_Quotation_BLL objBll = new LP_Quotation_BLL(objQuotationProperty);
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
    }
}