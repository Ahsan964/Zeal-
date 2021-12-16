using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using SSS.Property.Setups;
using SSS.DAL;
using SSS.DAL.Setups;
using System.Data;
using FluentValidation;

namespace SSS.BLL.Setups
{
    public class TreeView_BLL : GridCommandBase
    {
        private TreeView_DAL objTreeViewDAL;

        public DataTable GetData(string TableName)
        {
            objTreeViewDAL = new TreeView_DAL();
            if (TableName != "LOCATIONS_SETUP")
                return objTreeViewDAL.SelectAll(TableName);
            else
                //return objTreeViewDAL.SelectAll(TableName);
            return objTreeViewDAL.SelectAllLocations(TableName);
        }

        public DataTable GetDataNew(string TableName, int lvl, char greaterorLess)
        {
            objTreeViewDAL = new TreeView_DAL();
            if (TableName != "LOCATIONS_SETUP")
                return objTreeViewDAL.SelectAllNew(TableName, lvl, greaterorLess);
            else
                return objTreeViewDAL.SelectAllLocationsNew(TableName, lvl, greaterorLess);
        }

        public DataTable GetDataFromNode(string Node, string TableName, string NodeColumn, string Code, string KeyMember)
        {
            objTreeViewDAL = new TreeView_DAL();
            return objTreeViewDAL.SelectByNode(Node, TableName, NodeColumn, Code, KeyMember);
        }

        public override void UpdateStatus()
        {
            throw new NotImplementedException();
        }

        public DataTable GetData2(string TableName)
        {
            objTreeViewDAL = new TreeView_DAL();
            if (TableName != "LOCATIONS_SETUP")
                return objTreeViewDAL.SelectAll2(TableName);
            else
                return objTreeViewDAL.SelectAllLocations(TableName);
        }
    }
}
