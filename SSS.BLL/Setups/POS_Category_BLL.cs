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
    public class POS_Category_BLL : GridCommandBase
    {
        private POS_Category_DAL objCatDAL;
        private POS_Category_Property objCatProperty;

        public POS_Category_BLL()
        {
        }

        public POS_Category_BLL(POS_Category_Property objCat_Property)
        {
            objCatProperty = objCat_Property;
        }

        public DataTable ViewAll()
        {
            objCatDAL = new POS_Category_DAL(objCatProperty);
            return objCatDAL.SelectAll();
        }

        public override void UpdateStatus()
        {
            
            POS_Category_Property objPOS_Category_Property = new POS_Category_Property();
            POS_Category_DAL objCatDAL = new POS_Category_DAL(objPOS_Category_Property);
            objPOS_Category_Property.ID = base.Id;
            objPOS_Category_Property.TableName = "POS_CATEGORY";
            objPOS_Category_Property.Operated_By = 1;
            objPOS_Category_Property.Status = base.Status;
            //objPOS_Category_Property.TableName = objPOS_Category_Property.TableName;

            objCatDAL = new POS_Category_DAL(objPOS_Category_Property);
             objCatDAL.UpdateStatus();
        }
        public bool ADD()
        {
            objCatDAL = new POS_Category_DAL(objCatProperty);
            return objCatDAL.Insert();
        }

        public bool Update()
        {
            objCatDAL = new POS_Category_DAL(objCatProperty);
            return objCatDAL.Update();
        }
    }
}
