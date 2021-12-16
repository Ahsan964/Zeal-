using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Web;
using System.Net.Mail;
using FluentValidation;
using SNDDAL;
using SSS.Property.Setups;


namespace SSS.DAL.Setups
{
    public class Final_Product_Selection_DAL : DBInteractionBase
    {
        private Final_Product_Selection_Property objFinalProdSelectionProperty;
        public SqlString sqlErrorMsg;

        public Final_Product_Selection_DAL()
        {
        }

        public Final_Product_Selection_DAL(Final_Product_Selection_Property objFinalProdSelection_Property)
        {
            objFinalProdSelectionProperty = objFinalProdSelection_Property;
        }

        public DataTable Select()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[FINAL_PRODUCT_SELECTION]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("PRODUCT_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Code", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objFinalProdSelectionProperty.Code));
                cmdToExecute.Parameters.Add(new SqlParameter("@Category", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objFinalProdSelectionProperty.Category));
                cmdToExecute.Parameters.Add(new SqlParameter("@SKU", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objFinalProdSelectionProperty.Sku));
                cmdToExecute.Parameters.Add(new SqlParameter("@errorMsg", SqlDbType.VarChar, 2048, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, sqlErrorMsg));

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
                sqlErrorMsg = (SqlString)cmdToExecute.Parameters["@errorMsg"].Value;

                return toReturn;
            }
            catch (Exception ex)
            {
                return toReturn;
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

        public DataTable ViewProduct()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Product_User_Control]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("PRODUCT_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Is_Final_Product", SqlDbType.Bit, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objFinalProdSelectionProperty.IsFinalProduct));

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
                sqlErrorMsg = (SqlString)cmdToExecute.Parameters["@errorMsg"].Value;

                return toReturn;
            }
            catch (Exception ex)
            {
                return toReturn;
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

        public DataTable ViewProductForCashMemo()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Product_From_Sale_Category_Product]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("PRODUCT_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Is_Final_Product", SqlDbType.Bit, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objFinalProdSelectionProperty.IsFinalProduct));
                cmdToExecute.Parameters.Add(new SqlParameter("@SaleRep", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objFinalProdSelectionProperty.SaleRepID));
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
                //sqlErrorMsg = (SqlString)cmdToExecute.Parameters["@errorMsg"].Value;

                return toReturn;
            }
            catch (Exception ex)
            {
                return toReturn;
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

        public DataTable ViewProductFilter()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Product_User_Control]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("PRODUCT_SETUP");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Is_Final_Product", SqlDbType.Bit, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objFinalProdSelectionProperty.IsFinalProduct));

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
                sqlErrorMsg = (SqlString)cmdToExecute.Parameters["@errorMsg"].Value;

                return toReturn;
            }
            catch (Exception ex)
            {
                return toReturn;
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
