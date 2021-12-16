using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Setups;
using SSS.DAL;
using SSS.DAL.Setups;
using System.Data;
using System.Xml;
using System.Xml.Linq;

namespace SSS.BLL.Setups
{
    public class Company_BLL
    {
        private Company_Property objCompanyProperty;
        private Company_DAL objCompanyDAL;

        public Company_BLL()
        {
            

        }
        public Company_BLL(Company_Property obCompany_Property)
        {
            objCompanyProperty = obCompany_Property;

        }
        public DataTable ViewAll()
        {
            objCompanyDAL = new Company_DAL(objCompanyProperty);
            return objCompanyDAL.SelectAll();
        }

        public DataTable GetCompanyById()
        {
            objCompanyDAL = new Company_DAL(objCompanyProperty);
            return objCompanyDAL.SelectById();
        }
        public bool Insert()
        {
            objCompanyDAL = new Company_DAL(objCompanyProperty);
            return objCompanyDAL.Insert();
        }
        public bool Update()
        {
            objCompanyDAL = new Company_DAL(objCompanyProperty);
            return objCompanyDAL.Update();
        }
        //public DataTable ViewByDistributer_ID(int DistributerID)
        //{
        //    objCompanyDAL = new Company_DAL(objCompanyProperty);
        //    return objCompanyDAL.SelectByDistributerID(DistributerID);
        //}

        public DataTable ViewAll(string xmlpath)
        {

            // load your xml file (this one is named people and it is in my App_Data folder)
            XElement x = XElement.Load(xmlpath);//get your file
            // declare a new DataTable and pass your XElement to it
          
            
            objCompanyDAL = new Company_DAL(objCompanyProperty);
            return objCompanyDAL.XElementToDataTable(x);
        }

        //public string UpdateCompanyXML()
        //{
        //    objCompanyDAL = new Company_DAL(objCompanyProperty);
        //    return objCompanyDAL.UpdateCompanyXML();
        //}
    }   
}
