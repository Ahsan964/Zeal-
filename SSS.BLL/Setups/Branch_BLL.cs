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
   public class Branch_BLL
    {
        private Branch_Property objBranchProperty;
        private Branch_DAL objBranchDAL;
        private int? id;

        public Branch_BLL( )
        {
           

        }
        public Branch_BLL(Branch_Property obCompany_Property)
        {
            objBranchProperty = obCompany_Property;

        }
        public Branch_BLL(int? id)
        {
            this.id = id;
        }
        public DataTable ViewAll()
        {
            objBranchDAL = new Branch_DAL(objBranchProperty);
            return objBranchDAL.SelectAll();
        }
        public DataTable MainBranch()
        {
            objBranchDAL = new Branch_DAL(objBranchProperty);
            return objBranchDAL.SelectAllMainBranch();
        }

        public DataTable GetById()
        {
            objBranchDAL = new Branch_DAL(objBranchProperty);
            return objBranchDAL.SelectById();
        }
        public bool Insert()
        {
            objBranchDAL = new Branch_DAL(objBranchProperty);
            return objBranchDAL.Insert();
        }
        public bool Update()
        {
            objBranchDAL = new Branch_DAL(objBranchProperty);
            return objBranchDAL.Update();
        }

        public bool Delete(int? id)
        {
            objBranchDAL = new Branch_DAL(objBranchProperty);
            return objBranchDAL.Delete(id);
        }
        //public DataTable ViewByDistributer_ID(int DistributerID)
        //{
        //    objBranchDAL = new Branch_DAL(objCompanyProperty);
        //    return objBranchDAL.SelectByDistributerID(DistributerID);
        //}

        public DataTable ViewAll(string xmlpath)
        {

            // load your xml file (this one is named people and it is in my App_Data folder)
            XElement x = XElement.Load(xmlpath);//get your file
                                                // declare a new DataTable and pass your XElement to it


            objBranchDAL = new Branch_DAL(objBranchProperty);
            return objBranchDAL.XElementToDataTable(x);
        }

        //public string UpdateCompanyXML()
        //{
        //    objBranchDAL = new Branch_DAL(objCompanyProperty);
        //    return objBranchDAL.UpdateCompanyXML();
        //}
    }
}
