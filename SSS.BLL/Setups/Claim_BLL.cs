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
    public class Claim_BLL : GridCommandBase
    {
        private Claim_DAL objClaimDAL;
        private Claim_Property objClaimProperty;


        public Claim_BLL()
        { }
        public Claim_BLL(Claim_Property objClaim_Property)
        {
            objClaimProperty = objClaim_Property;
        }

        public DataSet ClaimFilters()
        {
            objClaimDAL = new Claim_DAL(objClaimProperty);
            return objClaimDAL.ClaimFilter();
        }

        public DataSet GetClaimPOS()
        {
            objClaimDAL = new Claim_DAL(objClaimProperty);
            return objClaimDAL.ClaimPOS();
        }

        public DataSet GetClaimPOSBySalesTypeIds()
        {
            objClaimDAL = new Claim_DAL(objClaimProperty);
            return objClaimDAL.ClaimPOSBySalesTypeIds();
        }        

        public DataTable GetAllPOS()
        {
            objClaimDAL = new Claim_DAL(objClaimProperty);
            return objClaimDAL.GetAllPOS();
        }

        public DataTable ViewAllTradeOfferClaims()
        {
            objClaimDAL = new Claim_DAL(objClaimProperty);
            return objClaimDAL.ViewAllTradeOfferClaims();
        }

        public bool GenerateClaim()
        {
            objClaimDAL = new Claim_DAL(objClaimProperty);
            return objClaimDAL.GenerateClaimDAL();
        }

        public bool GenerateOtherTypeClaim()
        {
            objClaimDAL = new Claim_DAL(objClaimProperty);
            return objClaimDAL.GenerateOtherTypeClaimDAL();
        }

        public bool Insert()
        {
            objClaimDAL = new Claim_DAL(objClaimProperty);
            return objClaimDAL.Insert();
        }

        public bool ClaimStatusUpdateBLL()
        {
            objClaimDAL = new Claim_DAL(objClaimProperty);
            return objClaimDAL.ClaimStatusUpdateDAL();
        }
        
        public DataTable SelectAll()
        {
            objClaimDAL = new Claim_DAL(objClaimProperty);
            return objClaimDAL.SelectAll();
        }

        public override void UpdateStatus()
        {
            Claim_Property objClaimPropertyNew = new Claim_Property();
            objClaimPropertyNew.ID = base.Id;
            objClaimPropertyNew.Status = base.Status;
            objClaimPropertyNew.TableName = objClaimProperty.TableName;
            objClaimPropertyNew.Operated_By = objClaimProperty.Operated_By;           
            objClaimDAL = new Claim_DAL(objClaimPropertyNew);
            objClaimDAL.UpdateStatus();
         
        }

        public DataTable GetTradeOfferClaim(string ClaimStatus)
        {
            objClaimDAL = new Claim_DAL(objClaimProperty);
            return objClaimDAL.GetTradeOfferClaim(ClaimStatus);
        }

        public DataTable GetClaimGetByTypeAndDateBLL()
        {
            objClaimDAL = new Claim_DAL(objClaimProperty);
            return objClaimDAL.GetClaimGetByTypeAndDateDAL();
        }        

        public DataTable GetSaleTypeClaim(string ClaimStatus)
        {
            objClaimDAL = new Claim_DAL(objClaimProperty);
            return objClaimDAL.GetSaleTypeClaim(ClaimStatus);
        }

        public DataTable GetTradeOfferClaimbyPOS(string ClaimStatus, string POSID)
        {
            objClaimDAL = new Claim_DAL(objClaimProperty);
            return objClaimDAL.GetTradeOfferClaimbyPOS(ClaimStatus, POSID);
        }

        public DataTable GetSaleTypeClaimbyPOS(string ClaimStatus, string POSID)
        {
            objClaimDAL = new Claim_DAL(objClaimProperty);
            return objClaimDAL.GetSaleTypeClaimbyPOS(ClaimStatus, POSID);
        }


        public DataSet GetPOSWiseClaimDetail(int pageIndex, int pageSize, out int recordCount)
        {
            objClaimDAL = new Claim_DAL(objClaimProperty);
            return objClaimDAL.GetPOSWiseClaimDetail(pageIndex, pageSize,out recordCount);
        }

        public DataTable GetCMWiseClaimDetail(int pageIndex, int pageSize, out int recordCount)
        {
            objClaimDAL = new Claim_DAL(objClaimProperty);
            return objClaimDAL.GetCMWiseClaimDetail(pageIndex, pageSize, out recordCount);
        }

        public DataTable GetClaimsForApproval(int pageIndex, int pageSize, out int recordCount)
        {
            objClaimDAL = new Claim_DAL(objClaimProperty);
            return objClaimDAL.GetClaimsForApproval(pageIndex, pageSize, out recordCount);
        }

        public bool ClaimApproval()
        {
            objClaimDAL = new Claim_DAL(objClaimProperty);
            return objClaimDAL.ClaimApproval();
        }

        public DataSet GetClaimReport()
        {
            objClaimDAL = new Claim_DAL(objClaimProperty);
            return objClaimDAL.GetClaimReport();
        }
    }
}
 