using Newtonsoft.Json;
using SSS.BLL.Setups;
using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using SSS.Utility;

namespace SMSYSTEM.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Product
        Product_BLL objProductBLL = new Product_BLL();
        Product_Property objProductProperty;
        public ActionResult ViewProduct()
        {
            //GenerateReport();
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string pagename = @"/" + controllerName + @"/" + actionName;
            var page = (List<LP_Pages_Property>)Session["PageList"];

            if (Session["LoggedIn"] != null && Helper.CheckPageAccess(pagename, page))
            {
                DataTable categories = objProductBLL.ddlCategory();
                List<Product_Category_Property> catLST = new List<Product_Category_Property>();
                foreach (DataRow dr in categories.Rows)
                {
                    Product_Category_Property objProductCat = new Product_Category_Property();
                    objProductCat.Category = dr["category"].ToString();
                    objProductCat.idx = Convert.ToInt32(dr["idx"].ToString());
                    objProductCat.HSCodeCat = (dr["HSCodeCat"].ToString());
                    catLST.Add(objProductCat);
                }
                ViewBag.catLST = catLST;
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

        public JsonResult GetAllProducts()
        {
            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                    objProductProperty = new Product_Property();
                    //objProductProperty.branchIdx = 1;//user logged in session branchIdx
                    objProductBLL = new Product_BLL(objProductProperty);
                    var Data = JsonConvert.SerializeObject(objProductBLL.ViewAll());
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

        public ActionResult AddNewProduct(int? id)
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string pagename = @"/" + controllerName + @"/" + actionName;
            var page = (List<LP_Pages_Property>)Session["PageList"];

            if (Session["LoggedIn"] != null && Helper.CheckPageAccess(pagename, page))
            {

                Product_Property objProductVm = new Product_Property();
                objProductVm.idx = Convert.ToInt32(id);
                objProductProperty = new Product_Property();
                objProductProperty.idx = objProductVm.idx;// Convert.ToInt32(id);
                //objProductProperty.branchIdx = 1;//It will have the value of session branchIdx
                objProductBLL = new Product_BLL(objProductProperty);
                DataTable categories = objProductBLL.ddlCategory();
                List<Product_Category_Property> catLST = new List<Product_Category_Property>();
                DataTable subCategories = objProductBLL.ddlSubCategory();
                List<Product_SubCategory_Property> subCatLST = new List<Product_SubCategory_Property>();
                DataTable productTypes = objProductBLL.ddlProductType();
                List<Product_Type_Property> productTypeLST = new List<Product_Type_Property>();
                DataTable units = objProductBLL.ddlUnit();
                List<itemUnit_Property> unitLST = new List<itemUnit_Property>();
                List<LP_Products_Picture> LSTProductsPicture = new List<LP_Products_Picture>();
                foreach (DataRow dr in categories.Rows)
                {
                    Product_Category_Property objProductCat = new Product_Category_Property();
                    objProductCat.Category = dr["category"].ToString();
                    objProductCat.idx = Convert.ToInt32(dr["idx"].ToString());
                    objProductCat.HSCodeCat = (dr["HSCodeCat"].ToString());
                    catLST.Add(objProductCat);
                }
                ViewBag.catLST = catLST;
                ViewBag.categoryLST = JsonConvert.SerializeObject(catLST);
                foreach (DataRow dr in subCategories.Rows)
                {
                    Product_SubCategory_Property objProductCat = new Product_SubCategory_Property();
                    objProductCat.subCategory = dr["subCategory"].ToString();
                    objProductCat.product_catIdx = int.Parse(dr["product_catIdx"].ToString());
                    objProductCat.idx = Convert.ToInt32(dr["idx"].ToString());
                    objProductCat.HS_CodeSub = dr["HS_CodeSub"].ToString();
                    subCatLST.Add(objProductCat);
                }
                ViewBag.subCatLST = subCatLST;
                ViewBag.subcategoryLST = JsonConvert.SerializeObject(subCatLST);
                foreach (DataRow dr in productTypes.Rows)
                {
                    Product_Type_Property objProductCat = new Product_Type_Property();
                    objProductCat.productType = dr["productType"].ToString();
                    objProductCat.idx = Convert.ToInt32(dr["idx"].ToString());
                    productTypeLST.Add(objProductCat);
                }
                ViewBag.productTypeLST = productTypeLST;
                foreach (DataRow dr in units.Rows)
                {
                    itemUnit_Property objProductCat = new itemUnit_Property();
                    objProductCat.itemUnit = dr["itemUnit"].ToString();
                    objProductCat.idx = Convert.ToInt32(dr["idx"].ToString());
                    unitLST.Add(objProductCat);
                }
                ViewBag.unitLST = unitLST;
                // Update
                if (id != null && id != 0)
                {
                    decimal cp, sp, pt;
                    var dt = objProductBLL.GetById(id);
                    //objProductProperty.companyIdx = 1;
                    objProductVm.idx = int.Parse(dt.Rows[0]["idx"].ToString());
                    objProductVm.productTypeIdx = int.Parse(dt.Rows[0]["productTypeIdx"].ToString());
                    objProductVm.productCatIdx = int.Parse(dt.Rows[0]["productCatIdx"].ToString());
                    objProductVm.productSubCatIdx = int.Parse(dt.Rows[0]["productSubCatIdx"].ToString());
                    objProductVm.unitIdx = int.Parse(dt.Rows[0]["unitIdx"].ToString());
                    objProductVm.HSCODE = (dt.Rows[0]["HSCODE"].ToString());
                    objProductVm.itemCode = (dt.Rows[0]["itemCode"].ToString());
                    objProductVm.itemName = (dt.Rows[0]["itemName"].ToString());
                    objProductVm.description = (dt.Rows[0]["description"].ToString());
                    //objProductProperty.costPrice = 0.00m;
                    string costPrice = (dt.Rows[0]["costPrice"].ToString());
                    decimal.TryParse(costPrice, out cp);
                    objProductVm.costPrice = cp;
                    string salePrice = (dt.Rows[0]["salePrice"].ToString());
                    decimal.TryParse(salePrice, out sp);
                    objProductVm.salePrice = sp;                    
                    string productTax = (dt.Rows[0]["productTax"].ToString());
                    decimal.TryParse(productTax, out pt);
                    objProductVm.productTax = pt;
                    // Added By Ahsan
                    objProductVm.Reference = (dt.Rows[0]["Reference"].ToString());


                    foreach (DataRow dr in units.Rows)
                    {
                        itemUnit_Property objProductCat = new itemUnit_Property();
                        objProductCat.itemUnit = dr["itemUnit"].ToString();
                        objProductCat.idx = Convert.ToInt32(dr["idx"].ToString());
                        unitLST.Add(objProductCat);
                    }
                    ViewBag.unitLST = unitLST;


                    DataTable ProdctPic = objProductBLL.GetPicturesById(id);
                  
                    foreach (DataRow dr in ProdctPic.Rows)
                    {
                        LP_Products_Picture objprdctpic = new LP_Products_Picture();
                        objprdctpic.PicturePath= dr["PicturePath"].ToString();
                        LSTProductsPicture.Add(objprdctpic);
                        //objProductVm.ProductPicPath[i] = dr["PicturePath"].ToString();
                        
                    }
                    ViewBag.ProductPics = LSTProductsPicture;
                    //
                    //objProductProperty.product_catIdx = int.Parse(dt.Rows[0]["product_catIdx"].ToString());
                    //objProductProperty.subCategory = dt.Rows[0]["subCategory"].ToString();
                    //objProductProperty.HS_CodeSub = dt.Rows[0]["HS_CodeSub"].ToString();
                    ////objProductProperty.firstName = dt.Rows[0]["firstName"].ToString();
                    //objProductProperty.lastName = dt.Rows[0]["lastName"].ToString();
                    //objProductProperty.CNIC = (dt.Rows[0]["CNIC"].ToString());
                    //objProductProperty.cellNumber = (dt.Rows[0]["cellNumber"].ToString());
                    //objProductProperty.loginId = (dt.Rows[0]["loginId"].ToString());
                    //objProductProperty.password = dt.Rows[0]["password"].ToString();
                }
                else
                {

                    ViewBag.ProductPics = LSTProductsPicture;
                    objProductVm.ProductPicPath = new string[0];
                    LP_GenerateTransNumber_Property objtrans = new LP_GenerateTransNumber_Property();
                    objtrans.TableName = "products";
                    objtrans.Identityfieldname = "idx";
                    objtrans.userid = Session["UID"].ToString();
                    objProductVm.itemCode = objProductBLL.GenerateProductCode(objtrans);
                }


                return PartialView("_AddNewProduct", objProductVm);
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
        public JsonResult AddUpdate(Product_Property objproduct)
        {
            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                    string[] picturepath;
                    if (objproduct.idx > 0)
                    {

                        objproduct.lastModifiedByUserIdx = Convert.ToInt32(Session["UID"].ToString());
                        objproduct.lastModificationDate = DateTime.Now.ToString("dd/MM/yyyy");
                        List<LP_Products_Picture> toFindDeletedImages = objproduct.ProductPictureList;
                        if (objproduct.PicturePath != null)
                        {
                            picturepath = SavePicture(objproduct.PicturePath);
                            objproduct.ProductPictureList = new List<LP_Products_Picture>();
                            for (int i = 0; i < picturepath.Length; i++)
                            {
                                LP_Products_Picture objprflepicpth = new LP_Products_Picture();
                                objprflepicpth.PicturePath = picturepath[i].ToString();
                                objproduct.ProductPictureList.Add(objprflepicpth);
                            }
                        }
                        //objProductProperty = JsonConvert.DeserializeObject<Product_Property>(JsonConvert.SerializeObject(objproduct)); 
                        if(toFindDeletedImages != null)
                        {

                            List<LP_Products_Picture> ExistingImages = new List<LP_Products_Picture>();
                            DataTable ProdctPic = objProductBLL.GetPicturesById(objproduct.idx);
                            
                            foreach (DataRow dr in ProdctPic.Rows)
                            {
                                LP_Products_Picture objprflepicpth = new LP_Products_Picture();
                                objprflepicpth.PicturePath = dr["PicturePath"].ToString();
                                objprflepicpth.ID = Convert.ToInt16(dr["Id"].ToString());
                                ExistingImages.Add(objprflepicpth);
                            }

                            List<int> imagestoDelete = new List<int>();
                            for (int i = 0; i < ExistingImages.Count; i++)
                            {
                                var t = toFindDeletedImages
                                    .Any(x => x.PicturePath == ExistingImages[i].PicturePath);
                                if (t == false)
                                {
                                    imagestoDelete.Add(ExistingImages[i].ID);
                                }
                            }

                            //foreach (LP_Products_Picture existingImage in ExistingImages)
                            //{
                            //    var t = toFindDeletedImages
                            //        .Where(x => x.PicturePath == existingImage.PicturePath);
                            //    if (t == false)
                            //    {
                            //        imagestoDelete.Add(existingImage.ID);
                            //    }
                            //}
                            objProductBLL = new Product_BLL(imagestoDelete);
                            objProductBLL.DeleteProductsImages();
                            //objproduct.ProductPictureList = new List<LP_Products_Picture>();
                            //for (int i = 0; i < picturepath.Length; i++)
                            //{
                            //    LP_Products_Picture objprflepicpth = new LP_Products_Picture();
                            //    objprflepicpth.PicturePath = picturepath[i].ToString();

                            //    objproduct.ProductPictureList.Add(objprflepicpth);
                            //}
                        }
                        objProductBLL = new Product_BLL(objproduct);

                        bool flag = objProductBLL.Update();
                        return Json(new { data = "Updated", success = flag, statuscode = 200 }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                       

                        //objProductCategory.companyIdx = 1;
                        objproduct.createdByUserIdx = Convert.ToInt32(Session["UID"].ToString());

                        //objProductProperty = JsonConvert.DeserializeObject<Product_Property>(JsonConvert.SerializeObject(objproduct));
                        if (objproduct.PicturePath != null)
                        {
                           
                            picturepath = SavePicture(objproduct.PicturePath);
                            
                            objproduct.ProductPictureList = new List<LP_Products_Picture>();
                            for(int i = 0; i < picturepath.Length; i++)
                            {
                                LP_Products_Picture objprflepicpth = new LP_Products_Picture();
                                objprflepicpth.PicturePath = picturepath[i].ToString();
                                objproduct.ProductPictureList.Add(objprflepicpth);
                            }
                            
                        }
                        objProductBLL = new Product_BLL(objproduct);
                        
                        //if (objProductCategory.isMainBranch == 1)
                        //{
                        //    var check = objProductCategory.MainBranch();
                        //    if (check.Rows.Count > 0)
                        //    {
                        //        return Json(new { data = "Main Branch Already Exist", success = false, statuscode = 500 }, JsonRequestBehavior.AllowGet);
                        //    }
                        //}

                        bool flag = objProductBLL.Insert();
                        
                        return Json(new { data = "Inserted", success = flag, statuscode = 200 }, JsonRequestBehavior.AllowGet);
                    }


                }
                catch (Exception ex)
                {
                    return Json(new { data = ex.Message+"-"+ex.InnerException.ToString(), success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { data = "Session Expired", success = false, statuscode = 400, count = 0 }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Delete(int? id)
        {
            if (Session["LOGGEDIN"] != null)
            {

                try
                {
                    if (id > 0)
                    {

                        Product_Property branchProperty = new Product_Property();
                        branchProperty.idx = int.Parse(id.ToString());
                        objProductBLL = new Product_BLL(id);
                        Product_BLL branhcBll = new Product_BLL(branchProperty);
                        var flag1 = branhcBll.Delete(id);
                        //if (flag1.Rows.Count > 0)
                        //{
                        if (true)
                        {
                            bool flag = objProductBLL.Delete(id);
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