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


    public class Price_List_Mst_BLL : GridCommandBase
    {


        private Price_List_Mst_Property objPriceListMstProperty;
        private Price_List_Mst_DAL  objPriceListMstDAL;

        public Price_List_Mst_BLL(Price_List_Mst_Property obPriceListMst_Property)
        {
            objPriceListMstProperty = obPriceListMst_Property;

        }

        public Price_List_Mst_BLL()
        {
            

        }




        public bool ADD()
        {
            objPriceListMstDAL = new Price_List_Mst_DAL(objPriceListMstProperty);

            //this.ErrorCode = Convert.ToInt32(objRoleDAL.ErrorCode); 


            return objPriceListMstDAL.PriceListInsert() ;
        }


        public DataTable ViewAll()
        {
            objPriceListMstDAL = new Price_List_Mst_DAL(objPriceListMstProperty);
            return objPriceListMstDAL.SelectAll();
        }

        public DataTable ViewAllProductsPrice()
        {
            objPriceListMstDAL = new Price_List_Mst_DAL(objPriceListMstProperty);
            return objPriceListMstDAL.SelectAll_Price();
        }
        

        public DataTable ViewAllProductsPrice_WithPriceCode()
        {
            objPriceListMstDAL = new Price_List_Mst_DAL(objPriceListMstProperty);
            return objPriceListMstDAL.SelectAll_Price_WithPriceCode();
        }


        public override void UpdateStatus()
        {
            Price_List_Mst_Property objPriceListMstPropertyNew = new Price_List_Mst_Property();
            objPriceListMstPropertyNew.ID = base.Id;
            objPriceListMstPropertyNew.PriceListStatus = base.Status;
            objPriceListMstPropertyNew.TableName = objPriceListMstProperty.TableName;

            objPriceListMstDAL = new Price_List_Mst_DAL(objPriceListMstPropertyNew);
            objPriceListMstDAL.UpdateStatus();

           
        }

        public bool UpdateStatus(Price_List_Mst_Property objPriceListMstPropertyNew)
        {
          
            objPriceListMstDAL = new Price_List_Mst_DAL(objPriceListMstPropertyNew);
          return  objPriceListMstDAL.UpdateStatus();


        }

        public DataTable Selectlatestbatchid()
        {
            objPriceListMstDAL = new Price_List_Mst_DAL(objPriceListMstProperty);
            return objPriceListMstDAL.Selectlatestbatchid();
        }

        public DataTable SelectPricebySKUCode(string SKUCode)
        {
            objPriceListMstDAL = new Price_List_Mst_DAL(objPriceListMstProperty);
            return objPriceListMstDAL.SelectPricebySKUCode(SKUCode);
        }


        public DataTable View()
        {
            objPriceListMstDAL = new Price_List_Mst_DAL(objPriceListMstProperty);
            return objPriceListMstDAL.SelectOne();
        }





        public bool Update()
        {
            objPriceListMstDAL = new Price_List_Mst_DAL(objPriceListMstProperty);

            //this.ErrorCode = Convert.ToInt32(objRoleDAL.ErrorCode); 


            return objPriceListMstDAL.Update();
        }


        public DataSet PriceStructureReport()
        {
            objPriceListMstDAL = new Price_List_Mst_DAL(objPriceListMstProperty);
            return objPriceListMstDAL.PriceStructureReport();
        }







    }
}
