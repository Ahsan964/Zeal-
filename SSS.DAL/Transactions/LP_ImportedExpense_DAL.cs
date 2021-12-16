using SNDDAL;
using SSS.Property.Setups;
using SSS.Property.Transactions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SSS.DAL.Transactions
{
    public class LP_ImportedExpense_DAL : DBInteractionBase
    {
        private int GLIDX;
        private LP_ImportedExpense_Master_Property _objIEMasterProperty;
        private LP_ImportedExpense_Details_Property _objIEDetailProperty;
        string ieIdx;

        public LP_ImportedExpense_DAL()
        {

        }
        public LP_ImportedExpense_DAL(LP_ImportedExpense_Master_Property objPOMasterProperty)
        {
            _objIEMasterProperty = objPOMasterProperty;
        }
        public LP_ImportedExpense_DAL(LP_ImportedExpense_Details_Property objPODetailProperty)
        {
            _objIEDetailProperty = objPODetailProperty;
        }
        public DataTable SelectAllInvoiceDODetails(int id)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = @"select sd.*,pr.itemName from displayOrderDetails sd
inner join products pr on pr.idx = sd.itemIdx where sd.ieIdx=@idx ";
            //cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Banks");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@idx", SqlDbType.Int, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, id));

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
        public override bool Insert()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            if (_objIEMasterProperty.idx > 0)
            {
                //sp_PurchaseUpdate
                cmdToExecute.CommandText = "dbo.[sp_ImportedExpenseUpdate]";
            }
            else
            {
                cmdToExecute.CommandText = "dbo.[sp_ImportedExpenseInsert]";
            }

            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                if (_objIEMasterProperty.idx > 0)
                {
                    cmdToExecute.Parameters.Add(new SqlParameter("@masterIdx", SqlDbType.Int, 32, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.glIdx));

                    cmdToExecute.Parameters.Add(new SqlParameter("@ieNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.ieNumber));

                    //cmdToExecute.Parameters.Add(new SqlParameter("@description", SqlDbType.NVarChar, 80, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.description));


                    cmdToExecute.Parameters.Add(new SqlParameter("@creationdate", SqlDbType.DateTime, 50, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objIEMasterProperty.lastModificationDate));

                    cmdToExecute.Parameters.Add(new SqlParameter("@createdByUserIdx", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.createdByUserIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@visible", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objIEMasterProperty.visible));
                    cmdToExecute.Parameters.Add(new SqlParameter("@status", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objIEMasterProperty.status));
                    cmdToExecute.Parameters.Add(new SqlParameter("@date", SqlDbType.DateTime, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.date));
                    cmdToExecute.Parameters.Add(new SqlParameter("@totalExpense", SqlDbType.Decimal, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.totalExpense));
                    cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.idx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@reference", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.reference));
                    cmdToExecute.Parameters.Add(new SqlParameter("@commercialIdx", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.commercialIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@totalCost", SqlDbType.Decimal, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.totalCost));
                    cmdToExecute.Parameters.Add(new SqlParameter("@valueAdditionPercent", SqlDbType.Decimal, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.valueAdditionPercent));
                    cmdToExecute.Parameters.Add(new SqlParameter("@valueAddition", SqlDbType.Decimal, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.valueAddition));
                    cmdToExecute.Parameters.Add(new SqlParameter("@additionalSalesTaxPercent", SqlDbType.Decimal, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.additionalSalesTaxPercent));
                    cmdToExecute.Parameters.Add(new SqlParameter("@additionalSalesTax", SqlDbType.Decimal, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.additionalSalesTax));
                    cmdToExecute.Parameters.Add(new SqlParameter("@profitPercent", SqlDbType.Decimal, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.profitPercent));
                    cmdToExecute.Parameters.Add(new SqlParameter("@profit", SqlDbType.Decimal, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.profit));
                    cmdToExecute.Parameters.Add(new SqlParameter("@grandTotalExpense", SqlDbType.Decimal, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.grandTotalExpense));
                    cmdToExecute.Parameters.Add(new SqlParameter("@finalPercentage", SqlDbType.Decimal, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.finalPercentage));
                }
                else
                {
                    // Accounts Master
                    cmdToExecute.Parameters.Add(new SqlParameter("@transactionTypeIdx", SqlDbType.Int, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1)); //Activity
                    cmdToExecute.Parameters.Add(new SqlParameter("@glIdx", SqlDbType.Int, 500, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.glIdx));

                    //cmdToExecute.Parameters.Add(new SqlParameter("@ieNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.ieNumber));

                    //cmdToExecute.Parameters.Add(new SqlParameter("@description", SqlDbType.NVarChar, 80, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.description));


                    cmdToExecute.Parameters.Add(new SqlParameter("@creationdate", SqlDbType.DateTime, 50, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objIEMasterProperty.creationDate));

                    cmdToExecute.Parameters.Add(new SqlParameter("@createdByUserIdx", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.createdByUserIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@visible", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objIEMasterProperty.visible));
                    cmdToExecute.Parameters.Add(new SqlParameter("@status", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objIEMasterProperty.status));
                    cmdToExecute.Parameters.Add(new SqlParameter("@date", SqlDbType.DateTime, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.date));
                    cmdToExecute.Parameters.Add(new SqlParameter("@totalExpense", SqlDbType.Decimal, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.totalExpense));
                    cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 32, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.idx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@reference", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.reference));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@commercialIdx", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.commercialIdx));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@totalCost", SqlDbType.Decimal, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.totalCost));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@valueAdditionPercent", SqlDbType.Decimal, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.valueAdditionPercent));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@valueAddition", SqlDbType.Decimal, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.valueAddition));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@additionalSalesTaxPercent", SqlDbType.Decimal, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.additionalSalesTaxPercent));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@additionalSalesTax", SqlDbType.Decimal, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.additionalSalesTax));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@profitPercent", SqlDbType.Decimal, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.profitPercent));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@profit", SqlDbType.Decimal, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.profit));
                   // cmdToExecute.Parameters.Add(new SqlParameter("@grandTotalExpense", SqlDbType.Decimal, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.grandTotalExpense));
                    //  cmdToExecute.Parameters.Add(new SqlParameter("@finalPercentage", SqlDbType.Decimal, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.finalPercentage));
                    cmdToExecute.Parameters.Add(new SqlParameter("@grandTotalExpense", SqlDbType.Decimal, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.grandTotalExpense));
                    cmdToExecute.Parameters.Add(new SqlParameter("@PINO", SqlDbType.Int, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.PINO));
                    cmdToExecute.Parameters.Add(new SqlParameter("@poNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.poNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@numberOfProducts", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objIEMasterProperty.numberOfProducts));
                    cmdToExecute.Parameters.Add(new SqlParameter("@ExchangeRate", SqlDbType.Decimal, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objIEMasterProperty.ExchangeRate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@expense", SqlDbType.Decimal, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objIEMasterProperty.expense));

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

                
                // Added By Ahsan
                if (_objIEMasterProperty.idx > 0)
                {
                    if (_objIEMasterProperty.DetailData != null)
                    {
                        foreach (DataRow row in _objIEMasterProperty.DetailData.Rows)
                        {
                            row["ieIdx"] = _objIEMasterProperty.idx;
                            ieIdx = _objIEMasterProperty.idx.ToString();

                            //row["ieIdx"] = cmdToExecute.Parameters["@ID"].Value.ToString();
                            //ieIdx = cmdToExecute.Parameters["@ID"].Value.ToString();
                        }


                        _objIEMasterProperty.DetailData.AcceptChanges();

                        SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);
                        _objIEMasterProperty.DetailData.TableName = "importedExpenseDetails";

                        sbc.ColumnMappings.Clear();
                        sbc.ColumnMappings.Add("ieIdx", "ieIdx");
                        sbc.ColumnMappings.Add("vendorIdx", "vendorIdx");
                        sbc.ColumnMappings.Add("coaIdx", "coaIdx");
                        sbc.ColumnMappings.Add("amount", "amount");
                        sbc.DestinationTableName = _objIEMasterProperty.DetailData.TableName;
                        sbc.WriteToServer(_objIEMasterProperty.DetailData);

                    }

                    int GLIDX = (Int32)cmdToExecute.Parameters["@masterIdx"].Value;
                    // AccountGJ insert
                    if (_objIEMasterProperty.DetailData != null)
                    {
                        DataTable dt = new DataTable();
                        dt = _objIEMasterProperty.DetailData;
                        int count = _objIEMasterProperty.DetailData.Rows.Count;
                        int customerIdx, coaIdx;
                        string invoiceNo;
                        decimal Price, TotalPrice, credit, debit;
                        int vendorIdx, vendor;
                        for (int i = 0; i < count; i++)
                        {
                            decimal.TryParse(dt.Rows[i]["amount"].ToString(), out Price); //paidAmount
                            decimal.TryParse(dt.Rows[i]["amount"].ToString(), out TotalPrice); //BalanceAmount
                            int.TryParse(dt.Rows[i]["vendorIdx"].ToString(), out vendor);
                            credit = Price;
                            debit = TotalPrice;
                            vendorIdx = vendor;

                            //int GLIDX = (Int32)cmdToExecute.Parameters["@glIdx"].Value;
                            //purchase entry for account gj same for all types
                            cmdToExecute = new SqlCommand();
                            // cmdToExecute.CommandType = CommandType.StoredProcedure;
                            cmdToExecute.CommandType = CommandType.StoredProcedure;
                            cmdToExecute.CommandText = "sp_CIInsertAccountGj";
                            cmdToExecute.Connection = _mainConnection;
                            cmdToExecute.Parameters.Add(new SqlParameter("@GLIdx", SqlDbType.Int, 50,
                                ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, GLIDX));
                            cmdToExecute.Parameters.Add(new SqlParameter("@TransTypeIdx", SqlDbType.Int, 500,
                                ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed,
                                1)); //Receipt Voucher Trasaction Type

                            cmdToExecute.Parameters.Add(new SqlParameter("@useridx", SqlDbType.Int, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                                _objIEMasterProperty.createdByUserIdx));

                            cmdToExecute.Parameters.Add(new SqlParameter("@vendoridx", SqlDbType.Int, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, vendorIdx));
                            cmdToExecute.Parameters.Add(new SqlParameter("@employeeidx", SqlDbType.Int, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                            cmdToExecute.Parameters.Add(new SqlParameter("@customeridx", SqlDbType.Int, 25,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                            cmdToExecute.Parameters.Add(new SqlParameter("@coaidx", SqlDbType.Int, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 89)); //Sales
                            cmdToExecute.Parameters.Add(new SqlParameter("@invoiceidx", SqlDbType.NVarChar, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.ieNumber));

                            cmdToExecute.Parameters.Add(new SqlParameter("@debit", SqlDbType.Decimal, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, debit));

                            cmdToExecute.Parameters.Add(new SqlParameter("@credit", SqlDbType.Decimal, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, credit));
                            cmdToExecute.Parameters.Add(new SqlParameter("@creationDate", SqlDbType.Date, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                                _objIEMasterProperty.lastModificationDate));
                            cmdToExecute.Parameters.Add(new SqlParameter("@modifiedDate", SqlDbType.Date, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                            cmdToExecute.Parameters.Add(new SqlParameter("@DueDate", SqlDbType.Date, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));

                            cmdToExecute.Transaction = this.Transaction;
                            _rowsAffected = cmdToExecute.ExecuteNonQuery();
                        }

                    }

                }
                else
                {
                    GLIDX = (Int32)cmdToExecute.Parameters["@glIdx"].Value;
                    if (_objIEMasterProperty.DetailData != null)
                    {
                        foreach (DataRow row in _objIEMasterProperty.DetailData.Rows)
                        {
                            row["ieIdx"] = cmdToExecute.Parameters["@ID"].Value.ToString();
                            ieIdx = cmdToExecute.Parameters["@ID"].Value.ToString();
                        }


                        _objIEMasterProperty.DetailData.AcceptChanges();

                        SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);
                        _objIEMasterProperty.DetailData.TableName = "importedExpenseDetails";

                        sbc.ColumnMappings.Clear();
                        sbc.ColumnMappings.Add("ieIdx", "ieIdx");
                        sbc.ColumnMappings.Add("vendorIdx", "vendorIdx");
                        sbc.ColumnMappings.Add("coaIdx", "coaIdx");
                        sbc.ColumnMappings.Add("amount", "amount");
                        sbc.DestinationTableName = _objIEMasterProperty.DetailData.TableName;
                        sbc.WriteToServer(_objIEMasterProperty.DetailData);

                    }

                    // AccountGJ insert
                    if (_objIEMasterProperty.DetailData != null)
                    {
                        DataTable dt = new DataTable();
                        dt = _objIEMasterProperty.DetailData;
                        int count = _objIEMasterProperty.DetailData.Rows.Count;
                        int customerIdx, coaIdx;
                        string invoiceNo;
                        decimal Price, TotalPrice, credit, debit;
                        int vendorIdx, vendor;
                        for (int i = 0; i < count; i++)
                        {
                            decimal.TryParse(dt.Rows[i]["amount"].ToString(), out Price); //paidAmount
                            decimal.TryParse(dt.Rows[i]["amount"].ToString(), out TotalPrice); //BalanceAmount
                            int.TryParse(dt.Rows[i]["vendorIdx"].ToString(), out vendor);
                            credit = Price;
                            debit = TotalPrice;
                            vendorIdx = vendor;

                            //int GLIDX = (Int32)cmdToExecute.Parameters["@glIdx"].Value;
                            //purchase entry for account gj same for all types
                            cmdToExecute = new SqlCommand();
                            // cmdToExecute.CommandType = CommandType.StoredProcedure;
                            cmdToExecute.CommandType = CommandType.StoredProcedure;
                            cmdToExecute.CommandText = "sp_CIInsertAccountGj";
                            cmdToExecute.Connection = _mainConnection;
                            cmdToExecute.Parameters.Add(new SqlParameter("@GLIdx", SqlDbType.Int, 50,
                                ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, GLIDX));
                            cmdToExecute.Parameters.Add(new SqlParameter("@TransTypeIdx", SqlDbType.Int, 500,
                                ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed,
                                1)); //Receipt Voucher Trasaction Type

                            cmdToExecute.Parameters.Add(new SqlParameter("@useridx", SqlDbType.Int, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                                _objIEMasterProperty.createdByUserIdx));

                            cmdToExecute.Parameters.Add(new SqlParameter("@vendoridx", SqlDbType.Int, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, vendorIdx));
                            cmdToExecute.Parameters.Add(new SqlParameter("@employeeidx", SqlDbType.Int, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                            cmdToExecute.Parameters.Add(new SqlParameter("@customeridx", SqlDbType.Int, 25,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                            cmdToExecute.Parameters.Add(new SqlParameter("@coaidx", SqlDbType.Int, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 89)); //Sales
                            cmdToExecute.Parameters.Add(new SqlParameter("@invoiceidx", SqlDbType.NVarChar, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.poNumber));

                            cmdToExecute.Parameters.Add(new SqlParameter("@debit", SqlDbType.Decimal, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, debit));

                            cmdToExecute.Parameters.Add(new SqlParameter("@credit", SqlDbType.Decimal, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, credit));
                            cmdToExecute.Parameters.Add(new SqlParameter("@creationDate", SqlDbType.Date, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                                _objIEMasterProperty.lastModificationDate));
                            cmdToExecute.Parameters.Add(new SqlParameter("@modifiedDate", SqlDbType.Date, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                            cmdToExecute.Parameters.Add(new SqlParameter("@DueDate", SqlDbType.Date, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));

                            cmdToExecute.Transaction = this.Transaction;
                            _rowsAffected = cmdToExecute.ExecuteNonQuery();
                        }

                    }

                }

                #region Commented extra

                // Added By Ahsan
                //if (_objIEMasterProperty.DetailDataInventory_logs != null)
                //{
                //    foreach (DataRow row in _objIEMasterProperty.DetailDataInventory_logs.Rows)
                //    {
                //        row["TransactionTypeID"] = "1";
                //        row["creationDate"] = DateTime.Now.ToString("yyyy-MM-dd");
                //    }

                //    _objIEMasterProperty.DetailDataInventory_logs.AcceptChanges();

                //    SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);

                //    _objIEMasterProperty.DetailDataInventory_logs.TableName = "inventory_logs";

                //    sbc.ColumnMappings.Clear();
                //    sbc.ColumnMappings.Add("TransactionTypeID", "TransactionTypeID");
                //    //sbc.ColumnMappings.Add(2, 1);
                //    //sbc.ColumnMappings.Add("productTypeIdx", "productTypeIdx");
                //    sbc.ColumnMappings.Add("itemIdx", "productIdx");
                //    sbc.ColumnMappings.Add("qty", "stock");
                //    sbc.ColumnMappings.Add("unitPrice", "unitPrice");
                //    sbc.ColumnMappings.Add("amount", "totalAmount");
                //    sbc.ColumnMappings.Add("creationDate", "creationDate");


                //    sbc.DestinationTableName = _objIEMasterProperty.DetailDataInventory_logs.TableName;
                //    sbc.WriteToServer(_objIEMasterProperty.DetailDataInventory_logs);

                //}


                // Commented by Ahsan
                //cmdToExecute = new SqlCommand();
                //cmdToExecute.CommandText = "dbo.[sp_selectCommercialItemData]";
                //cmdToExecute.CommandType = CommandType.StoredProcedure;
                //DataSet toReturn = new DataSet("Select Item Data");
                //SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
                //cmdToExecute.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.commercialIdx));
                //cmdToExecute.Parameters.Add(new SqlParameter("@ieIdx", SqlDbType.Int, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, decimal.Parse(ieIdx)));
                //adapter.Fill(toReturn);
                //cmdToExecute.Transaction = this.Transaction;
                //_rowsAffected = cmdToExecute.ExecuteNonQuery();



                //cmdToExecute = new SqlCommand();
                //// cmdToExecute.CommandType = CommandType.StoredProcedure;
                //cmdToExecute.CommandType = CommandType.StoredProcedure;
                //cmdToExecute.CommandText = "sp_InsertAccountGj";
                //cmdToExecute.Connection = _mainConnection;
                //cmdToExecute.Parameters.Add(new SqlParameter("@GLIdx", SqlDbType.Int, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, GLIDX));
                //cmdToExecute.Parameters.Add(new SqlParameter("@TransTypeIdx", SqlDbType.Int, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 2));

                //cmdToExecute.Parameters.Add(new SqlParameter("@useridx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.createdByUserIdx));

                //cmdToExecute.Parameters.Add(new SqlParameter("@vendoridx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                //cmdToExecute.Parameters.Add(new SqlParameter("@employeeidx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                //cmdToExecute.Parameters.Add(new SqlParameter("@customeridx", SqlDbType.Int, 25, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.customerIdx));
                //cmdToExecute.Parameters.Add(new SqlParameter("@coaidx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 6)); //Sales
                //cmdToExecute.Parameters.Add(new SqlParameter("@invoiceidx", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.soNumber));
                //cmdToExecute.Parameters.Add(new SqlParameter("@debit", SqlDbType.Decimal, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 0.00m));
                //cmdToExecute.Parameters.Add(new SqlParameter("@credit", SqlDbType.Decimal, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.netAmount));
                //cmdToExecute.Parameters.Add(new SqlParameter("@creationDate", SqlDbType.Date, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.creationDate));
                //cmdToExecute.Parameters.Add(new SqlParameter("@modifiedDate", SqlDbType.Date, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                //cmdToExecute.Parameters.Add(new SqlParameter("@DueDate", SqlDbType.Date, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));

                //cmdToExecute.Transaction = this.Transaction;
                //_rowsAffected = cmdToExecute.ExecuteNonQuery();


                #endregion

                this.Commit();
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    this.RollBack();
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_MASTER_Insert' reported the ErrorCode: " + _errorCode);

                }

                //DataSet ds = SelectCommercialInvoiceDetailData(_objIEMasterProperty.commercialIdx, Decimal.Parse(cmdToExecute.Parameters["@ID"].Value.ToString()));
                //var dt = ds.Tables[0];
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
        public  bool UpdateCommercialInvoiceDetailsValue(int masterIDx)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            if (masterIDx > 0)
            {
                //Updated Commercial Invoicesp
                cmdToExecute.CommandText = "dbo.[sp_PurchaseUpdate]";
            }
            else
            {
                cmdToExecute.CommandText = "dbo.[sp_ImportedExpenseInsert]";
            }

            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                if (masterIDx > 0)
                {
                    cmdToExecute.Parameters.Add(new SqlParameter("@ieNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.ieNumber));

                    cmdToExecute.Parameters.Add(new SqlParameter("@creationdate", SqlDbType.DateTime, 50, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objIEMasterProperty.creationDate));

                    cmdToExecute.Parameters.Add(new SqlParameter("@createdbyuser", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.createdByUserIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@visible", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objIEMasterProperty.visible));
                    cmdToExecute.Parameters.Add(new SqlParameter("@status", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objIEMasterProperty.status));


                    cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 32, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.idx));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@MRNIdx", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.MRNIdx));
                }
                else
                {
                    //cmdToExecute.Parameters.Add(new SqlParameter("@ieNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.ieNumber));

                    ////cmdToExecute.Parameters.Add(new SqlParameter("@description", SqlDbType.NVarChar, 80, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.description));


                    //cmdToExecute.Parameters.Add(new SqlParameter("@creationdate", SqlDbType.DateTime, 50, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objIEMasterProperty.creationDate));

                    //cmdToExecute.Parameters.Add(new SqlParameter("@createdByUserIdx", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.createdByUserIdx));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@visible", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objIEMasterProperty.visible));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@status", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objIEMasterProperty.status));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@date", SqlDbType.DateTime, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.date));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@totalExpense", SqlDbType.Decimal, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.totalExpense));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 32, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.idx));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@reference", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.reference));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@commercialIdx", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.commercialIdx));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@totalCost", SqlDbType.Decimal, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.totalCost));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@valueAdditionPercent", SqlDbType.Decimal, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.valueAdditionPercent));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@valueAddition", SqlDbType.Decimal, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.valueAddition));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@additionalSalesTaxPercent", SqlDbType.Decimal, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.additionalSalesTaxPercent));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@additionalSalesTax", SqlDbType.Decimal, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.additionalSalesTax));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@profitPercent", SqlDbType.Decimal, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.profitPercent));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@profit", SqlDbType.Decimal, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.profit));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@grandTotalExpense", SqlDbType.Decimal, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.grandTotalExpense));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@finalPercentage", SqlDbType.Decimal, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.finalPercentage));

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

                //if (_objIEMasterProperty.DetailData != null)
                //{
                //    foreach (DataRow row in _objIEMasterProperty.DetailData.Rows)
                //        row["ieIdx"] = cmdToExecute.Parameters["@ID"].Value.ToString();

                //    _objIEMasterProperty.DetailData.AcceptChanges();

                //    SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);
                //    _objIEMasterProperty.DetailData.TableName = "importedExpenseDetails";

                //    sbc.ColumnMappings.Clear();
                //    sbc.ColumnMappings.Add("ieIdx", "ieIdx");
                //    sbc.ColumnMappings.Add("vendorIdx", "vendorIdx");
                //    sbc.ColumnMappings.Add("coaIdx", "coaIdx");
                //    sbc.ColumnMappings.Add("amount", "amount");
                //    sbc.DestinationTableName = _objIEMasterProperty.DetailData.TableName;
                //    sbc.WriteToServer(_objIEMasterProperty.DetailData);

                //}


                // Added By Ahsan
                //if (_objIEMasterProperty.DetailDataInventory_logs != null)
                //{
                //    foreach (DataRow row in _objIEMasterProperty.DetailDataInventory_logs.Rows)
                //    {
                //        row["TransactionTypeID"] = "1";
                //        row["creationDate"] = DateTime.Now.ToString("yyyy-MM-dd");
                //    }

                //    _objIEMasterProperty.DetailDataInventory_logs.AcceptChanges();

                //    SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);

                //    _objIEMasterProperty.DetailDataInventory_logs.TableName = "inventory_logs";

                //    sbc.ColumnMappings.Clear();
                //    sbc.ColumnMappings.Add("TransactionTypeID", "TransactionTypeID");
                //    //sbc.ColumnMappings.Add(2, 1);
                //    //sbc.ColumnMappings.Add("productTypeIdx", "productTypeIdx");
                //    sbc.ColumnMappings.Add("itemIdx", "productIdx");
                //    sbc.ColumnMappings.Add("qty", "stock");
                //    sbc.ColumnMappings.Add("unitPrice", "unitPrice");
                //    sbc.ColumnMappings.Add("amount", "totalAmount");
                //    sbc.ColumnMappings.Add("creationDate", "creationDate");


                //    sbc.DestinationTableName = _objIEMasterProperty.DetailDataInventory_logs.TableName;
                //    sbc.WriteToServer(_objIEMasterProperty.DetailDataInventory_logs);

                //}


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
        // Insert into inventory
        public  bool Insertinventory()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            if (_objIEMasterProperty.idx > 0)
            {
                cmdToExecute.CommandText = "dbo.[sp_Update_inventoryIE]";
            }
            else
            {
                cmdToExecute.CommandText = "dbo.[sp_insert_inventoryIE]";
            }

            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                if (_objIEMasterProperty.idx > 0)
                {
                    cmdToExecute.Parameters.Add(new SqlParameter("@productIdx", SqlDbType.Int, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.itemIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@stock", SqlDbType.Int, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.qty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@warehouseIdx", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.warehouseIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@branchIdx", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.BRANCHID));

                }
                else
                {
                    //Added By Ahsan
                    cmdToExecute.Parameters.Add(new SqlParameter("@productIdx", SqlDbType.Int, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.itemIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@stock", SqlDbType.Int, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.qty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@unitPrice", SqlDbType.Int, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.unitPrice));
                    cmdToExecute.Parameters.Add(new SqlParameter("@totalAmount", SqlDbType.Int, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.amount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@warehouseIdx", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.warehouseIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@branchIdx", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.BRANCHID));

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

        // Delete Imported Expense 
        public bool DeleteIE()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = @"update importedExpense SET visible=0 where idx=@ID";
            //cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@companyIdx", SqlDbType.Int, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objUserProperty.companyIdx));
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.idx));

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

        public override DataTable SelectAll()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetAllImportedExpense]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
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
        public override DataTable SelectOne()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_SelectIEByID]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Select one IE");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.idx));

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


                if (toReturn.Rows.Count > 0)
                {
                    //ObjDepartmentProperty.Department_Id = (Int32)toReturn.Rows[0]["ID"];
                    //ObjDepartmentProperty.DepartmentName = (string)toReturn.Rows[0]["DepartmentName"];
                    //objBankProperty.idx = Convert.ToInt32(toReturn.Rows[0]["idx"]);// == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["idx"]);
                    //objBankProperty.bankName = (toReturn.Rows[0]["bankName"].ToString());// == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["bankName"]).ToString();
                    //objBankProperty.creationDate = Convert.ToDateTime((toReturn.Rows[0]["creationDate"]));// == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["creationDate"]));

                    //objBankProperty.visible = (int)toReturn.Rows[0]["visible"];
                    //objBankProperty.createdByUserIdx = (int)toReturn.Rows[0]["createdByUserIdx"];

                    // ObjDepartmentProperty.ISActive = (bool)toReturn.Rows[0]["IsActive"];
                    // //toReturn.Rows[0]["Product_Form_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Product_Form_ID"];
                    // ObjDepartmentProperty.UserId = (int)toReturn.Rows[0]["UserID"];
                    //string a= (toReturn.Rows[0]["bankName"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["bankName"]).ToString();
                    // ObjDepartmentProperty.CreatedDate = (DateTime)toReturn.Rows[0]["DateCreated"];
                    //   ObjDepartmentProperty.CustomerAddress = (string)toReturn.Rows[0]["Address"];
                    //  toReturn.Rows[0]["Product_Parent_Code"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Product_Parent_Code"];

                }
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

        // Added By Ahsan

        public DataTable SelectOneItem()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_selectItemData]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Select Item Data");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.commercialIdx));

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


                if (toReturn.Rows.Count > 0)
                {
                    //ObjDepartmentProperty.Department_Id = (Int32)toReturn.Rows[0]["ID"];
                    //ObjDepartmentProperty.DepartmentName = (string)toReturn.Rows[0]["DepartmentName"];
                    //objBankProperty.idx = Convert.ToInt32(toReturn.Rows[0]["idx"]);// == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["idx"]);
                    //objBankProperty.bankName = (toReturn.Rows[0]["bankName"].ToString());// == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["bankName"]).ToString();
                    //objBankProperty.creationDate = Convert.ToDateTime((toReturn.Rows[0]["creationDate"]));// == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["creationDate"]));

                    //objBankProperty.visible = (int)toReturn.Rows[0]["visible"];
                    //objBankProperty.createdByUserIdx = (int)toReturn.Rows[0]["createdByUserIdx"];

                    // ObjDepartmentProperty.ISActive = (bool)toReturn.Rows[0]["IsActive"];
                    // //toReturn.Rows[0]["Product_Form_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Product_Form_ID"];
                    // ObjDepartmentProperty.UserId = (int)toReturn.Rows[0]["UserID"];
                    //string a= (toReturn.Rows[0]["bankName"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["bankName"]).ToString();
                    // ObjDepartmentProperty.CreatedDate = (DateTime)toReturn.Rows[0]["DateCreated"];
                    //   ObjDepartmentProperty.CustomerAddress = (string)toReturn.Rows[0]["Address"];
                    //  toReturn.Rows[0]["Product_Parent_Code"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Product_Parent_Code"];

                }
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



        //public override DataTable SelectItemsData()
        //{
        //    SqlCommand cmdToExecute = new SqlCommand();
        //    cmdToExecute.CommandText = "dbo.[sp_selectItemData]";
        //    cmdToExecute.CommandType = CommandType.StoredProcedure;
        //    DataTable toReturn = new DataTable("Select Item Data");
        //    SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

        //    // Use base class' connection object
        //    cmdToExecute.Connection = _mainConnection;

        //    try
        //    {
        //        cmdToExecute.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.commercialIdx));

        //        if (_mainConnectionIsCreatedLocal)
        //        {
        //            // Open connection.
        //            _mainConnection.Open();
        //        }
        //        else
        //        {
        //            if (_mainConnectionProvider.IsTransactionPending)
        //            {
        //                cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
        //            }
        //        }

        //        // Execute query.
        //        adapter.Fill(toReturn);


        //        if (toReturn.Rows.Count > 0)
        //        {
        //            //ObjDepartmentProperty.Department_Id = (Int32)toReturn.Rows[0]["ID"];
        //            //ObjDepartmentProperty.DepartmentName = (string)toReturn.Rows[0]["DepartmentName"];
        //            //objBankProperty.idx = Convert.ToInt32(toReturn.Rows[0]["idx"]);// == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["idx"]);
        //            //objBankProperty.bankName = (toReturn.Rows[0]["bankName"].ToString());// == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["bankName"]).ToString();
        //            //objBankProperty.creationDate = Convert.ToDateTime((toReturn.Rows[0]["creationDate"]));// == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["creationDate"]));

        //            //objBankProperty.visible = (int)toReturn.Rows[0]["visible"];
        //            //objBankProperty.createdByUserIdx = (int)toReturn.Rows[0]["createdByUserIdx"];

        //            // ObjDepartmentProperty.ISActive = (bool)toReturn.Rows[0]["IsActive"];
        //            // //toReturn.Rows[0]["Product_Form_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Product_Form_ID"];
        //            // ObjDepartmentProperty.UserId = (int)toReturn.Rows[0]["UserID"];
        //            //string a= (toReturn.Rows[0]["bankName"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["bankName"]).ToString();
        //            // ObjDepartmentProperty.CreatedDate = (DateTime)toReturn.Rows[0]["DateCreated"];
        //            //   ObjDepartmentProperty.CustomerAddress = (string)toReturn.Rows[0]["Address"];
        //            //  toReturn.Rows[0]["Product_Parent_Code"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Product_Parent_Code"];

        //        }
        //        return toReturn;
        //    }
        //    catch (Exception ex)
        //    {
        //        // some error occured. Bubble it to caller and encapsulate Exception object
        //        throw new Exception("PRODUCT_SETUP::SelectOne::Error occured.", ex);
        //    }
        //    finally
        //    {
        //        if (_mainConnectionIsCreatedLocal)
        //        {
        //            // Close connection.
        //            _mainConnection.Close();
        //        }
        //        cmdToExecute.Dispose();
        //        adapter.Dispose();
        //    }
        //}
        public DataSet SelectCommercialInvoiceDetailData(int MasterIdx,decimal ieIdx)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_selectCommercialItemData]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("Select Item Data");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, MasterIdx));
                cmdToExecute.Parameters.Add(new SqlParameter("@ieIdx", SqlDbType.Int, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, ieIdx));

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
        public DataTable SelectTaxOnQS()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "select * from salesTaxes where taxType=2 and ieIdx=@qsid";
            //cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Bank Setup");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@qsid", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objIEMasterProperty.idx));

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


                if (toReturn.Rows.Count > 0)
                {


                }
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
        public DataTable SelectQS()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "select idx,concat('QS-',idx) as doNumber from quotation where visible=1 and status=0";

            DataTable toReturn = new DataTable("MRN");
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
        public DataTable SelectForDropDown()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetAllDisplayOrdersForDDL]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
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
        public DataTable GeneratePONo(LP_GenerateTransNumber_Property objTranNo)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GenerateTransNo]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Po");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@tablename", SqlDbType.VarChar, 40, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objTranNo.TableName));
                cmdToExecute.Parameters.Add(new SqlParameter("@identityfieldname", SqlDbType.NVarChar, 40, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objTranNo.Identityfieldname));
                cmdToExecute.Parameters.Add(new SqlParameter("@userid", SqlDbType.Int, 40, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objTranNo.userid));

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


                if (toReturn.Rows.Count > 0)
                {
                    //ObjDepartmentProperty.Department_Id = (Int32)toReturn.Rows[0]["ID"];
                    //ObjDepartmentProperty.DepartmentName = (string)toReturn.Rows[0]["DepartmentName"];
                    //objBankProperty.idx = Convert.ToInt32(toReturn.Rows[0]["idx"]);// == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["idx"]);
                    //objBankProperty.bankName = (toReturn.Rows[0]["bankName"].ToString());// == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["bankName"]).ToString();
                    //objBankProperty.creationDate = Convert.ToDateTime((toReturn.Rows[0]["creationDate"]));// == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["creationDate"]));

                    //objBankProperty.visible = (int)toReturn.Rows[0]["visible"];
                    //objBankProperty.createdByUserIdx = (int)toReturn.Rows[0]["createdByUserIdx"];

                    // ObjDepartmentProperty.ISActive = (bool)toReturn.Rows[0]["IsActive"];
                    // //toReturn.Rows[0]["Product_Form_ID"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Product_Form_ID"];
                    // ObjDepartmentProperty.UserId = (int)toReturn.Rows[0]["UserID"];
                    //string a= (toReturn.Rows[0]["bankName"] == System.DBNull.Value ? SqlString.Null : (string)toReturn.Rows[0]["bankName"]).ToString();
                    // ObjDepartmentProperty.CreatedDate = (DateTime)toReturn.Rows[0]["DateCreated"];
                    //   ObjDepartmentProperty.CustomerAddress = (string)toReturn.Rows[0]["Address"];
                    //  toReturn.Rows[0]["Product_Parent_Code"] == System.DBNull.Value ? SqlInt32.Null : (Int32)toReturn.Rows[0]["Product_Parent_Code"];

                }
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
