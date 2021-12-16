using SSS.BLL.Setups;
using SSS.DAL.Setups;
using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.BLL.Setups
{
    public class Vendors_BLL
    {
        private Vendors_DAL objVendors_DAL;
        private Vendors_Property objVendorsProperty;

        private int? id;

        public Vendors_BLL()
        {
            

        }
        public Vendors_BLL(Vendors_Property objVendors_Property)
        {
            objVendorsProperty = objVendors_Property;

        }
        public Vendors_BLL(int? id)
        {
            this.id = id;
        }
        public DataTable ViewAll()
        {
            objVendors_DAL = new Vendors_DAL(objVendorsProperty);
            return objVendors_DAL.SelectAll();
        }
        // For Main Listings
        public DataTable ViewAllVendors()
        {
            objVendors_DAL = new Vendors_DAL(objVendorsProperty);
            return objVendors_DAL.SelectAllVendors();
        }

        public DataTable ViewAllVendorByType(int id) //if send id is one then local and if 2 then internation hardcoded
        {
            objVendors_DAL = new Vendors_DAL(objVendorsProperty);
            return objVendors_DAL.SelectAllByType(id);
        }
        public DataTable ddlVendorsType()
        {
            objVendors_DAL = new Vendors_DAL(objVendorsProperty);
            return objVendors_DAL.ddlVendorsType();
        }
        public DataTable ddlCategory()
        {
            objVendors_DAL = new Vendors_DAL(objVendorsProperty);
            return objVendors_DAL.ddlCategory();
        }
        public DataTable getVendorPrice(int id)
        {
            objVendors_DAL = new Vendors_DAL(objVendorsProperty);
            return objVendors_DAL.selectVendorPrice(id);
        }

        public DataTable GetByCatId(int? id)
        {
            objVendors_DAL = new Vendors_DAL(objVendorsProperty);
            return objVendors_DAL.SelectByCatId(id);
        }

        public DataTable GetById(int? id)
        {
            objVendors_DAL = new Vendors_DAL(objVendorsProperty);
            return objVendors_DAL.SelectById(id);
        }
        public bool Insert()
        {
            objVendors_DAL = new Vendors_DAL(objVendorsProperty);
            return objVendors_DAL.Insert();
        }
        public bool Update()
        {
            objVendors_DAL = new Vendors_DAL(objVendorsProperty);
            return objVendors_DAL.Update();
        }
        public bool Delete(int? id)
        {
            objVendors_DAL = new Vendors_DAL(objVendorsProperty);
            return objVendors_DAL.Delete(id);
        }
        public string GenerateSO(LP_GenerateTransNumber_Property objtransno)
        {
            string TransactionNumber = "";
            objVendors_DAL = new Vendors_DAL(objVendorsProperty);
            DataTable dt = objVendors_DAL.GenerateSONo(objtransno);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TransactionNumber = dr["TransNumber"].ToString();
                    TransactionNumber = "V-00" + (int.Parse(TransactionNumber) + 1) + "-" + objtransno.userid;


                }
                return TransactionNumber;
            }
            else
            {

                TransactionNumber = "V-001-" + objtransno.userid;

                return TransactionNumber;
            }
        }
    }
}
