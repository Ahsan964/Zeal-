using CrystalDecisions.CrystalReports.Engine;
using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSYSTEM.Controllers
{
    public class ReportController : BaseController
    {
        // GET: Report
        public ActionResult Index()
        {
            List<Product_Property> allCustomer = new List<Product_Property>();
            Product_Property objproduct;
            for (int i = 0; i < 10; i++)
            {
                objproduct = new Product_Property();
                objproduct.itemName = "ABC" + i;
                objproduct.itemCode = "ABCCODe" + i;
                objproduct.idx = i;
            }
            return View(allCustomer);
        }


        public ActionResult ExportCustomers()
        {
            List<Product_Property> allCustomer = new List<Product_Property>();
            Product_Property objproduct;
            for(int i = 0; i < 10; i++)
            {
                objproduct = new Product_Property();
                objproduct.itemName = "ABC" + i;
                objproduct.itemCode = "ABCCODe" + i;
                objproduct.idx = i;
            }


            ReportDocument rd = new ReportDocument();
            rd.Load(Server.MapPath("~/Reprts/Test.rpt"), "Test.rpt");

            rd.SetDataSource(allCustomer);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "CustomerList.pdf");
        }
    }
}