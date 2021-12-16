using SNDDAL;
using SSS.Property.Transactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SSS.DAL.Transactions
{
    public class LP_FinishProduct_DAL : DBInteractionBase
    {
        private LP_FinsihProduct_Property _objACTasterProperty;

        public LP_FinishProduct_DAL(LP_FinsihProduct_Property objACTasterProperty)
        {
            _objACTasterProperty = objACTasterProperty;
        }
        public LP_FinishProduct_DAL()
        {
            
        }
        public override bool Insert()
        {
            SqlCommand cmdToExecute = new SqlCommand();


            if (_objACTasterProperty.orderIdx > 0)
            {
                //sp_PurchaseUpdate
                cmdToExecute.CommandText = @"update Activity set status=1 where orderIdx=@idx";
            }
            if (_objACTasterProperty.productIdx > 0)
            {
                cmdToExecute.CommandText = "[dbo].[sp_insert_inventory]";
                cmdToExecute.CommandType = CommandType.StoredProcedure;
            }
            
            else
            {
                cmdToExecute.CommandText = "dbo.[sp_SalesOrderInsert]";
            }

            //cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {

                if (_objACTasterProperty.orderIdx > 0)
                {
                    cmdToExecute.Parameters.Add(new SqlParameter("@idx", SqlDbType.Int, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objACTasterProperty.orderIdx));
                }
                if (_objACTasterProperty.productIdx > 0)
                {
                    cmdToExecute.Parameters.Add(new SqlParameter("@typeIdx", SqlDbType.Int, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objACTasterProperty.typeIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@productIdx", SqlDbType.Int, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objACTasterProperty.productIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@stock", SqlDbType.Int, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objACTasterProperty.stock));
                    cmdToExecute.Parameters.Add(new SqlParameter("@unitPrice", SqlDbType.Int, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objACTasterProperty.unitPrice));
                    cmdToExecute.Parameters.Add(new SqlParameter("@totalAmount", SqlDbType.Int, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objACTasterProperty.totalAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@warehouseIdx", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objACTasterProperty.warehouseIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@branchIdx", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objACTasterProperty.branchIdx));

                }

                else
                {
                   
                }

                if (_mainConnectionIsCreatedLocal)
                {

                    OpenConnection();
                }
                else
                {
                    if (_mainConnectionProvider.IsTransactionPending)
                    {
                        cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                    }
                }

                this.StartTransaction();
                cmdToExecute.Transaction = this.Transaction;
                // Execute query.
                _rowsAffected = cmdToExecute.ExecuteNonQuery();
                // _iD = (Int32)cmdToExecute.Parameters["@iID"].Value;
                //_errorCode = cmdToExecute.Parameters["@ErrorCode"].Value;

                if (_objACTasterProperty.DetailData != null)
                {
                    foreach (DataRow row in _objACTasterProperty.DetailData.Rows)
                    {
                        row["MasterID"] = _objACTasterProperty.orderIdx;
                        row["TransactionTypeID"] = "1";
                        row["creationDate"] = DateTime.Now.ToString("yyyy-MM-dd");
                    }

                    _objACTasterProperty.DetailData.AcceptChanges();

                    SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);

                    // Inventory Condition
                    
                    //_objACTasterProperty.DetailData.TableName = "inventory";

                    //sbc.ColumnMappings.Clear();
                    
                    //sbc.ColumnMappings.Add("productTypeIdx", "productTypeIdx");
                    //sbc.ColumnMappings.Add("productIdx", "productIdx");
                    //sbc.ColumnMappings.Add("stock", "stock");
                    //sbc.ColumnMappings.Add("unitPrice", "unitPrice");
                    //sbc.ColumnMappings.Add("totalAmount", "totalAmount");
                    //sbc.ColumnMappings.Add("creationDate", "creationDate");
                  

                    //sbc.DestinationTableName = _objACTasterProperty.DetailData.TableName;
                    //sbc.WriteToServer(_objACTasterProperty.DetailData);


                    _objACTasterProperty.DetailData.TableName = "inventory_logs";

                    sbc.ColumnMappings.Clear();
                    sbc.ColumnMappings.Add("TransactionTypeID", "TransactionTypeID");
                    //sbc.ColumnMappings.Add(2, 1);
                    sbc.ColumnMappings.Add("productTypeIdx", "productTypeIdx");
                    sbc.ColumnMappings.Add("productIdx", "productIdx");
                    sbc.ColumnMappings.Add("stock", "stock");
                    sbc.ColumnMappings.Add("unitPrice", "unitPrice");
                    sbc.ColumnMappings.Add("totalAmount", "totalAmount");
                    sbc.ColumnMappings.Add("creationDate", "creationDate");
                    sbc.ColumnMappings.Add("BRANCHID", "BRANCHID");
                    sbc.ColumnMappings.Add("wareHouseIdx", "wareHouseIdx");

                    //sbc.ColumnMappings.Add("Product_Code", "Product_Code");
                    //sbc.ColumnMappings.Add("Product", "Product_Name");
                    //sbc.ColumnMappings.Add("Status", "Status");

                    //sbc.ColumnMappings.Add("Department_Id", "Department_Id");
                    //sbc.ColumnMappings.Add("Description", "Description");

                    sbc.DestinationTableName = _objACTasterProperty.DetailData.TableName;
                    sbc.WriteToServer(_objACTasterProperty.DetailData);

                }

                
                this.Commit();
                return true;
            }
            catch (Exception ex)
            {
                this.RollBack();
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TRANSACTION_MASTER::Insert::Error occured.", ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    //// Close connection.
                    //_mainConnection.Close();
                    CloseConnection();
                }
                cmdToExecute.Dispose();
            }
        }

        public override DataTable SelectAll()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = @"select distinct ac.orderIdx as idx,case when ac.typeIdx=1 then so.soNumber 
when ac.typeIdx=2 then do.doNumber end soNumber
from Activity ac
left join displayOrder do on (ac.orderIdx=do.idx and ac.typeIdx=2) 
left join salesOrder so on (ac.orderIdx=so.idx and ac.typeIdx=1) 
where ac.status=0";
            //cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Banks");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
               
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
        public  DataTable SelectAllActivityByOrder(int id)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "sp_getAllActivityByOrderIdx";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Banks");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@idx", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, id));

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
