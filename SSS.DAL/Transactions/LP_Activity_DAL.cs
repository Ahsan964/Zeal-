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
    public class LP_Activity_DAL : DBInteractionBase
    {
        private LP_Activity_Property _objACTasterProperty;
        int GLIDX;

        public LP_Activity_DAL()
        {

        }

        public LP_Activity_DAL(LP_Activity_Property objACTasterProperty)
        {
            _objACTasterProperty = objACTasterProperty;
        }

        public bool DeleteAndInsert()
        {
           // SqlCommand cmdToExecute = new SqlCommand();
           // cmdToExecute.CommandText = "delete from Activity where orderIdx="+_objACTasterProperty.orderIdx + "and typeIdx="+_objACTasterProperty.typeIdx;
            SqlCommand cmdToExecute = new SqlCommand();
            
                //sp_ActivityAccountsUpdate
            cmdToExecute.CommandText = "dbo.sp_AccountsGLActivityUpdate";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                    cmdToExecute.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _objACTasterProperty.idx));
                  
                    cmdToExecute.Parameters.Add(new SqlParameter("@tranTypeIdx", SqlDbType.Int, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1));//Receipt Voucher Transaction Type
                    cmdToExecute.Parameters.Add(new SqlParameter("@invoiceidx", SqlDbType.NVarChar, 5000, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _objACTasterProperty.orderIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@debit", SqlDbType.Decimal, 500, ParameterDirection.Input, false, 10, 1, "", DataRowVersion.Proposed, _objACTasterProperty.TotalPrice));
                    cmdToExecute.Parameters.Add(new SqlParameter("@credit", SqlDbType.Decimal, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objACTasterProperty.TotalPrice));
                    cmdToExecute.Parameters.Add(new SqlParameter("@masterIdx", SqlDbType.Int, 500, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Proposed, _objACTasterProperty.glIdx));
                
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

                if (_objACTasterProperty.DetailData != null)
                {
                    decimal totalmount;
                    foreach (DataRow row in _objACTasterProperty.DetailData.Rows)
                    {
                        // row["doIdx"] = cmdToExecute.Parameters["@ID"].Value.ToString();
                        row["activityDate"] = _objACTasterProperty.activityDate;
                        row["creationDate"] = _objACTasterProperty.creationDate;
                        row["createdBy"] = _objACTasterProperty.createdBy;
                        row["orderIdx"] = _objACTasterProperty.orderIdx;
                      //  row["vendorCatIdx"] = _objACTasterProperty.vendorCatIdx;
                       // row["vendorIdx"] = _objACTasterProperty.vendorIdx;
                        row["typeIdx"] = _objACTasterProperty.typeIdx;
                       // row["lastModificationDate"] = _objACTasterProperty.lastModificationDate;
                        row["lastModifiedByUserIdx"] = _objACTasterProperty.lastModifiedByUserIdx;
                      
                    }


                    _objACTasterProperty.DetailData.AcceptChanges();

                    SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);
                    _objACTasterProperty.DetailData.TableName = "Activity";

                    sbc.ColumnMappings.Clear();
                    sbc.ColumnMappings.Add("activityDate", "activityDate");
                    sbc.ColumnMappings.Add("creationDate", "creationDate");
                    sbc.ColumnMappings.Add("createdBy", "createdBy");
                    sbc.ColumnMappings.Add("orderIdx", "orderIdx");
                    sbc.ColumnMappings.Add("vendorCatIdx", "vendorCatIdx");
                    sbc.ColumnMappings.Add("vendorIdx", "vendorIdx");
                    sbc.ColumnMappings.Add("typeIdx", "typeIdx");
                    sbc.ColumnMappings.Add("productIdx", "productIdx");
                    sbc.ColumnMappings.Add("size", "size");
                    sbc.ColumnMappings.Add("qty", "qty");
                    sbc.ColumnMappings.Add("activityPrice", "activityPrice");
                    sbc.ColumnMappings.Add("description", "description");
                    sbc.ColumnMappings.Add("reference", "reference");
                    sbc.ColumnMappings.Add("totalAmount", "totalAmount");
                    sbc.ColumnMappings.Add("Price", "Price");
                    sbc.ColumnMappings.Add("TotalPrice", "TotalPrice");
                    // sbc.ColumnMappings.Add("DeliveryDate", "DeliveryDate");
                    //  sbc.ColumnMappings.Add("lastModificationDate", "lastModificationDate");
                    sbc.ColumnMappings.Add("lastModifiedByUserIdx", "lastModifiedByUserIdx");
                 

                    sbc.DestinationTableName = _objACTasterProperty.DetailData.TableName;
                    sbc.WriteToServer(_objACTasterProperty.DetailData);

                }

                // AccountsGJ
                GLIDX = (Int32)cmdToExecute.Parameters["@masterIdx"].Value;
                if (_objACTasterProperty.DetailData != null)
                {
                    DataTable dt = new DataTable();
                    dt = _objACTasterProperty.DetailData;
                    int count = _objACTasterProperty.DetailData.Rows.Count;
                    int customerIdx, coaIdx;
                    string invoiceNo;
                    decimal Price, TotalPrice, credit, debit;
                    int vendorIdx, vendor;
                    for (int i = 0; i < count; i++)
                    {
                        decimal.TryParse(dt.Rows[i]["Price"].ToString(), out Price); //paidAmount
                        decimal.TryParse(dt.Rows[i]["TotalPrice"].ToString(), out TotalPrice); //BalanceAmount
                        int.TryParse(dt.Rows[i]["vendorIdx"].ToString(), out vendor);
                        credit = Price;
                        debit = TotalPrice;
                        vendorIdx = vendor;

                        //int GLIDX = (Int32)cmdToExecute.Parameters["@glIdx"].Value;
                        //purchase entry for account gj same for all types
                        cmdToExecute = new SqlCommand();
                        // cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.CommandText = "sp_InsertAccountGj";
                        cmdToExecute.Connection = _mainConnection;
                        cmdToExecute.Parameters.Add(new SqlParameter("@GLIdx", SqlDbType.Int, 50,
                            ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, GLIDX));
                        cmdToExecute.Parameters.Add(new SqlParameter("@TransTypeIdx", SqlDbType.Int, 500,
                            ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed,
                            1)); //Receipt Voucher Trasaction Type

                        cmdToExecute.Parameters.Add(new SqlParameter("@useridx", SqlDbType.Int, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                            _objACTasterProperty.createdBy));

                        cmdToExecute.Parameters.Add(new SqlParameter("@vendoridx", SqlDbType.Int, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, vendorIdx));
                        cmdToExecute.Parameters.Add(new SqlParameter("@employeeidx", SqlDbType.Int, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        cmdToExecute.Parameters.Add(new SqlParameter("@customeridx", SqlDbType.Int, 25,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        cmdToExecute.Parameters.Add(new SqlParameter("@coaidx", SqlDbType.Int, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 88)); //Sales
                        cmdToExecute.Parameters.Add(new SqlParameter("@invoiceidx", SqlDbType.NVarChar, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                            _objACTasterProperty.orderIdx));

                        cmdToExecute.Parameters.Add(new SqlParameter("@debit", SqlDbType.Decimal, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, debit));

                        cmdToExecute.Parameters.Add(new SqlParameter("@credit", SqlDbType.Decimal, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, credit));
                        cmdToExecute.Parameters.Add(new SqlParameter("@creationDate", SqlDbType.Date, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                            _objACTasterProperty.creationDate));
                        cmdToExecute.Parameters.Add(new SqlParameter("@modifiedDate", SqlDbType.Date, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        cmdToExecute.Parameters.Add(new SqlParameter("@DueDate", SqlDbType.Date, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));

                        cmdToExecute.Transaction = this.Transaction;
                        _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    }
                }

                this.Commit();
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    this.RollBack();
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_MASTER_Insert' reported the ErrorCode: " + _errorCode);

                }

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



        public override bool Insert()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_ActivityAccountsGLInsert]";
            
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {

                cmdToExecute.Parameters.Add(new SqlParameter("@branchIdx", SqlDbType.Int, 100, ParameterDirection.Input,
                    false, 0, 0, "", DataRowVersion.Proposed, null)); //Receipt Voucher Transaction Type

                cmdToExecute.Parameters.Add(new SqlParameter("@transactionTypeIdx", SqlDbType.Int, 100,
                    ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1)); //Activity
                cmdToExecute.Parameters.Add(new SqlParameter("@useridx", SqlDbType.Int, 200, ParameterDirection.Input,
                    false, 0, 0, "", DataRowVersion.Proposed, _objACTasterProperty.createdBy));
                cmdToExecute.Parameters.Add(new SqlParameter("@vendoridx", SqlDbType.Int, 4, ParameterDirection.Input,
                    false, 10, 0, "", DataRowVersion.Proposed, null));
                cmdToExecute.Parameters.Add(new SqlParameter("@employeeidx", SqlDbType.Int, 4, ParameterDirection.Input,
                    false, 10, 0, "", DataRowVersion.Proposed, null));
                cmdToExecute.Parameters.Add(new SqlParameter("@customeridx", SqlDbType.Int, 4, ParameterDirection.Input,
                    false, 10, 0, "", DataRowVersion.Proposed, null));
                cmdToExecute.Parameters.Add(new SqlParameter("@invoiceidx", SqlDbType.NVarChar, 5000,
                    ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _objACTasterProperty.orderIdx));
                cmdToExecute.Parameters.Add(new SqlParameter("@debit", SqlDbType.Decimal, 500, ParameterDirection.Input,
                    false, 10, 1, "", DataRowVersion.Proposed, _objACTasterProperty.TotalPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@credit", SqlDbType.Decimal, 500,
                    ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed,
                    _objACTasterProperty.TotalPrice));
                cmdToExecute.Parameters.Add(new SqlParameter("@createdate", SqlDbType.DateTime, 50,
                    ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed,
                    _objACTasterProperty.creationDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@modifieddate", SqlDbType.NVarChar, 50,
                    ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, null));
                cmdToExecute.Parameters.Add(new SqlParameter("@paidamount", SqlDbType.Decimal, 500,
                    ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, null));
                cmdToExecute.Parameters.Add(new SqlParameter("@balance", SqlDbType.Decimal, 500,
                    ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, 0.00m));
                cmdToExecute.Parameters.Add(new SqlParameter("@discount", SqlDbType.Decimal, 500,
                    ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, null));
                cmdToExecute.Parameters.Add(new SqlParameter("@isCredit", SqlDbType.Int, 500, ParameterDirection.Input,
                    false, 10, 0, "", DataRowVersion.Proposed, 0));
                cmdToExecute.Parameters.Add(new SqlParameter("@creditdays", SqlDbType.Int, 500,
                    ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, null));
                cmdToExecute.Parameters.Add(new SqlParameter("@visible", SqlDbType.Int, 4, ParameterDirection.Input,
                    false, 10, 0, "", DataRowVersion.Proposed, 1));
                cmdToExecute.Parameters.Add(new SqlParameter("@paymentModeIdx", SqlDbType.Int, 4,
                    ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, null));
                cmdToExecute.Parameters.Add(new SqlParameter("@bankIdx", SqlDbType.Int, 4, ParameterDirection.Input,
                    false, 10, 0, "", DataRowVersion.Proposed, null));
                cmdToExecute.Parameters.Add(new SqlParameter("@chequeNumber", SqlDbType.NVarChar, 5000,
                    ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, null));
                cmdToExecute.Parameters.Add(new SqlParameter("@memo", SqlDbType.NVarChar, 50, ParameterDirection.Input,
                    false, 10, 0, "", DataRowVersion.Proposed, _objACTasterProperty.reference));
                cmdToExecute.Parameters.Add(new SqlParameter("@DueDate", SqlDbType.DateTime, 50,
                    ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, null));
                cmdToExecute.Parameters.Add(new SqlParameter("@itemId", SqlDbType.Int, 4, ParameterDirection.Input,
                    false, 10, 0, "", DataRowVersion.Proposed, 0));
                cmdToExecute.Parameters.Add(new SqlParameter("@ChequeDate", SqlDbType.DateTime, 50,
                    ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, null));
                cmdToExecute.Parameters.Add(new SqlParameter("@Isdeposited", SqlDbType.Int, 50,
                    ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 0));
                cmdToExecute.Parameters.Add(new SqlParameter("@glIdx", SqlDbType.Int, 500,
                    ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Proposed,
                    _objACTasterProperty.glIdx));

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

                GLIDX = (Int32) cmdToExecute.Parameters["@glIdx"].Value;
                if (_objACTasterProperty.DetailData != null)
                {
                    DataTable dt = new DataTable();
                    dt = _objACTasterProperty.DetailData;
                    int count = _objACTasterProperty.DetailData.Rows.Count;
                    int customerIdx, coaIdx;
                    string invoiceNo;
                    decimal Price, TotalPrice, credit, debit;
                    int vendorIdx, vendor;
                    for (int i = 0; i < count; i++)
                    {
                        decimal.TryParse(dt.Rows[i]["Price"].ToString(), out Price); //paidAmount
                        decimal.TryParse(dt.Rows[i]["TotalPrice"].ToString(), out TotalPrice); //BalanceAmount
                        int.TryParse(dt.Rows[i]["vendorIdx"].ToString(), out vendor);
                        credit = Price;
                        debit = TotalPrice;
                        vendorIdx = vendor;

                        //int GLIDX = (Int32)cmdToExecute.Parameters["@glIdx"].Value;
                        //purchase entry for account gj same for all types
                        cmdToExecute = new SqlCommand();
                        // cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.CommandText = "sp_InsertAccountGj";
                        cmdToExecute.Connection = _mainConnection;
                        cmdToExecute.Parameters.Add(new SqlParameter("@GLIdx", SqlDbType.Int, 50,
                            ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, GLIDX));
                        cmdToExecute.Parameters.Add(new SqlParameter("@TransTypeIdx", SqlDbType.Int, 500,
                            ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed,
                            1)); //Receipt Voucher Trasaction Type

                        cmdToExecute.Parameters.Add(new SqlParameter("@useridx", SqlDbType.Int, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                            _objACTasterProperty.createdBy));

                        cmdToExecute.Parameters.Add(new SqlParameter("@vendoridx", SqlDbType.Int, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, vendorIdx));
                        cmdToExecute.Parameters.Add(new SqlParameter("@employeeidx", SqlDbType.Int, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        cmdToExecute.Parameters.Add(new SqlParameter("@customeridx", SqlDbType.Int, 25,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        cmdToExecute.Parameters.Add(new SqlParameter("@coaidx", SqlDbType.Int, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 88)); //Sales
                        cmdToExecute.Parameters.Add(new SqlParameter("@invoiceidx", SqlDbType.NVarChar, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                            _objACTasterProperty.orderIdx));

                        cmdToExecute.Parameters.Add(new SqlParameter("@debit", SqlDbType.Decimal, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, debit));

                        cmdToExecute.Parameters.Add(new SqlParameter("@credit", SqlDbType.Decimal, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, credit));
                        cmdToExecute.Parameters.Add(new SqlParameter("@creationDate", SqlDbType.Date, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                            _objACTasterProperty.creationDate));
                        cmdToExecute.Parameters.Add(new SqlParameter("@modifiedDate", SqlDbType.Date, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        cmdToExecute.Parameters.Add(new SqlParameter("@DueDate", SqlDbType.Date, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));

                        cmdToExecute.Transaction = this.Transaction;
                        _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    }
                }

                if (_objACTasterProperty.DetailData != null)
                    {
                        decimal totalmount;
                        foreach (DataRow row in _objACTasterProperty.DetailData.Rows)
                        {
                            // row["doIdx"] = cmdToExecute.Parameters["@ID"].Value.ToString();
                            row["activityDate"] = _objACTasterProperty.activityDate;
                            row["creationDate"] = _objACTasterProperty.creationDate;
                            row["createdBy"] = _objACTasterProperty.createdBy;
                            row["orderIdx"] = _objACTasterProperty.orderIdx;
                            //row["vendorCatIdx"] = _objACTasterProperty.vendorCatIdx;
                            //row["vendorIdx"] = _objACTasterProperty.vendorIdx;
                            row["typeIdx"] = _objACTasterProperty.typeIdx;
                            row["DeliveryDate"] = _objACTasterProperty.DeliveryDate;

                        }


                        _objACTasterProperty.DetailData.AcceptChanges();

                        SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default,
                            this.Transaction);
                        _objACTasterProperty.DetailData.TableName = "Activity";

                        sbc.ColumnMappings.Clear();
                        sbc.ColumnMappings.Add("activityDate", "activityDate");
                        sbc.ColumnMappings.Add("creationDate", "creationDate");
                        sbc.ColumnMappings.Add("DeliveryDate", "DeliveryDate");
                        sbc.ColumnMappings.Add("createdBy", "createdBy");
                        sbc.ColumnMappings.Add("orderIdx", "orderIdx");
                        sbc.ColumnMappings.Add("vendorCatIdx", "vendorCatIdx");
                        sbc.ColumnMappings.Add("vendorIdx", "vendorIdx");
                        sbc.ColumnMappings.Add("typeIdx", "typeIdx");
                        sbc.ColumnMappings.Add("productIdx", "productIdx");
                        sbc.ColumnMappings.Add("size", "size");
                        sbc.ColumnMappings.Add("qty", "qty");
                        sbc.ColumnMappings.Add("activityPrice", "activityPrice");
                        sbc.ColumnMappings.Add("description", "description");
                        sbc.ColumnMappings.Add("reference", "reference");
                        sbc.ColumnMappings.Add("totalAmount", "totalAmount");
                        sbc.ColumnMappings.Add("Price", "Price");
                        sbc.ColumnMappings.Add("TotalPrice", "TotalPrice");
                        sbc.DestinationTableName = _objACTasterProperty.DetailData.TableName;
                        sbc.WriteToServer(_objACTasterProperty.DetailData);

                    }

                    this.Commit();
                    if (_errorCode != (int) LLBLError.AllOk)
                    {
                        // Throw error.
                        this.RollBack();
                        throw new Exception("Stored Procedure 'sp_TRANSACTION_MASTER_Insert' reported the ErrorCode: " +
                                            _errorCode);

                    }

                
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

        //Delete
        public bool Delete()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = @"update Activity SET visible=0 where idx=@ID";
            //cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@companyIdx", SqlDbType.Int, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objUserProperty.companyIdx));
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objACTasterProperty.idx));

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
                _rowsAffected = cmdToExecute.ExecuteNonQuery();
                // _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_upate_branch' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("Branch::Update::Error occured.", ex);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
        }


        public  DataTable selectVendorPrice(int id)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = @"select isNULL(price,0) price from vendors where idx=@idx";
            
            DataTable toReturn = new DataTable("Vendor Setup");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@idx", SqlDbType.Int,500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, id));

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


     
                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("PRODUCT_SETUP::SelectOne::Error occured.", ex);
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

        public override DataTable SelectAll()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "sp_GetAllActivity";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Vendor Setup");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objACTasterProperty.orderIdx));

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



                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("PRODUCT_SETUP::SelectOne::Error occured.", ex);
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
