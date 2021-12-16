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
   public class LP_PI_DAL : DBInteractionBase
   {
        int GLIDX;
         int ID;
       private LP_ImportedExpense_Master_Property _objIEMaster;
        private LP_Performa_Invoice_Property _objPerformaMaster;
        private LP_Performa_Invoice_Details_Property _objPerformaDetail;
        private LP_CI_PurchaseOrder_Property _objCIMaster;
        private LP_CI_PurchaseDetails_Property _objCIDetail;
        private LP_Consigment_Property _objConsigmnetProperty;
        private LP_ConsigmentDetails _objConsignmentDetails;

        public LP_PI_DAL()
        {

        }

        public LP_PI_DAL(LP_Consigment_Property objConMasterProperty)
        {
            _objConsigmnetProperty = objConMasterProperty;
        }
        public LP_PI_DAL(LP_Performa_Invoice_Property objPOMasterProperty)
        {
            _objPerformaMaster = objPOMasterProperty;
        }
        public LP_PI_DAL(LP_CI_PurchaseOrder_Property objPIMasterProperty)
        {
            _objCIMaster = objPIMasterProperty;
        }
        public LP_PI_DAL(LP_Performa_Invoice_Details_Property objPODetailProperty)
        {
            _objPerformaDetail = objPODetailProperty;
        } 

        public override bool Insert()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            if (_objPerformaMaster.idx > 0)
            {
                //sp_PurchaseUpdate
                cmdToExecute.CommandText = "dbo.[sp_PerformainvoiceUpdate]";
            }
            else
            {
                cmdToExecute.CommandText = "dbo.[sp_PerformainvoiceInsert]";
            }

            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                if (_objPerformaMaster.idx > 0)
                {
                    cmdToExecute.Parameters.Add(new SqlParameter("@detailID", SqlDbType.Int, 32, ParameterDirection.Output,
                        true, 10, 0, "", DataRowVersion.Proposed, _objPerformaMaster.idx));
                    // Accounts
                    cmdToExecute.Parameters.Add(new SqlParameter("@masterIdx", SqlDbType.Int, 32, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _objPerformaMaster.glIdx));

                    cmdToExecute.Parameters.Add(new SqlParameter("@poNumber", SqlDbType.NVarChar, 50,
                        ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed,
                        _objPerformaMaster.poNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@vendorIdx", SqlDbType.Int, 50,ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed,_objPerformaMaster.vendorIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@branchIdx", SqlDbType.Int, 50,
                        ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed,
                        _objPerformaMaster.branchIdx));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@purchasedate", SqlDbType.DateTime, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _objPerformaMaster.purchaseDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@reference", SqlDbType.NVarChar, 32,
                        ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed,
                        _objPerformaMaster.reference));
                    cmdToExecute.Parameters.Add(new SqlParameter("@description", SqlDbType.NVarChar, 80,
                        ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                        _objPerformaMaster.description));
                    cmdToExecute.Parameters.Add(new SqlParameter("@totalamount", SqlDbType.Decimal, 4,
                        ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed,
                        _objPerformaMaster.totalAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@netamount", SqlDbType.Decimal, 9,
                        ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed,
                        _objPerformaMaster.netAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@paidAmount", SqlDbType.Decimal, 20,
                        ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed,
                        _objPerformaMaster.paidAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@balanceamount", SqlDbType.Decimal, 4,
                        ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                        _objPerformaMaster.balanceAmount));

                    //cmdToExecute.Parameters.Add(new SqlParameter("@lastModificationDate", SqlDbType.DateTime, 50, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, null));

                    cmdToExecute.Parameters.Add(new SqlParameter("@lastmodifiedBy", SqlDbType.Int, 4,
                        ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                        _objPerformaMaster.createdByUserIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@visible", SqlDbType.Int, 4, ParameterDirection.Input,
                        true, 18, 1, "", DataRowVersion.Proposed, _objPerformaMaster.visible));
                    cmdToExecute.Parameters.Add(new SqlParameter("@status", SqlDbType.Int, 4, ParameterDirection.Input,
                        true, 18, 1, "", DataRowVersion.Proposed, _objPerformaMaster.status));


                    cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 32, ParameterDirection.Input,
                        true, 10, 0, "", DataRowVersion.Proposed, _objPerformaMaster.idx));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@DepartmentID", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objPerformaMaster.DepartmentID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@DocumentNumber", SqlDbType.NVarChar, 50,
                        ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed,
                        _objPerformaMaster.DocumentNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@ContainerNo", SqlDbType.NVarChar, 80,
                        ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed,
                        _objPerformaMaster.ContainerNo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@ExchangeRate", SqlDbType.Decimal, 32,
                        ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed,
                        _objPerformaMaster.ExchangeRate));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@grandTotalAVPKR", SqlDbType.Decimal, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed,_objPerformaMaster.grandTotalAVPKR));

                    //cmdToExecute.Parameters.Add(new SqlParameter("@CIcheck", SqlDbType.Int, 32,
                    //    ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed,
                    //    _objPerformaMaster.CIcheck));
                    cmdToExecute.Parameters.Add(new SqlParameter("@numberOfProducts", SqlDbType.Int, 32,
                        ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed,
                        _objPerformaMaster.numberOfProducts));

                }
                else
                {
                    // cmdToExecute.Parameters.Add(new SqlParameter("@branchIdx", SqlDbType.Int, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, null)); //Receipt Voucher Transaction Type
                    //Accounts
                    cmdToExecute.Parameters.Add(new SqlParameter("@transactionTypeIdx", SqlDbType.Int, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1)); //Activity
                    cmdToExecute.Parameters.Add(new SqlParameter("@glIdx", SqlDbType.Int, 500, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Proposed, _objPerformaMaster.glIdx));

                    // Performa Invoice
                    cmdToExecute.Parameters.Add(new SqlParameter("@poNumber", SqlDbType.NVarChar, 50,
                        ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed,
                        _objPerformaMaster.poNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@vendorIdx", SqlDbType.Int, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objPerformaMaster.vendorIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@branchIdx", SqlDbType.Int, 50,
                        ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed,
                        _objPerformaMaster.branchIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@purchasedate", SqlDbType.DateTime, 50,
                        ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed,
                        _objPerformaMaster.purchaseDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@reference", SqlDbType.NVarChar, 32,
                        ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed,
                        _objPerformaMaster.reference));
                    cmdToExecute.Parameters.Add(new SqlParameter("@description", SqlDbType.NVarChar, 80,
                        ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                        _objPerformaMaster.description));
                    cmdToExecute.Parameters.Add(new SqlParameter("@totalamount", SqlDbType.Decimal, 4,
                        ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed,
                        _objPerformaMaster.totalAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@netamount", SqlDbType.Decimal, 9,
                        ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed,
                        _objPerformaMaster.netAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@paidAmount", SqlDbType.Decimal, 20,
                        ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed,
                        _objPerformaMaster.paidAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@balanceamount", SqlDbType.Decimal, 4,
                        ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                        _objPerformaMaster.balanceAmount));

                    cmdToExecute.Parameters.Add(new SqlParameter("@creationdate", SqlDbType.DateTime, 50,
                        ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed,
                        _objPerformaMaster.creationDate));

                    cmdToExecute.Parameters.Add(new SqlParameter("@createdbyuser", SqlDbType.Int, 4,
                        ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                        _objPerformaMaster.createdByUserIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@visible", SqlDbType.Int, 4, ParameterDirection.Input,
                        true, 18, 1, "", DataRowVersion.Proposed, _objPerformaMaster.visible));
                    cmdToExecute.Parameters.Add(new SqlParameter("@status", SqlDbType.Int, 4, ParameterDirection.Input,
                        true, 18, 1, "", DataRowVersion.Proposed, _objPerformaMaster.status));


                    cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 32, ParameterDirection.Output,
                        true, 10, 0, "", DataRowVersion.Proposed, _objPerformaMaster.idx));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@DepartmentID", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objPerformaMaster.DepartmentID));

                    cmdToExecute.Parameters.Add(new SqlParameter("@DocumentNumber", SqlDbType.NVarChar, 50,
                        ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed,
                        _objPerformaMaster.DocumentNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@ContainerNo", SqlDbType.NVarChar, 80,
                        ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed,
                        _objPerformaMaster.ContainerNo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@ExchangeRate", SqlDbType.Decimal, 32,
                        ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed,
                        _objPerformaMaster.ExchangeRate));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@grandTotalAVPKR", SqlDbType.Decimal, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objPerformaMaster.grandTotalAVPKR));
                    cmdToExecute.Parameters.Add(new SqlParameter("@CIcheck", SqlDbType.Int, 32,
                        ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed,
                        _objPerformaMaster.CIcheck));
                    cmdToExecute.Parameters.Add(new SqlParameter("@IEcheck", SqlDbType.Int, 32,
                        ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed,
                        _objPerformaMaster.IEcheck));
                    cmdToExecute.Parameters.Add(new SqlParameter("@numberOfProducts", SqlDbType.Int, 32,
                        ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed,
                        _objPerformaMaster.numberOfProducts));
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
                if (_objPerformaMaster.idx > 0)
                {
                    int detailID = (Int32)cmdToExecute.Parameters["@detailID"].Value;
                   // int masterID = (Int32)cmdToExecute.Parameters["@masterIdx"].Value;

                    if (_objPerformaMaster.DetailData != null)
                    {
                        foreach (DataRow row in _objPerformaMaster.DetailData.Rows)
                        
                            row["purchaseIdx"] = detailID;
                            //row["grandTotalAVPKR"] =
                            //    (decimal.Parse(row["TADVRate"].ToString()) * (_objPerformaMaster.ExchangeRate))
                            //    .ToString();
                        


                        _objPerformaMaster.DetailData.AcceptChanges();

                        SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default,
                            this.Transaction);
                        _objPerformaMaster.DetailData.TableName = "CommercialDetails";

                        sbc.ColumnMappings.Clear();
                        sbc.ColumnMappings.Add("purchaseIdx", "purchaseIdx");
                        //sbc.ColumnMappings.Add(2, 1);
                        sbc.ColumnMappings.Add("productTypeIdx", "productTypeIdx");
                        sbc.ColumnMappings.Add("itemIdx", "itemIdx");
                        //sbc.ColumnMappings.Add("gridVendorIdx", "gridVendorIdx");
                        sbc.ColumnMappings.Add("unitPrice", "unitPrice");
                        sbc.ColumnMappings.Add("qty", "qty");
                        sbc.ColumnMappings.Add("amount", "amount");
                        sbc.ColumnMappings.Add("qty", "openItem");
                        sbc.ColumnMappings.Add("ItemDescription", "ItemDescription");
                        sbc.ColumnMappings.Add("unitPrice", "DVRate");
                        sbc.ColumnMappings.Add("amount", "TDVRate");
                        //sbc.ColumnMappings.Add("ADVRate", "ADVRate");
                        //sbc.ColumnMappings.Add("TADVRate", "TADVRate");
                        //sbc.ColumnMappings.Add("grandTotalAVPKR", "grandTotalAVPKR");
                        //sbc.ColumnMappings.Add("Product_Code", "Product_Code");
                        //sbc.ColumnMappings.Add("Product", "Product_Name");
                        //sbc.ColumnMappings.Add("Status", "Status");

                        //sbc.ColumnMappings.Add("Department_Id", "Department_Id");
                        //sbc.ColumnMappings.Add("Description", "Description");

                        sbc.DestinationTableName = _objPerformaMaster.DetailData.TableName;
                        sbc.WriteToServer(_objPerformaMaster.DetailData);

                    }
                    //if (_objPerformaMaster.DetailData.Rows.Count>0)
                    //{
                    //    foreach (DataRow row in _objPerformaMaster.DetailData.Rows)
                    //    {
                    //        row["purchaseIdx"] = detailID;
                    //        //row["grandTotalAVPKR"] =
                    //        //    (decimal.Parse(row["TADVRate"].ToString()) * (_objPerformaMaster.ExchangeRate))
                    //        //    .ToString();
                    //        _objPerformaMaster.DetailData.AcceptChanges();

                    //        SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default,
                    //            this.Transaction);
                    //        _objPerformaMaster.DetailData.TableName = "CommercialDetails";

                    //        sbc.ColumnMappings.Clear();

                    //        //row["purchaseIdx"] = detailID;

                    //        // row["purchaseIdx"] = cmdToExecute.Parameters["@ID"].Value.ToString();


                    //        // SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default,
                    //        //    this.Transaction);
                    //        //_objPerformaMaster.DetailData.TableName = "CommercialDetails";

                    //        //sbc.ColumnMappings.Clear();
                    //        //_objPerformaMaster.DetailData.AcceptChanges();
                    //        sbc.ColumnMappings.Add("purchaseIdx", "purchaseIdx");
                    //        //sbc.ColumnMappings.Add(2, 1);
                    //        sbc.ColumnMappings.Add("productTypeIdx", "productTypeIdx");
                    //        sbc.ColumnMappings.Add("itemIdx", "itemIdx");
                    //       // sbc.ColumnMappings.Add("gridVendorIdx", "gridVendorIdx");
                    //        sbc.ColumnMappings.Add("unitPrice", "unitPrice");
                    //        sbc.ColumnMappings.Add("qty", "qty");
                    //        sbc.ColumnMappings.Add("amount", "amount");
                    //        sbc.ColumnMappings.Add("qty", "openItem");
                    //        sbc.ColumnMappings.Add("ItemDescription", "ItemDescription");
                    //        sbc.ColumnMappings.Add("unitPrice", "DVRate");
                    //        sbc.ColumnMappings.Add("amount", "TDVRate");
                    //        //sbc.ColumnMappings.Add("ADVRate", "ADVRate");
                    //        //sbc.ColumnMappings.Add("TADVRate", "TADVRate");
                    //        //sbc.ColumnMappings.Add("grandTotalAVPKR", "grandTotalAVPKR");
                    //        //sbc.ColumnMappings.Add("Product_Code", "Product_Code");
                    //        //sbc.ColumnMappings.Add("Product", "Product_Name");
                    //        //sbc.ColumnMappings.Add("Status", "Status");

                    //        //sbc.ColumnMappings.Add("Department_Id", "Department_Id");
                    //        //sbc.ColumnMappings.Add("Description", "Description");

                    //        sbc.DestinationTableName = _objPerformaMaster.DetailData.TableName;
                    //        sbc.WriteToServer(_objPerformaMaster.DetailData);
                    //    }
                    //}

                    // AccountGJ insert
                    if (_objPerformaMaster.DetailData != null)
                    {
                        int masterIdx = (Int32)cmdToExecute.Parameters["@masterIdx"].Value;

                        DataTable dt = new DataTable();
                        dt = _objPerformaMaster.DetailData;
                        int count = _objPerformaMaster.DetailData.Rows.Count;
                        int customerIdx, coaIdx;
                        string invoiceNo;
                        decimal Price, TotalPrice, credit, debit;
                        int vendorIdx, vendor;
                        for (int i = 0; i < count; i++)
                        {
                            decimal.TryParse(dt.Rows[i]["amount"].ToString(), out Price);
                            decimal.TryParse(dt.Rows[i]["TADVRate"].ToString(), out TotalPrice);
                            int.TryParse(dt.Rows[i]["gridVendorIdx"].ToString(), out vendor);
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
                                ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, masterIdx));
                            cmdToExecute.Parameters.Add(new SqlParameter("@TransTypeIdx", SqlDbType.Int, 500,
                                ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed,
                                1)); //Receipt Voucher Trasaction Type

                            cmdToExecute.Parameters.Add(new SqlParameter("@useridx", SqlDbType.Int, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                                _objPerformaMaster.createdByUserIdx));

                            cmdToExecute.Parameters.Add(new SqlParameter("@vendoridx", SqlDbType.Int, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, vendorIdx));
                            cmdToExecute.Parameters.Add(new SqlParameter("@employeeidx", SqlDbType.Int, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                            cmdToExecute.Parameters.Add(new SqlParameter("@customeridx", SqlDbType.Int, 25,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                            cmdToExecute.Parameters.Add(new SqlParameter("@coaidx", SqlDbType.Int, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 89)); //Sales
                            cmdToExecute.Parameters.Add(new SqlParameter("@invoiceidx", SqlDbType.NVarChar, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objPerformaMaster.poNumber));

                            cmdToExecute.Parameters.Add(new SqlParameter("@debit", SqlDbType.Decimal, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, debit));

                            cmdToExecute.Parameters.Add(new SqlParameter("@credit", SqlDbType.Decimal, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, credit));
                            cmdToExecute.Parameters.Add(new SqlParameter("@creationDate", SqlDbType.DateTime, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                                _objPerformaMaster.creationDate));
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
                    GLIDX = (Int32) cmdToExecute.Parameters["@glIdx"].Value;

                    if (_objPerformaMaster.DetailData != null)
                    {
                        foreach (DataRow row in _objPerformaMaster.DetailData.Rows)
                        {
                            row["purchaseIdx"] = cmdToExecute.Parameters["@ID"].Value.ToString();
                            //row["grandTotalAVPKR"] =
                            //    (decimal.Parse(row["TADVRate"].ToString()) * (_objPerformaMaster.ExchangeRate))
                            //    .ToString();
                        }


                        _objPerformaMaster.DetailData.AcceptChanges();

                        SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default,
                            this.Transaction);
                        _objPerformaMaster.DetailData.TableName = "CommercialDetails";

                        sbc.ColumnMappings.Clear();
                        sbc.ColumnMappings.Add("purchaseIdx", "purchaseIdx");
                        //sbc.ColumnMappings.Add(2, 1);
                        sbc.ColumnMappings.Add("productTypeIdx", "productTypeIdx");
                        sbc.ColumnMappings.Add("itemIdx", "itemIdx");
                        //sbc.ColumnMappings.Add("gridVendorIdx", "gridVendorIdx");
                        sbc.ColumnMappings.Add("unitPrice", "unitPrice");
                        sbc.ColumnMappings.Add("qty", "qty");
                        sbc.ColumnMappings.Add("amount", "amount");
                        sbc.ColumnMappings.Add("qty", "openItem");
                        sbc.ColumnMappings.Add("ItemDescription", "ItemDescription");
                        sbc.ColumnMappings.Add("unitPrice", "DVRate");
                        sbc.ColumnMappings.Add("amount", "TDVRate");
                        //sbc.ColumnMappings.Add("ADVRate", "ADVRate");
                        //sbc.ColumnMappings.Add("TADVRate", "TADVRate");
                        //sbc.ColumnMappings.Add("grandTotalAVPKR", "grandTotalAVPKR");
                        //sbc.ColumnMappings.Add("Product_Code", "Product_Code");
                        //sbc.ColumnMappings.Add("Product", "Product_Name");
                        //sbc.ColumnMappings.Add("Status", "Status");

                        //sbc.ColumnMappings.Add("Department_Id", "Department_Id");
                        //sbc.ColumnMappings.Add("Description", "Description");

                        sbc.DestinationTableName = _objPerformaMaster.DetailData.TableName;
                        sbc.WriteToServer(_objPerformaMaster.DetailData);

                    }

                    // AccountGJ insert
                    if (_objPerformaMaster.DetailData != null)
                    {
                        DataTable dt = new DataTable();
                        dt = _objPerformaMaster.DetailData;
                        int count = _objPerformaMaster.DetailData.Rows.Count;
                        int customerIdx, coaIdx;
                        string invoiceNo;
                        decimal Price, TotalPrice, credit, debit;
                        int vendorIdx, vendor;
                        for (int i = 0; i < count; i++)
                        {
                            decimal.TryParse(dt.Rows[i]["amount"].ToString(), out Price);
                            decimal.TryParse(dt.Rows[i]["TADVRate"].ToString(), out TotalPrice);
                            int.TryParse(dt.Rows[i]["gridVendorIdx"].ToString(), out vendor);
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
                                _objPerformaMaster.createdByUserIdx));

                            cmdToExecute.Parameters.Add(new SqlParameter("@vendoridx", SqlDbType.Int, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, vendorIdx));
                            cmdToExecute.Parameters.Add(new SqlParameter("@employeeidx", SqlDbType.Int, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                            cmdToExecute.Parameters.Add(new SqlParameter("@customeridx", SqlDbType.Int, 25,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                            cmdToExecute.Parameters.Add(new SqlParameter("@coaidx", SqlDbType.Int, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 89)); //Sales
                            cmdToExecute.Parameters.Add(new SqlParameter("@invoiceidx", SqlDbType.NVarChar, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                                _objPerformaMaster.poNumber));

                            cmdToExecute.Parameters.Add(new SqlParameter("@debit", SqlDbType.Decimal, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, debit));

                            cmdToExecute.Parameters.Add(new SqlParameter("@credit", SqlDbType.Decimal, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, credit));
                            cmdToExecute.Parameters.Add(new SqlParameter("@creationDate", SqlDbType.Date, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                                _objPerformaMaster.creationDate));
                            cmdToExecute.Parameters.Add(new SqlParameter("@modifiedDate", SqlDbType.Date, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                            cmdToExecute.Parameters.Add(new SqlParameter("@DueDate", SqlDbType.Date, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));

                            cmdToExecute.Transaction = this.Transaction;
                            _rowsAffected = cmdToExecute.ExecuteNonQuery();
                        }

                    }

                    // Inventory & Inventory_logs
                    if (_objPerformaMaster.DetailData != null)
                    {
                        // Inventory
                        for (int i = 0; i < _objPerformaMaster.DetailData.Rows.Count; i++)
                        {
                            cmdToExecute = new SqlCommand();
                            cmdToExecute.CommandText = "sp_PIinsert_inventory";
                            cmdToExecute.CommandType = CommandType.StoredProcedure;
                            cmdToExecute.Connection = _mainConnection;


                            cmdToExecute.Parameters.Add(new SqlParameter("@productIdx", SqlDbType.Int, 50,
                                ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed,
                                Convert.ToInt16(_objPerformaMaster.DetailData.Rows[i]["itemIdx"])));
                            cmdToExecute.Parameters.Add(new SqlParameter("@stock", SqlDbType.Int, 50,
                                ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed,
                                Convert.ToInt16(_objPerformaMaster.DetailData.Rows[i]["qty"])));
                            cmdToExecute.Parameters.Add(new SqlParameter("@unitPrice", SqlDbType.Int, 50,
                                ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed,
                                Convert.ToInt16(_objPerformaMaster.DetailData.Rows[i]["unitprice"])));
                            cmdToExecute.Parameters.Add(new SqlParameter("@totalAmount", SqlDbType.Int, 50,
                                ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed,
                                Convert.ToInt16(_objPerformaMaster.DetailData.Rows[i]["amount"])));
                            cmdToExecute.Parameters.Add(new SqlParameter("@branchIdx", SqlDbType.Int, 4,
                                ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed,
                                Convert.ToInt16(_objPerformaMaster.DetailData.Rows[i]["branchIdx"])));
                            cmdToExecute.Parameters.Add(new SqlParameter("@TransTypeIdx", SqlDbType.Int, 4,
                                ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, 1));

                            cmdToExecute.Parameters.Add(new SqlParameter("@masterId", SqlDbType.Int, 4,
                                ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _objPerformaMaster.masterId));

                            cmdToExecute.Transaction = this.Transaction;
                            _rowsAffected = cmdToExecute.ExecuteNonQuery();
                        }

                        // Inventory Logs
                        foreach (DataRow row in _objPerformaMaster.DetailData.Rows)
                        {
                            int masterId = (Int32) cmdToExecute.Parameters["@masterId"].Value;

                            row["MasterID"] = masterId;
                            row["TransTypeIdx"] = "1";
                            row["creationDate"] = DateTime.Now.ToString("yyyy-MM-dd");
                        }

                        _objPerformaMaster.DetailData.AcceptChanges();

                        SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default,
                            this.Transaction);

                        _objPerformaMaster.DetailData.TableName = "inventory_logs";

                        sbc.ColumnMappings.Clear();
                        sbc.ColumnMappings.Add("MasterID", "MasterID");

                        sbc.ColumnMappings.Add("TransTypeIdx", "TransTypeIdx");
                        //sbc.ColumnMappings.Add(2, 1);
                        //sbc.ColumnMappings.Add("productTypeIdx", "productTypeIdx");
                        sbc.ColumnMappings.Add("itemIdx", "productIdx");
                        sbc.ColumnMappings.Add("qty", "stock");
                        sbc.ColumnMappings.Add("unitprice", "unitPrice");
                        sbc.ColumnMappings.Add("amount", "totalAmount");
                       
                        sbc.ColumnMappings.Add("branchIdx", "BRANCHID");
                        //sbc.ColumnMappings.Add("wareHouseIdx", "wareHouseIdx");


                        sbc.DestinationTableName = _objPerformaMaster.DetailData.TableName;
                        sbc.WriteToServer(_objPerformaMaster.DetailData);

                    }
                }

                this.Commit();
                        if (_errorCode != (int) LLBLError.AllOk)
                        {
                            // Throw error.
                            this.RollBack();
                            throw new Exception(
                                "Stored Procedure 'sp_TRANSACTION_MASTER_Insert' reported the ErrorCode: " +
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

        // Delete Perfoma Invoice
        public bool Delete()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = @"update CommercialInvoice SET visible=0 where idx=@ID";
            //cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@companyIdx", SqlDbType.Int, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objUserProperty.companyIdx));
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objPerformaMaster.idx));

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

        
        // For Update view PI
        public override DataTable SelectOne()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = @"select * from CommercialInvoice c 
inner join CommercialDetails cd on cd.purchaseIdx = c.idx
inner join products p on p.idx = cd.itemIdx
inner join branch b on b.idx = c.branchIdx
where c.idx=@ID";
            //cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Select one Commercial Invoice");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@companyIdx", SqlDbType.Int, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objUserProperty.companyIdx));
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _objPerformaMaster.idx));

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

        // For update view CI
        public  DataTable SelectOneCI()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = @"select * from [dbo].[CI_PurchaseOrder] c 
inner join CI_PurchaseDetails cid on cid.purchaseIdx = c.idx
inner join ChartofAccountsChildHead ch on ch.idx = cid.coaIdx
inner join vendors v on v.idx = cid.vendorIdx
where c.idx=@ID";
            //cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Select one Commercial Invoice");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@companyIdx", SqlDbType.Int, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objUserProperty.companyIdx));
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _objCIMaster.idx));

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

        // Delete Commercial Invoice 
        public bool DeleteCI()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = @"update CI_PurchaseOrder SET visible=0 where idx=@ID";
            //cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@companyIdx", SqlDbType.Int, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objUserProperty.companyIdx));
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objCIMaster.idx));

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

        // PI list for CIPO
        public  DataTable SelectAllDT()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetAllPerformaInvoiceDT]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Banks");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@ProductCode", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Product_Code));
                // cmdToExecute.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Product_Name));
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

        // PI list for IE
        public  DataTable SelectAllIE()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetAllPerformaInvoiceIE]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Banks");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@ProductCode", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Product_Code));
                // cmdToExecute.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Product_Name));
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

        public override DataTable SelectAll()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetAllPerformaInvoice]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Banks");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@ProductCode", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Product_Code));
                // cmdToExecute.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Product_Name));
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
        public  DataTable SelectPIBYID(int id)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_SelctPerfomaByid]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Bank Setup");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@pid", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, id));

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

        #region CIPO
        public bool InsertCIPO()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            if (_objCIMaster.idx > 0)
            {
                //sp_PurchaseUpdate
                cmdToExecute.CommandText = "dbo.[sp_CI_PO_Update]";
            }
            else
            {
                cmdToExecute.CommandText = "dbo.[sp_CI_PO_InserT]";
            }

            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                if (_objCIMaster.idx > 0)
                {
                    cmdToExecute.Parameters.Add(new SqlParameter("@masterIdx", SqlDbType.Int, 32, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _objCIMaster.glIdx));

                    cmdToExecute.Parameters.Add(new SqlParameter("@poNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objCIMaster.poNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@PINO", SqlDbType.Int, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objCIMaster.PINO));
                   // cmdToExecute.Parameters.Add(new SqlParameter("@purchaseDate", SqlDbType.DateTime, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objCIMaster.purchaseDate));

                    cmdToExecute.Parameters.Add(new SqlParameter("@description", SqlDbType.NVarChar, 80, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objCIMaster.description));
                    cmdToExecute.Parameters.Add(new SqlParameter("@totalamount", SqlDbType.Decimal, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objCIMaster.totalAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@totalTD", SqlDbType.Decimal, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objCIMaster.totalTD));//Added By Arsalan 12-04-21
                   // cmdToExecute.Parameters.Add(new SqlParameter("@creationdate", SqlDbType.DateTime, 50, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objCIMaster.creationDate.ToString("yyyy-MM-ddTHH:mm:ss.fff")));
                    cmdToExecute.Parameters.Add(new SqlParameter("@CIcheck", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objCIMaster.CIcheck));

                    cmdToExecute.Parameters.Add(new SqlParameter("@createdByUserIdx", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objCIMaster.createdByUserIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@visible", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objCIMaster.visible));
                    cmdToExecute.Parameters.Add(new SqlParameter("@status", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objCIMaster.status));
                    cmdToExecute.Parameters.Add(new SqlParameter("@numberOfProducts", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objCIMaster.numberOfProducts));
                    cmdToExecute.Parameters.Add(new SqlParameter("@grandTotalAVPKR", SqlDbType.Decimal, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objCIMaster.grandTotalAVPKR));
                    cmdToExecute.Parameters.Add(new SqlParameter("@ExchangeRate", SqlDbType.Decimal, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objCIMaster.ExchangeRate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objCIMaster.idx));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@purchaseDate", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objCIMaster.DepartmentID));

                }
                else
                {
                    // Account Master entry
                    cmdToExecute.Parameters.Add(new SqlParameter("@transactionTypeIdx", SqlDbType.Int, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 1)); //Activity
                    cmdToExecute.Parameters.Add(new SqlParameter("@glIdx", SqlDbType.Int, 500, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Proposed, _objCIMaster.glIdx));

                    // Insert into inventory
                    //cmdToExecute.Parameters.Add(new SqlParameter("@productIdx", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objCIMaster.productIdx));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@stock", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objCIMaster.stock));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@unitPrice", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objCIMaster.unitPrice));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@totalAmountInv", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objCIMaster.totalAmount));

                    // Insert into CIPO
                    cmdToExecute.Parameters.Add(new SqlParameter("@poNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objCIMaster.poNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@PINO", SqlDbType.Int, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objCIMaster.PINO));
                    cmdToExecute.Parameters.Add(new SqlParameter("@purchaseDate", SqlDbType.DateTime, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objCIMaster.purchaseDate));

                    cmdToExecute.Parameters.Add(new SqlParameter("@description", SqlDbType.NVarChar, 80, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objCIMaster.description));
                    cmdToExecute.Parameters.Add(new SqlParameter("@totalamount", SqlDbType.Decimal, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objCIMaster.totalAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@totalTD", SqlDbType.Decimal, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objCIMaster.totalTD));//Added By Arsalan 12-04-21
                    cmdToExecute.Parameters.Add(new SqlParameter("@TD", SqlDbType.Decimal, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objCIMaster.TD));//Added By Arsalan 12-04-21
                    cmdToExecute.Parameters.Add(new SqlParameter("@creationdate", SqlDbType.DateTime, 50, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objCIMaster.creationDate.ToString("yyyy-MM-ddTHH:mm:ss.fff")));
                    cmdToExecute.Parameters.Add(new SqlParameter("@CIcheck", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objCIMaster.CIcheck));

                    cmdToExecute.Parameters.Add(new SqlParameter("@createdByUserIdx", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objCIMaster.createdByUserIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@visible", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objCIMaster.visible));
                    cmdToExecute.Parameters.Add(new SqlParameter("@status", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objCIMaster.status));
                    cmdToExecute.Parameters.Add(new SqlParameter("@numberOfProducts", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objCIMaster.numberOfProducts));
                   // cmdToExecute.Parameters.Add(new SqlParameter("@grandTotalAVPKR", SqlDbType.Decimal, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objCIMaster.grandTotalAVPKR));
                    cmdToExecute.Parameters.Add(new SqlParameter("@ExchangeRate", SqlDbType.Decimal, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objCIMaster.ExchangeRate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 32, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, _objCIMaster.idx));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@purchaseDate", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objCIMaster.DepartmentID));


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

               
                if (_objCIMaster.idx > 0)
                {
                    if (_objCIMaster.DetailData != null)
                    {
                        foreach (DataRow row in _objCIMaster.DetailData.Rows)
                            // row["purchaseIdx"] = cmdToExecute.Parameters["@ID"].Value.ToString();
                            row["purchaseIdx"] = _objCIMaster.idx;
                        _objCIMaster.DetailData.AcceptChanges();

                        SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);
                        _objCIMaster.DetailData.TableName = "CI_PurchaseDetails";

                        sbc.ColumnMappings.Clear();

                        //foreach(DataRow dr in _objCIMaster.DetailData.Rows)
                        //{
                        //    foreach (DataColumn dc in _objCIMaster.DetailData.Columns)
                        //    {
                        //        sbc.ColumnMappings.Add(dc.ColumnName, dc.ColumnName);
                        //       // nvEmp.Add(dc.ColumnName, dr[dc]);
                        //    }

                        //}



                        sbc.ColumnMappings.Add("purchaseIdx", "purchaseIdx");
                        //sbc.ColumnMappings.Add(2, 1);
                        sbc.ColumnMappings.Add("productTypeIdx", "productTypeIdx");
                        sbc.ColumnMappings.Add("itemIdx", "itemIdx");
                        sbc.ColumnMappings.Add("unitPrice", "unitPrice");
                        sbc.ColumnMappings.Add("qty", "qty");
                        sbc.ColumnMappings.Add("amount", "amount");
                        sbc.ColumnMappings.Add("qty", "openItem");
                        sbc.ColumnMappings.Add("ItemDescription", "ItemDescription");
                        sbc.ColumnMappings.Add("unitPrice", "DVRate");
                        sbc.ColumnMappings.Add("amount", "TDVRate");
                        sbc.ColumnMappings.Add("ADVRate", "ADVRate");

                        sbc.ColumnMappings.Add("ASSVCI", "ASSVCI");
                        sbc.ColumnMappings.Add("Landing", "Landing");
                        sbc.ColumnMappings.Add("CDPercntage", "CDPercntage");

                        sbc.ColumnMappings.Add("RDPercentage", "RDPercentage");
                        sbc.ColumnMappings.Add("ACDPercentage", "ACDPercentage");

                        sbc.ColumnMappings.Add("ASTPercentage", "ASTPercentage");
                        sbc.ColumnMappings.Add("ITPercentage", "ITPercentage");

                        sbc.ColumnMappings.Add("TDTax", "TDTax");
                        sbc.ColumnMappings.Add("CleaningPrice", "CleaningPrice");

                        sbc.ColumnMappings.Add("TotalAmount", "TotalAmount");
                        sbc.ColumnMappings.Add("STPercentage", "STPercentage");

                        sbc.ColumnMappings.Add("TotalASSVSCI", "TotalASSVSCI");
                        sbc.ColumnMappings.Add("TotalLanding", "TotalLanding");
                        sbc.ColumnMappings.Add("TotalCDValue", "TotalCDValue");
                        sbc.ColumnMappings.Add("TotalRDValue", "TotalRDValue");
                        sbc.ColumnMappings.Add("TotalACDValue", "TotalACDValue");
                        sbc.ColumnMappings.Add("TotalASTValue", "TotalASTValue");
                        sbc.ColumnMappings.Add("TotalITValue", "TotalITValue");
                        sbc.ColumnMappings.Add("TotalSTValue", "TotalSTValue");
                        // Added By Ahsan
                        sbc.ColumnMappings.Add("clearingExpensePerProduct", "clearingExpensePerProduct");
                        sbc.ColumnMappings.Add("pricePerProduct", "pricePerProduct");


                        sbc.DestinationTableName = _objCIMaster.DetailData.TableName;
                        sbc.WriteToServer(_objCIMaster.DetailData);

                    }
                    int GLIDX = (Int32)cmdToExecute.Parameters["@masterIdx"].Value;
                    // AccountGJ insert
                    if (_objCIMaster.DetailData != null)
                    {
                        DataTable dt = new DataTable();
                        dt = _objCIMaster.DetailData;
                        int count = _objCIMaster.DetailData.Rows.Count;
                        int customerIdx, coaIdx;
                        string invoiceNo;
                        decimal Price, TotalPrice, credit, debit;
                        int vendorIdx, vendor;
                        for (int i = 0; i < count; i++)
                        {
                            decimal.TryParse(dt.Rows[i]["ADVRate"].ToString(), out Price); //paidAmount
                            decimal.TryParse(dt.Rows[i]["TDTax"].ToString(), out TotalPrice); //BalanceAmount
                            //int.TryParse(dt.Rows[i]["gridVendorIdx"].ToString(), out vendor);
                            credit = Price;
                            debit = TotalPrice;
                            // vendorIdx = vendor;

                            //int GLIDX = (Int32)cmdToExecute.Parameters["@glIdx"].Value;
                            //purchase entry for account gj same for all types
                            cmdToExecute = new SqlCommand();
                            // cmdToExecute.CommandType = CommandType.StoredProcedure;
                            cmdToExecute.CommandType = CommandType.StoredProcedure;
                            cmdToExecute.CommandText = "sp_CIPOInsertAccountGj";
                            cmdToExecute.Connection = _mainConnection;
                            cmdToExecute.Parameters.Add(new SqlParameter("@GLIdx", SqlDbType.Int, 50,
                                ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, GLIDX));
                            cmdToExecute.Parameters.Add(new SqlParameter("@TransTypeIdx", SqlDbType.Int, 500,
                                ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed,
                                1)); //Receipt Voucher Trasaction Type

                            cmdToExecute.Parameters.Add(new SqlParameter("@useridx", SqlDbType.Int, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                                _objCIMaster.createdByUserIdx));

                            cmdToExecute.Parameters.Add(new SqlParameter("@vendoridx", SqlDbType.Int, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                            cmdToExecute.Parameters.Add(new SqlParameter("@employeeidx", SqlDbType.Int, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                            cmdToExecute.Parameters.Add(new SqlParameter("@customeridx", SqlDbType.Int, 25,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                            cmdToExecute.Parameters.Add(new SqlParameter("@coaidx", SqlDbType.Int, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 89)); //Sales
                            cmdToExecute.Parameters.Add(new SqlParameter("@invoiceidx", SqlDbType.NVarChar, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objCIMaster.poNumber));

                            cmdToExecute.Parameters.Add(new SqlParameter("@debit", SqlDbType.Decimal, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, debit));

                            cmdToExecute.Parameters.Add(new SqlParameter("@credit", SqlDbType.Decimal, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, credit));
                            cmdToExecute.Parameters.Add(new SqlParameter("@creationDate", SqlDbType.Date, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                                _objCIMaster.creationDate));
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
                    ID = (Int32)cmdToExecute.Parameters["@ID"].Value;
                    if (_objCIMaster.DetailData != null)
                    {
                        foreach (DataRow row in _objCIMaster.DetailData.Rows)
                            row["purchaseIdx"] = cmdToExecute.Parameters["@ID"].Value.ToString();

                        _objCIMaster.DetailData.AcceptChanges();

                        SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);
                        _objCIMaster.DetailData.TableName = "CI_PurchaseDetails";

                        sbc.ColumnMappings.Clear();

                        //foreach(DataRow dr in _objCIMaster.DetailData.Rows)
                        //{
                        //    foreach (DataColumn dc in _objCIMaster.DetailData.Columns)
                        //    {
                        //        sbc.ColumnMappings.Add(dc.ColumnName, dc.ColumnName);
                        //       // nvEmp.Add(dc.ColumnName, dr[dc]);
                        //    }

                        //}



                        sbc.ColumnMappings.Add("purchaseIdx", "purchaseIdx");
                        sbc.ColumnMappings.Add("vendorIdx", "vendorIdx");
                        sbc.ColumnMappings.Add("coaIdx", "coaIdx");
                        sbc.ColumnMappings.Add("amount", "amount");


                        sbc.DestinationTableName = _objCIMaster.DetailData.TableName;
                        sbc.WriteToServer(_objCIMaster.DetailData);

                    }

                    // AccountGJ insert
                    if (_objCIMaster.DetailData != null)
                    {
                        DataTable dt = new DataTable();
                        dt = _objCIMaster.DetailData;
                        int count = _objCIMaster.DetailData.Rows.Count;
                        int customerIdx, coaIdx;
                        string invoiceNo;
                        decimal Price, TotalPrice, credit, debit;
                        int vendorIdx, vendor;
                        for (int i = 0; i < count; i++)
                        {
                            decimal.TryParse(dt.Rows[i]["amount"].ToString(), out Price); //paidAmount
                            decimal.TryParse(dt.Rows[i]["amount"].ToString(), out TotalPrice); //BalanceAmount
                            //int.TryParse(dt.Rows[i]["gridVendorIdx"].ToString(), out vendor);
                            credit = Price;
                            debit = TotalPrice;
                            // vendorIdx = vendor;

                            //int GLIDX = (Int32)cmdToExecute.Parameters["@glIdx"].Value;
                            //purchase entry for account gj same for all types
                            cmdToExecute = new SqlCommand();
                            // cmdToExecute.CommandType = CommandType.StoredProcedure;
                            cmdToExecute.CommandType = CommandType.StoredProcedure;
                            cmdToExecute.CommandText = "sp_CIPOInsertAccountGj";
                            cmdToExecute.Connection = _mainConnection;
                            cmdToExecute.Parameters.Add(new SqlParameter("@GLIdx", SqlDbType.Int, 50,
                                ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, GLIDX));
                            cmdToExecute.Parameters.Add(new SqlParameter("@TransTypeIdx", SqlDbType.Int, 500,
                                ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed,
                                1)); //Receipt Voucher Trasaction Type

                            cmdToExecute.Parameters.Add(new SqlParameter("@useridx", SqlDbType.Int, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                                _objCIMaster.createdByUserIdx));

                            cmdToExecute.Parameters.Add(new SqlParameter("@vendoridx", SqlDbType.Int, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                            cmdToExecute.Parameters.Add(new SqlParameter("@employeeidx", SqlDbType.Int, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                            cmdToExecute.Parameters.Add(new SqlParameter("@customeridx", SqlDbType.Int, 25,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                            cmdToExecute.Parameters.Add(new SqlParameter("@coaidx", SqlDbType.Int, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 89)); //Sales
                            cmdToExecute.Parameters.Add(new SqlParameter("@invoiceidx", SqlDbType.NVarChar, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objCIMaster.poNumber));

                            cmdToExecute.Parameters.Add(new SqlParameter("@debit", SqlDbType.Decimal, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, debit));

                            cmdToExecute.Parameters.Add(new SqlParameter("@credit", SqlDbType.Decimal, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, credit));
                            cmdToExecute.Parameters.Add(new SqlParameter("@creationDate", SqlDbType.Date, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                                _objCIMaster.creationDate));
                            cmdToExecute.Parameters.Add(new SqlParameter("@modifiedDate", SqlDbType.Date, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                            cmdToExecute.Parameters.Add(new SqlParameter("@DueDate", SqlDbType.Date, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));

                            cmdToExecute.Transaction = this.Transaction;
                            _rowsAffected = cmdToExecute.ExecuteNonQuery();
                        }

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


        public DataTable SelectAllCIPO()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetAllCI_PurchaseOrder]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Banks");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@ProductCode", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Product_Code));
                // cmdToExecute.Parameters.Add(new SqlParameter("@ProductName", SqlDbType.VarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjProductSetupProperty.Product_Name));
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

        public DataTable SelectCIBYID(int id)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_SelctCIByid]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("CI Setup");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@pid", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, id));

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
        #endregion



        #region Consignment


        public bool InsertConsigment()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            if (_objConsigmnetProperty.idx > 0)
            {
                //sp_PurchaseUpdate
                cmdToExecute.CommandText = "dbo.[sp_PurchaseUpdate]";
            }
            else
            {
                cmdToExecute.CommandText = "dbo.[sp_Insert_Consignment]";
            }

            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                if (_objConsigmnetProperty.idx > 0)
                {
                    cmdToExecute.Parameters.Add(new SqlParameter("@poNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objCIMaster.poNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@PINO", SqlDbType.Int, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objCIMaster.PINO));
                    cmdToExecute.Parameters.Add(new SqlParameter("@purchaseDate", SqlDbType.DateTime, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objCIMaster.purchaseDate));

                    cmdToExecute.Parameters.Add(new SqlParameter("@description", SqlDbType.NVarChar, 80, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objCIMaster.description));
                    cmdToExecute.Parameters.Add(new SqlParameter("@totalamount", SqlDbType.Decimal, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objCIMaster.totalAmount));

                    cmdToExecute.Parameters.Add(new SqlParameter("@creationdate", SqlDbType.DateTime, 50, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objCIMaster.creationDate));

                    cmdToExecute.Parameters.Add(new SqlParameter("@createdbyuser", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objCIMaster.createdByUserIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@visible", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objCIMaster.visible));
                    cmdToExecute.Parameters.Add(new SqlParameter("@status", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objCIMaster.status));


                    cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 32, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, _objCIMaster.idx));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@purchaseDate", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objCIMaster.DepartmentID));

                }
                else
                {
                    cmdToExecute.Parameters.Add(new SqlParameter("@InvoiceNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objConsigmnetProperty.InvoiceNo));
                    cmdToExecute.Parameters.Add(new SqlParameter("@ParentDocumentId", SqlDbType.Int, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objConsigmnetProperty.ParentDocumentId));
                    cmdToExecute.Parameters.Add(new SqlParameter("@Invoicedate", SqlDbType.DateTime, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objConsigmnetProperty.Invoicedate));

                    cmdToExecute.Parameters.Add(new SqlParameter("@Reference", SqlDbType.NVarChar, 80, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objConsigmnetProperty.Reference));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@totalamount", SqlDbType.Decimal, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objConsigmnetProperty.totalAmount));

                    cmdToExecute.Parameters.Add(new SqlParameter("@creationdate", SqlDbType.DateTime, 50, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objConsigmnetProperty.creationDate));

                    cmdToExecute.Parameters.Add(new SqlParameter("@createdByUserIdx", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objConsigmnetProperty.createdByUserIdx));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@visible", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objConsigmnetProperty.visible));
                    cmdToExecute.Parameters.Add(new SqlParameter("@status", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objConsigmnetProperty.status));


                    cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 32, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, _objConsigmnetProperty.idx));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@purchaseDate", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objConsigmnetProperty.DepartmentID));


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


               

                for(int i=0;i< _objConsigmnetProperty.CIPODetails.Rows.Count; i++)
                {
                    cmdToExecute = new SqlCommand();
                    cmdToExecute.CommandText = "dbo.[sp_Update_Percentage]";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.Parameters.Add(new SqlParameter("@itemid", SqlDbType.Int, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objConsigmnetProperty.CIPODetails.Rows[i]["itemidx"]));
                    cmdToExecute.Parameters.Add(new SqlParameter("@percentage", SqlDbType.Decimal, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objConsigmnetProperty.DetailData.Rows[0]["CalculatedPercentage"]));
                    cmdToExecute.Parameters.Add(new SqlParameter("@cleaningexpence", SqlDbType.Decimal, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objConsigmnetProperty.CIPODetails.Rows[i]["CleaningPrice"]));
                    cmdToExecute.Parameters.Add(new SqlParameter("@price", SqlDbType.Decimal, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objConsigmnetProperty.CIPODetails.Rows[i]["TotalAmount"]));
                    cmdToExecute.Parameters.Add(new SqlParameter("@purchaseidx", SqlDbType.Int, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objConsigmnetProperty.CIPODetails.Rows[i]["purchaseIdx"]));
                    cmdToExecute.Transaction = this.Transaction;
                    // Execute query.
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                }


                // _iD = (Int32)cmdToExecute.Parameters["@iID"].Value;
                //_errorCode = cmdToExecute.Parameters["@ErrorCode"].Value;

                if (_objConsigmnetProperty.DetailData != null)
                {
                    foreach (DataRow row in _objConsigmnetProperty.DetailData.Rows)
                    {
                        row["ParentDocumentId"] = cmdToExecute.Parameters["@ID"].Value.ToString();
                        row["creationDate"] = DateTime.Now;
                        row["lastModificationDate"] = DateTime.Now;
                    }
                    _objConsigmnetProperty.DetailData.AcceptChanges();

                    SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);
                    _objConsigmnetProperty.DetailData.TableName = "consigmentdetails";

                    sbc.ColumnMappings.Clear();

                    
                    foreach (DataColumn dc in _objConsigmnetProperty.DetailData.Columns)
                    {
                        sbc.ColumnMappings.Add(dc.ColumnName, dc.ColumnName);
                        
                    }

                    
                    sbc.DestinationTableName = _objConsigmnetProperty.DetailData.TableName;
                    sbc.WriteToServer(_objConsigmnetProperty.DetailData);

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


        #endregion
    }
}
