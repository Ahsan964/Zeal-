using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSS.Property.Setups;
using SSS.DAL;
using SSS.DAL.Setups;
using System.Data;
using System.Data.SqlTypes;


namespace SSS.BLL.Setups
{
    public class Page_BLL : GridCommandBase
    {

        private Page_DAL objPageDAL;
        private Page_Property objPageProperty;
        private SqlInt32 _errorcode;


        public Page_BLL()
        {
        }

        public Page_BLL(Page_Property objPage_Property)
        {
            objPageProperty = objPage_Property;
        }

        public DataTable ViewAll()
        {
            objPageDAL = new Page_DAL(objPageProperty);
            return objPageDAL.SelectAll();
        }

        public DataTable View()
        {
            objPageDAL = new Page_DAL(objPageProperty);
            return objPageDAL.SelectOne();
        }

        public bool ADD()
        {
            objPageDAL = new Page_DAL(objPageProperty);



            //this.ErrorCode = Convert.ToInt32(objPageDAL.ErrorCode); 

            


            return  objPageDAL.Insert();


             
        }

        public bool Update()
        {
            objPageDAL = new Page_DAL(objPageProperty);

            this.ErrorCode = objPageDAL.ErrorCode; 


            return objPageDAL.Update();
        }

        public override void UpdateStatus()
        {
            Page_Property objPageSetupPropertyNew = new Page_Property();
            objPageSetupPropertyNew.Id  = base.Id;
            objPageSetupPropertyNew.Status = base.Status;
            objPageSetupPropertyNew.TableName = objPageProperty.TableName;
            objPageSetupPropertyNew.Operated_By = objPageProperty.Operated_By;

            objPageDAL = new Page_DAL(objPageSetupPropertyNew);
            objPageDAL.UpdateStatus();
        }


        public SqlInt32 ErrorCode
        {

            get
            {
                return _errorcode;
            }
            set
            {
                _errorcode = value;
            }



        }



    }
}
