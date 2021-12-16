using SSS.DAL.Setups;
using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.BLL.Setups
{
    public class Customers_BLL
    {
        private Customers_Property ObjCustomerProperty;
        private Customers_DAL ObjCustomerDAL;
        private int? id;
        public Customers_BLL()
        {

        }

        public Customers_BLL(Customers_Property ObjCustomer_Property)
        {
            ObjCustomerProperty = ObjCustomer_Property;
        }
        //public DataTable ViewMaxCustomerCode()
        //{
        //    ObjCustomerDAL = new Customers_DAL(ObjCustomerProperty);
        //    return ObjCustomerDAL.ViewMaxCustomerCode();
        //}
        public Customers_BLL(int? id)
        {
            this.id = id;
        }
        public bool Insert()
        {
            ObjCustomerDAL = new Customers_DAL(ObjCustomerProperty);
            return ObjCustomerDAL.Insert();
        }
        public DataTable ViewAllCustomers()
        {
            ObjCustomerDAL = new Customers_DAL(ObjCustomerProperty);
            return ObjCustomerDAL.SelectAll();
        }




        public DataTable GetCustomerType()
        {
            ObjCustomerDAL = new Customers_DAL(ObjCustomerProperty);
            return ObjCustomerDAL.ddlCustomersType();
        }
        //public DataTable View()
        //{
        //    ObjCustomerDAL = new Customers_DAL(ObjCustomerProperty);
        //    return ObjCustomerDAL.SelectOne();
        //}

        public DataTable GetCustomerById()
        {
            ObjCustomerDAL = new Customers_DAL(ObjCustomerProperty);
            return ObjCustomerDAL.SelectById();
        }

        public bool Update()
        {
            ObjCustomerDAL = new Customers_DAL(ObjCustomerProperty);
            return ObjCustomerDAL.Update();
        }
        public bool Delete(int? id)
        {
            ObjCustomerDAL = new Customers_DAL(ObjCustomerProperty);
            return ObjCustomerDAL.Delete(id);
        }
        public string GenerateSO(LP_GenerateTransNumber_Property objtransno)
        {
            string TransactionNumber = "";
            ObjCustomerDAL = new Customers_DAL(ObjCustomerProperty);
            DataTable dt = ObjCustomerDAL.GenerateSONo(objtransno);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TransactionNumber = dr["TransNumber"].ToString();
                    TransactionNumber = "C-00" + (int.Parse(TransactionNumber) + 1) + "-" + objtransno.userid;


                }
                return TransactionNumber;
            }
            else
            {

                TransactionNumber = "C-001-" + objtransno.userid;

                return TransactionNumber;
            }
        }
    }
}
