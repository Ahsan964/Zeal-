using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Setups;
using SSS.DAL;
using SSS.DAL.Setups;
using System.Data;

namespace SSS.BLL.Setups
{
    public class Printer_Setup_BLL
    {
        private Printer_Setup_Property objPrinterProperty;
        private Printer_Setup_DAL objPrinterDAL;

        public Printer_Setup_BLL(Printer_Setup_Property objPrinter_Property)
        {
            objPrinterProperty = objPrinter_Property;
        }

        public DataTable ViewByDistributer_ID()
        {
            
            objPrinterDAL = new Printer_Setup_DAL(objPrinterProperty);
            return objPrinterDAL.GetPrinterbyDistributorID();
        }

        public bool Insert()
        {
            objPrinterDAL = new Printer_Setup_DAL(objPrinterProperty);
            return objPrinterDAL.Insert();
        }


    }
}
