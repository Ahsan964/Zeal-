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
    public class ReturnReasons_BLL : GridCommandBase
    {
        private ReturnReasons_DAL objReturnReasonsDAL;
        private ReturnReasons_Property objReturnReasonsProperty;

        public ReturnReasons_BLL(ReturnReasons_Property objReturnReasons_Property)
        {
            objReturnReasonsProperty = objReturnReasons_Property;
        }
           

        public bool Add()
        {
            objReturnReasonsDAL = new ReturnReasons_DAL(objReturnReasonsProperty);
            return objReturnReasonsDAL.Insert();
        }

       
        public bool Update()
        {
            objReturnReasonsDAL = new ReturnReasons_DAL(objReturnReasonsProperty);
            return objReturnReasonsDAL.Update() ;
        }

        public DataTable ViewAll()
        {
            objReturnReasonsDAL = new ReturnReasons_DAL(objReturnReasonsProperty);
            return objReturnReasonsDAL.SelectAll();
        }


        public override void UpdateStatus()
        {
            ReturnReasons_Property objReturnReasonsPropertyNew = new ReturnReasons_Property();
            objReturnReasonsPropertyNew.ID = base.Id;
            objReturnReasonsPropertyNew.Status = base.Status;
            objReturnReasonsPropertyNew.TableName = objReturnReasonsProperty.TableName;

            objReturnReasonsDAL = new ReturnReasons_DAL(objReturnReasonsPropertyNew);
            objReturnReasonsDAL.UpdateStatus();
        }

        public DataTable View()
        {            
            objReturnReasonsDAL = new ReturnReasons_DAL(objReturnReasonsProperty);
            return objReturnReasonsDAL.SelectOne();
        }

    }
}
