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
   public class AchivementProductDetail_BLL
    {
       private AchivementProductDetail_Property objAProductDetailProperty;
       private AchivementProductDetail_DAL objAProductDetailDAL;

       public AchivementProductDetail_BLL(AchivementProductDetail_Property objAProductDetail_Property)
        {
            objAProductDetailProperty = objAProductDetail_Property;
        }

       public DataTable GetProductDetailbyMasterID()
       {
           objAProductDetailDAL = new AchivementProductDetail_DAL(objAProductDetailProperty);
           return objAProductDetailDAL.GetProductDetailbyMasterID();
       }

       public bool Insert()
       {
           objAProductDetailDAL = new AchivementProductDetail_DAL(objAProductDetailProperty);
           return objAProductDetailDAL.Insert();
       }
    }
}
