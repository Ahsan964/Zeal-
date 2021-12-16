using SNDDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SSS.DAL.Setups
{
   public   class Invoice_DAL: DBInteractionBase
    {
        public Invoice_DAL()
        {

        }

        public DataTable GenerateReport(int? id,int? query)
        {

            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[invoiceData]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("MRN");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, id));
                cmdToExecute.Parameters.Add(new SqlParameter("@query", SqlDbType.Int, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, query));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Product_Parent_Code", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Product_Parent_Code));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Product_Conversion", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Product_Conversion));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Product_Level", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Product_Level));
                //   cmdToExecute.Parameters.Add(new SqlParameter("@Narration", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Narration));
                //   cmdToExecute.Parameters.Add(new SqlParameter("@Product_Type_ID", SqlDbType.Int, 5, ParameterDirection.Input, false, 1, 1, "", DataRowVersion.Proposed, ObjProductSetupProperty.Product_Type));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Packing_Unit_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Packing_Unit_ID));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Small_Unit", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Small_Unit));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Small_Weight", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Small_Weight));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Small_UOM_Length", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Small_UOM_Length));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Small_UOM_Width", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Small_UOM_Width));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Small_UOM_Height", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Small_UOM_Height));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Dozen_Unit", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Dozen_Unit));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Dozen_Weight", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Dozen_Weight));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Dozen_UOM_Length", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Dozen_UOM_Length));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Dozen_UOM_Width", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Dozen_UOM_Width));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Dozen_UOM_Height", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Dozen_UOM_Height));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Conversion_Unit", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Conversion_Unit));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Conversion_Weight", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Conversion_Weight));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Conversion_UOM_Length", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Conversion_UOM_Length));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Conversion_UOM_Width", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Conversion_UOM_Width));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Conversion_UOM_Height", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Conversion_UOM_Height));
                // cmdToExecute.Parameters.Add(new SqlParameter("@PriceApplyOn", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.PriceApplyOn));
                // cmdToExecute.Parameters.Add(new SqlParameter("@SKU_Previous_Code", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.SKU_Previous_Code));
                // cmdToExecute.Parameters.Add(new SqlParameter("@GST", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.GST));
                // cmdToExecute.Parameters.Add(new SqlParameter("@GST_Free_SKU", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.GST_Free_SKU));
                // cmdToExecute.Parameters.Add(new SqlParameter("@GST_Schedule_ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.GST_Schedule_ID));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Sale_Price", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, ObjProductSetupProperty.Sale_Price));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Purchase_Price", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, ObjProductSetupProperty.Purchase_Price));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Sale_Days", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Sale_Days));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Stop_Days", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Stop_Days));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Qty_Limit", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Qty_Limit));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Value_Limit", SqlDbType.Decimal, 9, ParameterDirection.Input, false, 18, 1, "", DataRowVersion.Proposed, ObjProductSetupProperty.Value_Limit));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Is_Active", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Is_Active));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Defined_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Defined_Date));
                // cmdToExecute.Parameters.Add(new SqlParameter("@Defined_By", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Defined_By));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Is_Final_Product", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Is_Final_Product));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Status));
                //cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.ID));
                //// cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                //cmdToExecute.Parameters.Add(new SqlParameter("@PageNum", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.PageNum));
                //cmdToExecute.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.PageSize));
                //cmdToExecute.Parameters.Add(new SqlParameter("@sortColumn", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.SortColumn));
                //cmdToExecute.Parameters.Add(new SqlParameter("@TotalRowsNum", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.TotalRowsNum));

                if (_mainConnectionIsCreatedLocal)
                {
                    // Open connection.
                    _mainConnection.Open();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }
                // Execute query.
                adapter.Fill(toReturn);
                //  _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    throw new Exception("Stored Procedure 'pr_PRODUCT_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                //}

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("PRODUCT_SETUP::SelectAll::Error occured.", ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
                adapter.Dispose();
            }
        }

    }
}
