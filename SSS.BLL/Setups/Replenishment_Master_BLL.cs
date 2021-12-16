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
    public class Replenishment_Master_BLL : GridCommandBase
    {
        private Replenishment_Master_DAL objReplenishmentMasterDAL;
        private Replenishment_Master_Property objReplenishmentMasterProperty;

        public Replenishment_Master_BLL(Replenishment_Master_Property objReplenishment_Master_Property)
        {
            objReplenishmentMasterProperty = objReplenishment_Master_Property;
        }

        public bool ADD()
        {
            objReplenishmentMasterDAL = new Replenishment_Master_DAL(objReplenishmentMasterProperty);
            return objReplenishmentMasterDAL.Insert();
        }

        public DataTable GetGenerateNeededStockBll()
        {
            objReplenishmentMasterDAL = new Replenishment_Master_DAL(objReplenishmentMasterProperty);
            return objReplenishmentMasterDAL.GetGenerateNeededStock();
        }

        public DataTable GetGenerateNeededStockMultiDistributorAndProductBll()
        {
            objReplenishmentMasterDAL = new Replenishment_Master_DAL(objReplenishmentMasterProperty);
            return objReplenishmentMasterDAL.GetGenerateNeededStockMultiDistributorAndProduct();
        }

        public DataTable GetDistributorAgainstMultipleIdsBll()
        {
            objReplenishmentMasterDAL = new Replenishment_Master_DAL(objReplenishmentMasterProperty);
            return objReplenishmentMasterDAL.GetDistributorAgainstMultipleIds();
        }

        public override void UpdateStatus()
        {
            Replenishment_Master_Property objReplenishmentMasterPropertyNew = new Replenishment_Master_Property();
            //objReplenishmentMasterPropertyNew.ID = base.Id;
            //objReplenishmentMasterPropertyNew.Status = base.Status;
            //objBatchSetupPropertyNew.TableName = objReplenishmentMasterProperty.TableName;

            objReplenishmentMasterDAL = new Replenishment_Master_DAL(objReplenishmentMasterPropertyNew);
            objReplenishmentMasterDAL.UpdateStatus();


        }

    }
}
