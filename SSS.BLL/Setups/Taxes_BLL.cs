using SSS.DAL.Setups;
using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SSS.BLL.Setups
{
    public class Taxes_BLL
    {
        private Taxes_Property objTaxesProperty;
        private Taxes_DAL objTaxesDAL;
        private int? id;
        public Taxes_BLL()
        {
            

        }

        public Taxes_BLL(Taxes_Property objTaxes_Property)
        {
            objTaxesProperty = objTaxes_Property;

        }
        public Taxes_BLL(int? id)
        {
            this.id = id;
        }
        public DataTable ViewAll()
        {
            objTaxesDAL = new Taxes_DAL(objTaxesProperty);
            return objTaxesDAL.SelectAll();
        }
        //public DataTable MainBranch()
        //{
        //    objTaxesDAL = new Taxes_DAL(objTaxesProperty);
        //    return objTaxesDAL.SelectAllMainBranch();
        //}
        public DataTable GetTaxesForCheckBox()
        {
            objTaxesDAL = new Taxes_DAL(objTaxesProperty);
            return objTaxesDAL.SelectAllTaxesForCheckBox();
        }
        public DataTable GetById()
        {
            objTaxesDAL = new Taxes_DAL(objTaxesProperty);
            return objTaxesDAL.SelectById();
        }
        public bool Insert()
        {
            objTaxesDAL = new Taxes_DAL(objTaxesProperty);
            return objTaxesDAL.Insert();
        }
        public bool Update()
        {
            objTaxesDAL = new Taxes_DAL(objTaxesProperty);
            return objTaxesDAL.Update();
        }

        public bool Delete(int? id)
        {
            objTaxesDAL = new Taxes_DAL(objTaxesProperty);
            return objTaxesDAL.Delete(id);
        }
        //public DataTable ViewByDistributer_ID(int DistributerID)
        //{
        //    objTaxesDAL = new Taxes_DAL(objCompanyProperty);
        //    return objTaxesDAL.SelectByDistributerID(DistributerID);
        //}

        public DataTable ViewAll(string xmlpath)
        {

            // load your xml file (this one is named people and it is in my App_Data folder)
            XElement x = XElement.Load(xmlpath);//get your file
                                                // declare a new DataTable and pass your XElement to it


            objTaxesDAL = new Taxes_DAL(objTaxesProperty);
            return objTaxesDAL.XElementToDataTable(x);
        }
    }
}
