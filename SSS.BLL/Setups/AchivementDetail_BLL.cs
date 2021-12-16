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
    public class AchivementDetail_BLL
    {
        private AchivementDetail_Property objAchivementDetailProperty;
        private AchivementDetail_DAL objAchivementDetailDAL;

        public AchivementDetail_BLL(AchivementDetail_Property objAchivementDetail_Property)
        {
            objAchivementDetailProperty = objAchivementDetail_Property;
        }

        public int Insert()
        {
            objAchivementDetailDAL = new AchivementDetail_DAL(objAchivementDetailProperty);
            return objAchivementDetailDAL.InsertSlabDetail();
        }

        public DataTable GetSlabDetailbyMasterID()
        {
            objAchivementDetailDAL = new AchivementDetail_DAL(objAchivementDetailProperty);
            return objAchivementDetailDAL.GetSlabDetailbyMasterID();
        }


        public bool validateAchivementSlab(int MasterId, int slabID, decimal fromQty, decimal toQty)
        {
            objAchivementDetailDAL = new AchivementDetail_DAL(objAchivementDetailProperty);
            return objAchivementDetailDAL.validateAchivementSlab(MasterId, slabID, fromQty, toQty);
        }

        public DataTable AchivementDetailByID()
        {
            objAchivementDetailDAL = new AchivementDetail_DAL(objAchivementDetailProperty);
            return objAchivementDetailDAL.GetSlabDetailByID();
        }

        public int Update()
        {
            objAchivementDetailDAL = new AchivementDetail_DAL(objAchivementDetailProperty);
            return objAchivementDetailDAL.UpdateSlabDetail();
        }

    }
}
