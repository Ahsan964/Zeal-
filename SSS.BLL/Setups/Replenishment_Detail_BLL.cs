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
    public class Replenishment_Detail_BLL : GridCommandBase
    {
        private Replenishment_Detail_DAL objReplenishmentDetailDAL;
        private Replenishment_Detail_Property objReplenishmentDetailProperty;

        public Replenishment_Detail_BLL(Replenishment_Detail_Property objReplenishment_Detail_Property)
        {
            objReplenishmentDetailProperty = objReplenishment_Detail_Property;
        }

       

        public override void UpdateStatus()
        {
            Replenishment_Detail_Property objReplenishmentDetailPropertyNew = new Replenishment_Detail_Property();
            //objReplenishmentMasterPropertyNew.ID = base.Id;
            //objReplenishmentMasterPropertyNew.Status = base.Status;
            //objBatchSetupPropertyNew.TableName = objReplenishmentMasterProperty.TableName;

            objReplenishmentDetailDAL = new Replenishment_Detail_DAL(objReplenishmentDetailPropertyNew);
            objReplenishmentDetailDAL.UpdateStatus();


        }

    }
}
