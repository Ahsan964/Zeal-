using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.DAL.Setups;
using SSS.Property.Setups;
using System.Data;

namespace SSS.BLL.Setups
{
    public class VendorProcess_BLL
    {
        private VendorProcess_DAL _objVendorDAL;
        private VendorProcessVM_Property _objVendorProcessVmProperty;

        public VendorProcess_BLL()
        {
                
        }

        public VendorProcess_BLL(int id)
        {
                
        }

        public VendorProcess_BLL(VendorProcessVM_Property objVendorProcessVmProperty)
        {
            _objVendorProcessVmProperty = objVendorProcessVmProperty;
        }

        public bool Insert()
        {
            _objVendorDAL = new VendorProcess_DAL(_objVendorProcessVmProperty);
            return _objVendorDAL.Insert();
        }

        public DataTable viewOne()
        {
            _objVendorDAL = new VendorProcess_DAL(_objVendorProcessVmProperty);
            return _objVendorDAL.selectOne();
        }

        public DataTable ViewAll()
        {
            _objVendorDAL = new VendorProcess_DAL(_objVendorProcessVmProperty);
            return _objVendorDAL.viewAll();
        }

        // Added By Ahsan
        public DataTable singlevendorProcess()
        {
            _objVendorDAL = new VendorProcess_DAL(_objVendorProcessVmProperty);
            return _objVendorDAL.singlevendorProcess();
        }

        public bool Delete()
        {
            _objVendorDAL = new VendorProcess_DAL(_objVendorProcessVmProperty);
            return _objVendorDAL.Delete();
        }

        public bool DeleteAndInsert()
        {
            _objVendorDAL = new VendorProcess_DAL(_objVendorProcessVmProperty);
            return _objVendorDAL.DeleteAndInsert();
        }
    }
}
