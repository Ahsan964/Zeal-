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
    public class Final_Product_Selection_BLL : GridCommandBase
    {
        private Final_Product_Selection_Property objFinalProductSelectionProperty;
        private Final_Product_Selection_DAL objFinalProductSelectionDAL;
        public Final_Product_Selection_BLL()
        {
            
        }

        public Final_Product_Selection_BLL(Final_Product_Selection_Property objFinalProductSelection_Property)
        {
            objFinalProductSelectionProperty = objFinalProductSelection_Property;
        }

        public DataTable View()
        {
            objFinalProductSelectionDAL = new Final_Product_Selection_DAL(objFinalProductSelectionProperty);
            return objFinalProductSelectionDAL.Select();
        }

        public DataTable ViewProduct()
        {
            objFinalProductSelectionDAL = new Final_Product_Selection_DAL(objFinalProductSelectionProperty);
            return objFinalProductSelectionDAL.ViewProduct();
        }

        

        public DataTable ViewProductForCashMemo()
        {
            objFinalProductSelectionDAL = new Final_Product_Selection_DAL(objFinalProductSelectionProperty);
            return objFinalProductSelectionDAL.ViewProductForCashMemo();
        }

        public override void UpdateStatus()
        {
            throw new NotImplementedException();
        }
    }
}
