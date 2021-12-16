using SNDDAL;
using SSS.Property.Setups;
using SSS.Property.Transactions;
using SSS.Property.Transactions.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SSS.DAL.Transactions
{
    public class LP_SalesOrder_DAL: DBInteractionBase
    {
        private LP_SalesOrder_Master_Property _objSOMasterProperty;
        private LP_SalesOrder_Detail_Property _objSODetailProperty;

        public LP_SalesOrder_DAL()
        {

        }
        public LP_SalesOrder_DAL(int id)
        {

        }
        public LP_SalesOrder_DAL(LP_SalesOrder_Master_Property objSOMasterProperty)
        {
            _objSOMasterProperty = objSOMasterProperty;
        }
        public LP_SalesOrder_DAL(LP_SalesOrder_Detail_Property objSODetailProperty)
        {
            _objSODetailProperty = objSODetailProperty;
        }
        public bool ProcessSalesInvoice()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_ProcessSalesInvoice]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@salesIdx", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.idx));
                //cmdToExecute.Parameters.Add(new SqlParameter("@ParentDocId", SqlDbType.Int, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objGrnMasterProperty.Parent_DocID));

                //cmdToExecute.Parameters.Add(new SqlParameter("@Narration", SqlDbType.NVarChar, 80, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objGrnMasterProperty.Narration));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Totalamount", SqlDbType.Decimal, 14, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objGrnMasterProperty.Total_Amount));
                //cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 9, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objGrnMasterProperty.Status));
                //cmdToExecute.Parameters.Add(new SqlParameter("@DateCreated", SqlDbType.DateTime, 50, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objGrnMasterProperty.Date_Created));

                //cmdToExecute.Parameters.Add(new SqlParameter("@userid", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objGrnMasterProperty.User_ID));
                ////cmdToExecute.Parameters.Add(new SqlParameter("@visible", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objGrnMasterProperty.visible));

                ////cmdToExecute.Parameters.Add(new SqlParameter("@NetAmount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.NetAmount));
                ////cmdToExecute.Parameters.Add(new SqlParameter("@DeliveryDate", SqlDbType.DateTime, 50, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.DeliveryDate));
                ////cmdToExecute.Parameters.Add(new SqlParameter("@Reference", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.Reference));
                ////cmdToExecute.Parameters.Add(new SqlParameter("@DocumentType", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.DocumentType));
                ////cmdToExecute.Parameters.Add(new SqlParameter("@IsActive", SqlDbType.Bit, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.IsActive));
                //////cmdToExecute.Parameters.Add(new SqlParameter("Ref_Document1", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Ref_Document1));
                //////cmdToExecute.Parameters.Add(new SqlParameter("Processed", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Processed));
                //////cmdToExecute.Parameters.Add(new SqlParameter("Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Status));
                //////cmdToExecute.Parameters.Add(new SqlParameter("Pos_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Pos_ID));
                //////cmdToExecute.Parameters.Add(new SqlParameter("PersonnelRef_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.PersonnelRef_ID));
                //////cmdToExecute.Parameters.Add(new SqlParameter("Prp_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Prp_ID));
                //////cmdToExecute.Parameters.Add(new SqlParameter("DeliveryDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.DeliveryDate));
                //////cmdToExecute.Parameters.Add(new SqlParameter("Route_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Route_ID));
                //////cmdToExecute.Parameters.Add(new SqlParameter("Transactionid", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.ID));

                //cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 32, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, objGrnMasterProperty.ID));
                //////cmdToExecute.Parameters.Add(new SqlParameter("ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                //////cmdToExecute.Parameters.Add(new SqlParameter("Record_Table_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Record_Table_Name));
                //////cmdToExecute.Parameters.Add(new SqlParameter("Operation", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Operation));
                //////cmdToExecute.Parameters.Add(new SqlParameter("Operated_By", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Operated_By));
                //////cmdToExecute.Parameters.Add(new SqlParameter("Operation_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Operation_Date));


                if (_mainConnectionIsCreatedLocal)
                {
                    // Open connection.
                    //   _mainConnection.Open();
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

                if (_objSOMasterProperty.DetailData != null)
                {
                    //foreach (DataRow row in objGrnMasterProperty.DetailData.Rows)
                    //    row["GRN_MasterId"] = cmdToExecute.Parameters["@ID"].Value.ToString();

                    //objGrnMasterProperty.DetailData.AcceptChanges();

                    //SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);
                    //objGrnMasterProperty.DetailData.TableName = "GRN_Detail";

                    //sbc.ColumnMappings.Clear();
                    //sbc.ColumnMappings.Add("GRN_MasterId", "GRN_MasterId");
                    ////sbc.ColumnMappings.Add(2, 1);
                    //sbc.ColumnMappings.Add("Product_Id", "Product_Id");
                    //sbc.ColumnMappings.Add("Quantity", "Quantity");
                    //sbc.ColumnMappings.Add("TotalAmount", "TotalAmount");
                    //sbc.ColumnMappings.Add("Rate", "Rate");
                    //sbc.ColumnMappings.Add("amount", "amount");
                    //sbc.ColumnMappings.Add("qty", "openItem");
                    //sbc.ColumnMappings.Add("Product_Code", "Product_Code");
                    //sbc.ColumnMappings.Add("Product", "Product_Name");
                    //sbc.ColumnMappings.Add("Status", "Status");

                    //sbc.ColumnMappings.Add("Department_Id", "Department_Id");
                    //sbc.ColumnMappings.Add("Description", "Description");

                    //sbc.DestinationTableName = objGrnMasterProperty.DetailData.TableName;
                    // sbc.WriteToServer(objGrnMasterProperty.DetailData);

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
            if (_objSOMasterProperty.idx > 0)
            {
                //sp_PurchaseUpdate
                cmdToExecute.CommandText = "dbo.[sp_SalesOrderUpdate]";
            }
            else
            {
                cmdToExecute.CommandText = "dbo.[sp_SalesOrderInsert]";
            }

            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                if (_objSOMasterProperty.idx > 0)
                {
                   //cmdToExecute.Parameters.Add(new SqlParameter("@DriverName", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.DriverName));
                   //cmdToExecute.Parameters.Add(new SqlParameter("@DriverCnic", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.DriverCnic));

                    cmdToExecute.Parameters.Add(new SqlParameter("@soNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.soNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@customerIdx", SqlDbType.Int, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.customerIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@description", SqlDbType.NVarChar, 80, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.description));
                    cmdToExecute.Parameters.Add(new SqlParameter("@paidAmount", SqlDbType.Decimal, 500, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.paidAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@balanceAmount", SqlDbType.Decimal, 500, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.balanceAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@totalamount", SqlDbType.Decimal, 500, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.totalAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@netAmount", SqlDbType.Decimal, 500, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.netAmount));

                    cmdToExecute.Parameters.Add(new SqlParameter("@creationdate", SqlDbType.DateTime, 50, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objSOMasterProperty.creationDate));

                    cmdToExecute.Parameters.Add(new SqlParameter("@createdbyuser", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.createdByUserIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@visible", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objSOMasterProperty.visible));
                    cmdToExecute.Parameters.Add(new SqlParameter("@status", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objSOMasterProperty.status));


                    cmdToExecute.Parameters.Add(new SqlParameter("@salesOrderDate", SqlDbType.DateTime, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.salesorderDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@DeliveryDate", SqlDbType.DateTime, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.DeliveryDate));
                    //wareHouseIdx,salespersonIdx,shippingCost,discount,taxAount,paymentModeIdx,bankIdx,accorChequeNumber

                    cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.idx));
                    // cmdToExecute.Parameters.Add(new SqlParameter("@MRNIdx", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.MRNIdx));
                   cmdToExecute.Parameters.Add(new SqlParameter("@masterIdx", SqlDbType.Int, 32, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.glIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@qsIdx", SqlDbType.Int, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.qsIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@reference", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.reference));
                    cmdToExecute.Parameters.Add(new SqlParameter("@branchIdx", SqlDbType.Int, 500, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.branchIdx));

                    cmdToExecute.Parameters.Add(new SqlParameter("@wareHouseIdx", SqlDbType.Int, 500, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.wareHouseIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@salespersonIdx", SqlDbType.Int, 500, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.salespersonIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@shippingCost", SqlDbType.Decimal, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.shippingCost));
                    cmdToExecute.Parameters.Add(new SqlParameter("@discount", SqlDbType.Decimal, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.discount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@taxAount", SqlDbType.Decimal, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.taxAount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@paymentModeIdx", SqlDbType.Int, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.bankIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bankIdx", SqlDbType.Int, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.discount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@accorChequeNumber", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.accorChequeNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@Productioncheck", SqlDbType.Int, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.Productioncheck));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@salesTypeIdx", SqlDbType.Int, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.salesTypeIdx));
                }
                else
                {
                    //cmdToExecute.Parameters.Add(new SqlParameter("@DriverName", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.DriverName));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@DriverCnic", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.DriverCnic));

                    cmdToExecute.Parameters.Add(new SqlParameter("@soNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.soNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@customerIdx", SqlDbType.Int, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.customerIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@description", SqlDbType.NVarChar, 80, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.description));
                    cmdToExecute.Parameters.Add(new SqlParameter("@paidAmount", SqlDbType.Decimal, 500, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.paidAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@balanceAmount", SqlDbType.Decimal, 500, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.balanceAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@totalamount", SqlDbType.Decimal, 500, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.totalAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@netAmount", SqlDbType.Decimal, 500, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.netAmount));

                    cmdToExecute.Parameters.Add(new SqlParameter("@creationdate", SqlDbType.DateTime, 50, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objSOMasterProperty.creationDate));

                    cmdToExecute.Parameters.Add(new SqlParameter("@createdbyuser", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.createdByUserIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@visible", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objSOMasterProperty.visible));
                    cmdToExecute.Parameters.Add(new SqlParameter("@status", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, _objSOMasterProperty.status));


                    cmdToExecute.Parameters.Add(new SqlParameter("@salesOrderDate", SqlDbType.DateTime, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.salesorderDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@DeliveryDate", SqlDbType.DateTime, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.DeliveryDate)); 
                    //wareHouseIdx,salespersonIdx,shippingCost,discount,taxAount,paymentModeIdx,bankIdx,accorChequeNumber

                    cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 32, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.idx));
                    // cmdToExecute.Parameters.Add(new SqlParameter("@MRNIdx", SqlDbType.Int, 32, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.MRNIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@glIdx", SqlDbType.Int, 32, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.glIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@qsIdx", SqlDbType.Int, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.qsIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@reference", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.reference));
                    cmdToExecute.Parameters.Add(new SqlParameter("@branchIdx", SqlDbType.Int, 500, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.branchIdx));

                    cmdToExecute.Parameters.Add(new SqlParameter("@wareHouseIdx", SqlDbType.Int, 500, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.wareHouseIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@salespersonIdx", SqlDbType.Int, 500, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.salespersonIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@shippingCost", SqlDbType.Decimal, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.shippingCost));
                    cmdToExecute.Parameters.Add(new SqlParameter("@discount", SqlDbType.Decimal, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.discount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@taxAount", SqlDbType.Decimal, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.taxAount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@paymentModeIdx", SqlDbType.Int, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.bankIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bankIdx", SqlDbType.Int, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.discount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@accorChequeNumber", SqlDbType.NVarChar, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.accorChequeNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@Productioncheck", SqlDbType.Int, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.Productioncheck));
                    //cmdToExecute.Parameters.Add(new SqlParameter("@salesTypeIdx", SqlDbType.Int, 500, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.salesTypeIdx));
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


                if (_objSOMasterProperty.idx > 0)
                {
                    if (_objSOMasterProperty.DetailData != null)
                    {
                        foreach (DataRow row in _objSOMasterProperty.DetailData.Rows)
                        {
                            //                            row["salesorderIdx"] = cmdToExecute.Parameters["@ID"].Value.ToString();
                            row["salesorderIdx"] = _objSOMasterProperty.idx;
                            //_objSOMasterProperty.idx = Convert.ToInt32(cmdToExecute.Parameters["@ID"].Value.ToString());
                        }

                        _objSOMasterProperty.DetailData.AcceptChanges();

                        SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default,
                            this.Transaction);
                        _objSOMasterProperty.DetailData.TableName = "SalesOrderDetails";

                        sbc.ColumnMappings.Clear();
                        sbc.ColumnMappings.Add("salesorderIdx", "salesorderIdx");
                        //sbc.ColumnMappings.Add(2, 1);
                        sbc.ColumnMappings.Add("productTypeIdx", "productTypeIdx");
                        sbc.ColumnMappings.Add("itemIdx", "itemIdx");
                        sbc.ColumnMappings.Add("salePrice", "salePrice");
                        sbc.ColumnMappings.Add("qty", "qty");
                        sbc.ColumnMappings.Add("amount", "amount");
                        sbc.ColumnMappings.Add("qty", "openItem");
                        sbc.ColumnMappings.Add("ItemDescription", "ItemDescription");

                        //sbc.ColumnMappings.Add("Product_Code", "Product_Code");
                        //sbc.ColumnMappings.Add("Product", "Product_Name");
                        //sbc.ColumnMappings.Add("Status", "Status");

                        //sbc.ColumnMappings.Add("Department_Id", "Department_Id");


                        sbc.DestinationTableName = _objSOMasterProperty.DetailData.TableName;
                        sbc.WriteToServer(_objSOMasterProperty.DetailData);

                    }

                    #region Commented Taxes
                    //if (_objSOMasterProperty.SalesTaxData != null)
                    //{
                    //    foreach (DataRow row in _objSOMasterProperty.SalesTaxData.Rows)
                    //    {
                    //        row["saleIdx"] = _objSOMasterProperty.idx;
                    //        row["taxType"] = "1";
                    //        row["creationDate"] = DateTime.Now.ToString("yyyy-MM-dd");

                    //        //row["createdBy"] = Convert.ToInt16(Session["UID"].ToString());
                    //    }

                    //    _objSOMasterProperty.SalesTaxData.AcceptChanges();

                    //    SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default,
                    //        this.Transaction);
                    //    _objSOMasterProperty.SalesTaxData.TableName = "salesTaxes";

                    //    sbc.ColumnMappings.Clear();
                    //    sbc.ColumnMappings.Add("taxIdx", "taxIdx");
                    //    sbc.ColumnMappings.Add("taxPercent", "taxPercent");
                    //    sbc.ColumnMappings.Add("status", "status");
                    //    sbc.ColumnMappings.Add("creationDate", "creationDate");
                    //    //sbc.ColumnMappings.Add(2, 1);
                    //    sbc.ColumnMappings.Add("saleIdx", "saleIdx");
                    //    sbc.ColumnMappings.Add("taxType", "taxType");
                    //    sbc.DestinationTableName = _objSOMasterProperty.SalesTaxData.TableName;
                    //    sbc.WriteToServer(_objSOMasterProperty.SalesTaxData);

                    //}
                    
                    #endregion


                    int GLIDX = (Int32)cmdToExecute.Parameters["@masterIdx"].Value;
                   // int GLIDX = _objSOMasterProperty.glIdx;
                    //purchase entry for account gj same for all types
                    cmdToExecute = new SqlCommand();
                    // cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.CommandText = "sp_InsertSIAccountGj";
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.Parameters.Add(new SqlParameter("@GLIdx", SqlDbType.Int, 50, ParameterDirection.Input,
                        true, 10, 0, "", DataRowVersion.Proposed, GLIDX));
                    cmdToExecute.Parameters.Add(new SqlParameter("@TransTypeIdx", SqlDbType.Int, 500,
                        ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 2));

                    cmdToExecute.Parameters.Add(new SqlParameter("@useridx", SqlDbType.Int, 500,
                        ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                        _objSOMasterProperty.createdByUserIdx));

                    cmdToExecute.Parameters.Add(new SqlParameter("@vendoridx", SqlDbType.Int, 500,
                        ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                    cmdToExecute.Parameters.Add(new SqlParameter("@employeeidx", SqlDbType.Int, 500,
                        ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                    cmdToExecute.Parameters.Add(new SqlParameter("@customeridx", SqlDbType.Int, 25,
                        ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                        _objSOMasterProperty.customerIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@coaidx", SqlDbType.Int, 500,
                        ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 6)); //Sales
                    cmdToExecute.Parameters.Add(new SqlParameter("@invoiceidx", SqlDbType.NVarChar, 500,
                        ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                        _objSOMasterProperty.soNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@debit", SqlDbType.Decimal, 500,
                        ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 0.00m));
                    cmdToExecute.Parameters.Add(new SqlParameter("@credit", SqlDbType.Decimal, 500,
                        ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                        _objSOMasterProperty.netAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@creationDate", SqlDbType.Date, 500,
                        ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                        _objSOMasterProperty.creationDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@modifiedDate", SqlDbType.Date, 500,
                        ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                    cmdToExecute.Parameters.Add(new SqlParameter("@DueDate", SqlDbType.Date, 500,
                        ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));

                    cmdToExecute.Transaction = this.Transaction;
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();

                    if (_objSOMasterProperty.shippingCost > 0)
                    {
                        //int GLIDX = (Int32)cmdToExecute.Parameters["@glIdx"].Value;
                        //purchase entry for account gj same for all types
                        cmdToExecute = new SqlCommand();
                        // cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.CommandText = "sp_InsertSIAccountGj";
                        cmdToExecute.Connection = _mainConnection;
                        cmdToExecute.Parameters.Add(new SqlParameter("@GLIdx", SqlDbType.Int, 50,
                            ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, GLIDX));
                        cmdToExecute.Parameters.Add(new SqlParameter("@TransTypeIdx", SqlDbType.Int, 500,
                            ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 2));

                        cmdToExecute.Parameters.Add(new SqlParameter("@useridx", SqlDbType.Int, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                            _objSOMasterProperty.createdByUserIdx));

                        cmdToExecute.Parameters.Add(new SqlParameter("@vendoridx", SqlDbType.Int, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        cmdToExecute.Parameters.Add(new SqlParameter("@employeeidx", SqlDbType.Int, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        cmdToExecute.Parameters.Add(new SqlParameter("@customeridx", SqlDbType.Int, 25,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                            _objSOMasterProperty.customerIdx));
                        cmdToExecute.Parameters.Add(new SqlParameter("@coaidx", SqlDbType.Int, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 8)); //Shipping Cost
                        cmdToExecute.Parameters.Add(new SqlParameter("@invoiceidx", SqlDbType.NVarChar, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                            _objSOMasterProperty.soNumber));
                        cmdToExecute.Parameters.Add(new SqlParameter("@debit", SqlDbType.Decimal, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                            _objSOMasterProperty.shippingCost));
                        cmdToExecute.Parameters.Add(new SqlParameter("@credit", SqlDbType.Decimal, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 0.00m));
                        cmdToExecute.Parameters.Add(new SqlParameter("@creationDate", SqlDbType.Date, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                            _objSOMasterProperty.creationDate));
                        cmdToExecute.Parameters.Add(new SqlParameter("@modifiedDate", SqlDbType.Date, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        cmdToExecute.Parameters.Add(new SqlParameter("@DueDate", SqlDbType.Date, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));

                        cmdToExecute.Transaction = this.Transaction;
                        _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    }

                    if (_objSOMasterProperty.discount > 0)
                    {
                        //int GLIDX = (Int32)cmdToExecute.Parameters["@glIdx"].Value;
                        //purchase entry for account gj same for all types
                        cmdToExecute = new SqlCommand();
                        // cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.CommandText = "sp_InsertSIAccountGj";
                        cmdToExecute.Connection = _mainConnection;
                        cmdToExecute.Parameters.Add(new SqlParameter("@GLIdx", SqlDbType.Int, 50,
                            ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, GLIDX));
                        cmdToExecute.Parameters.Add(new SqlParameter("@TransTypeIdx", SqlDbType.Int, 500,
                            ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 2));

                        cmdToExecute.Parameters.Add(new SqlParameter("@useridx", SqlDbType.Int, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                            _objSOMasterProperty.createdByUserIdx));

                        cmdToExecute.Parameters.Add(new SqlParameter("@vendoridx", SqlDbType.Int, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        cmdToExecute.Parameters.Add(new SqlParameter("@employeeidx", SqlDbType.Int, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        cmdToExecute.Parameters.Add(new SqlParameter("@customeridx", SqlDbType.Int, 25,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                            _objSOMasterProperty.customerIdx));
                        cmdToExecute.Parameters.Add(new SqlParameter("@coaidx", SqlDbType.Int, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 9)); //Discount
                        cmdToExecute.Parameters.Add(new SqlParameter("@invoiceidx", SqlDbType.NVarChar, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                            _objSOMasterProperty.soNumber));
                        cmdToExecute.Parameters.Add(new SqlParameter("@debit", SqlDbType.Decimal, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                            _objSOMasterProperty.discount));
                        cmdToExecute.Parameters.Add(new SqlParameter("@credit", SqlDbType.Decimal, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 0.00m));
                        cmdToExecute.Parameters.Add(new SqlParameter("@creationDate", SqlDbType.Date, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                            _objSOMasterProperty.creationDate));
                        cmdToExecute.Parameters.Add(new SqlParameter("@modifiedDate", SqlDbType.Date, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        cmdToExecute.Parameters.Add(new SqlParameter("@DueDate", SqlDbType.Date, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));

                        cmdToExecute.Transaction = this.Transaction;
                        _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    }
                    //purchase end

                    //TAX entries

                    #region Account Gj Tax Entries

                    //if (_objSOMasterProperty.SalesTaxData != null)
                    //{
                    //    for (int i = 0; i < _objSOMasterProperty.SalesTaxData.Rows.Count; i++)
                    //    {

                    //        decimal taxpercntage =
                    //            Convert.ToDecimal(_objSOMasterProperty.SalesTaxData.Rows[i]["taxPercent"].ToString());
                    //        int taxid = Convert.ToInt32(_objSOMasterProperty.SalesTaxData.Rows[i]["taxIdx"].ToString());
                    //        decimal taxamount = ((_objSOMasterProperty.netAmount / 100) * (taxpercntage));
                    //        cmdToExecute = new SqlCommand();
                    //        // cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //        cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //        cmdToExecute.CommandText = "sp_InsertSIAccountGj";
                    //        cmdToExecute.Connection = _mainConnection;
                    //        cmdToExecute.Parameters.Add(new SqlParameter("@GLIdx", SqlDbType.Int, 50,
                    //            ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, GLIDX));
                    //        cmdToExecute.Parameters.Add(new SqlParameter("@TransTypeIdx", SqlDbType.Int, 500,
                    //            ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 112));

                    //        cmdToExecute.Parameters.Add(new SqlParameter("@useridx", SqlDbType.Int, 500,
                    //            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                    //            _objSOMasterProperty.createdByUserIdx));

                    //        cmdToExecute.Parameters.Add(new SqlParameter("@customeridx", SqlDbType.Int, 500,
                    //            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                    //            _objSOMasterProperty.customerIdx));
                    //        cmdToExecute.Parameters.Add(new SqlParameter("@employeeidx", SqlDbType.Int, 500,
                    //            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                    //        cmdToExecute.Parameters.Add(new SqlParameter("@vendoridx", SqlDbType.Int, 25,
                    //            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                    //        cmdToExecute.Parameters.Add(new SqlParameter("@coaidx", SqlDbType.Int, 500,
                    //            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, taxid));
                    //        cmdToExecute.Parameters.Add(new SqlParameter("@invoiceidx", SqlDbType.NVarChar, 500,
                    //            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                    //            _objSOMasterProperty.soNumber));
                    //        cmdToExecute.Parameters.Add(new SqlParameter("@debit", SqlDbType.Decimal, 500,
                    //            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 0.00m));
                    //        cmdToExecute.Parameters.Add(new SqlParameter("@credit", SqlDbType.Decimal, 500,
                    //            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, taxamount));
                    //        cmdToExecute.Parameters.Add(new SqlParameter("@creationDate", SqlDbType.Date, 500,
                    //            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                    //            _objSOMasterProperty.creationDate));
                    //        cmdToExecute.Parameters.Add(new SqlParameter("@modifiedDate", SqlDbType.Date, 500,
                    //            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                    //        cmdToExecute.Parameters.Add(new SqlParameter("@DueDate", SqlDbType.Date, 500,
                    //            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));

                    //        cmdToExecute.Transaction = this.Transaction;
                    //        _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    //    }
                    //}

                    #endregion

                    #region Full Payment

                    if (_objSOMasterProperty.balanceAmount == 0)
                    {

                        //cash entry bank
                        cmdToExecute = new SqlCommand();
                        // cmdToExecute.CommandType = CommandType.StoredProcedure;

                        cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.CommandText = "sp_InsertSIAccountGj";

                        cmdToExecute.Connection = _mainConnection;
                        cmdToExecute.Parameters.Add(new SqlParameter("@GLIdx", SqlDbType.Int, 50,
                            ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, GLIDX));
                        cmdToExecute.Parameters.Add(new SqlParameter("@TransTypeIdx", SqlDbType.Int, 500,
                            ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 2));

                        cmdToExecute.Parameters.Add(new SqlParameter("@useridx", SqlDbType.Int, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                            _objSOMasterProperty.createdByUserIdx));

                        cmdToExecute.Parameters.Add(new SqlParameter("@customeridx", SqlDbType.Int, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                            _objSOMasterProperty.customerIdx));
                        cmdToExecute.Parameters.Add(new SqlParameter("@employeeidx", SqlDbType.Int, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        cmdToExecute.Parameters.Add(new SqlParameter("@vendoridx", SqlDbType.Int, 25,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));

                        cmdToExecute.Parameters.Add(new SqlParameter("@invoiceidx", SqlDbType.NVarChar, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                            _objSOMasterProperty.soNumber));
                        cmdToExecute.Parameters.Add(new SqlParameter("@debit", SqlDbType.Decimal, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                            _objSOMasterProperty.paidAmount));
                        cmdToExecute.Parameters.Add(new SqlParameter("@credit", SqlDbType.Decimal, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 0.00m));
                        cmdToExecute.Parameters.Add(new SqlParameter("@creationDate", SqlDbType.Date, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                            _objSOMasterProperty.creationDate));
                        cmdToExecute.Parameters.Add(new SqlParameter("@modifiedDate", SqlDbType.Date, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        cmdToExecute.Parameters.Add(new SqlParameter("@DueDate", SqlDbType.Date, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        //cmdToExecute.Parameters.Add(new SqlParameter("@credit", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objMRMasterProperty.isPaid));
                        if (_objSOMasterProperty.paymentModeIdx == 1)
                        {
                            //cash
                            cmdToExecute.Parameters.Add(new SqlParameter("@coaidx", SqlDbType.Int, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 7));
                        }

                        if (_objSOMasterProperty.paymentModeIdx == 2 || _objSOMasterProperty.paymentModeIdx == 3)
                        {
                            //bank
                            // var data= _objpinvoicepropert
                            cmdToExecute.Parameters.Add(new SqlParameter("@coaidx", SqlDbType.Int, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                                _objSOMasterProperty.BankCOAIDX));
                        }

                        if (_objSOMasterProperty.paymentModeIdx == 4)
                        {
                            //cash
                            cmdToExecute.Parameters.Add(new SqlParameter("@coaidx", SqlDbType.Int, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                                55)); //Customer Payment
                        }

                        cmdToExecute.Transaction = this.Transaction;
                        //this.StartTransaction();
                        // cmdToExecute.Transaction = this.Transaction;
                        // Execute query.
                        _rowsAffected = cmdToExecute.ExecuteNonQuery();

                        //cash end


                    }


                    #endregion


                    #region partial Payment

                    if (_objSOMasterProperty.paidAmount != _objSOMasterProperty.totalAmount)
                    {

                        //cash entry bank
                        cmdToExecute = new SqlCommand();
                        // cmdToExecute.CommandType = CommandType.StoredProcedure;

                        cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.CommandText = "sp_InsertSIAccountGj";

                        cmdToExecute.Connection = _mainConnection;
                        cmdToExecute.Parameters.Add(new SqlParameter("@GLIdx", SqlDbType.Int, 50,
                            ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, GLIDX));
                        cmdToExecute.Parameters.Add(new SqlParameter("@TransTypeIdx", SqlDbType.Int, 500,
                            ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 2));

                        cmdToExecute.Parameters.Add(new SqlParameter("@useridx", SqlDbType.Int, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                            _objSOMasterProperty.createdByUserIdx));

                        cmdToExecute.Parameters.Add(new SqlParameter("@customeridx", SqlDbType.Int, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                            _objSOMasterProperty.customerIdx));
                        cmdToExecute.Parameters.Add(new SqlParameter("@employeeidx", SqlDbType.Int, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        cmdToExecute.Parameters.Add(new SqlParameter("@vendoridx", SqlDbType.Int, 25,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));

                        cmdToExecute.Parameters.Add(new SqlParameter("@invoiceidx", SqlDbType.NVarChar, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                            _objSOMasterProperty.soNumber));
                        cmdToExecute.Parameters.Add(new SqlParameter("@debit", SqlDbType.Decimal, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                            _objSOMasterProperty.paidAmount));
                        cmdToExecute.Parameters.Add(new SqlParameter("@credit", SqlDbType.Decimal, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 0.00m));
                        cmdToExecute.Parameters.Add(new SqlParameter("@creationDate", SqlDbType.Date, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                            _objSOMasterProperty.creationDate));
                        cmdToExecute.Parameters.Add(new SqlParameter("@modifiedDate", SqlDbType.Date, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        cmdToExecute.Parameters.Add(new SqlParameter("@DueDate", SqlDbType.Date, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        //cmdToExecute.Parameters.Add(new SqlParameter("@credit", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objMRMasterProperty.isPaid));
                        if (_objSOMasterProperty.paymentModeIdx == 1)
                        {
                            //cash
                            cmdToExecute.Parameters.Add(new SqlParameter("@coaidx", SqlDbType.Int, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 7));
                        }

                        if (_objSOMasterProperty.paymentModeIdx == 2 || _objSOMasterProperty.paymentModeIdx == 3)
                        {
                            //bank
                            // var data= _objpinvoicepropert
                            cmdToExecute.Parameters.Add(new SqlParameter("@coaidx", SqlDbType.Int, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                                _objSOMasterProperty.BankCOAIDX));
                        }

                        if (_objSOMasterProperty.paymentModeIdx == 4)
                        {
                            //cash
                            cmdToExecute.Parameters.Add(new SqlParameter("@coaidx", SqlDbType.Int, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                                55)); //Customer Payment
                        }

                        cmdToExecute.Transaction = this.Transaction;
                        _rowsAffected = cmdToExecute.ExecuteNonQuery();


                        //acount receivable
                        cmdToExecute = new SqlCommand();
                        cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.CommandText = "sp_InsertSIAccountGj";
                        cmdToExecute.Connection = _mainConnection;
                        cmdToExecute.Parameters.Add(new SqlParameter("@GLIdx", SqlDbType.Int, 50,
                            ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, GLIDX));
                        cmdToExecute.Parameters.Add(new SqlParameter("@TransTypeIdx", SqlDbType.Int, 500,
                            ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 2));
                        cmdToExecute.Parameters.Add(new SqlParameter("@useridx", SqlDbType.Int, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                            _objSOMasterProperty.createdByUserIdx));
                        cmdToExecute.Parameters.Add(new SqlParameter("@customeridx", SqlDbType.Int, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                            _objSOMasterProperty.customerIdx));
                        cmdToExecute.Parameters.Add(new SqlParameter("@employeeidx", SqlDbType.Int, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        cmdToExecute.Parameters.Add(new SqlParameter("@vendoridx", SqlDbType.Int, 25,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        cmdToExecute.Parameters.Add(new SqlParameter("@invoiceidx", SqlDbType.NVarChar, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                            _objSOMasterProperty.soNumber));
                        cmdToExecute.Parameters.Add(new SqlParameter("@debit", SqlDbType.Decimal, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                            _objSOMasterProperty.balanceAmount));
                        cmdToExecute.Parameters.Add(new SqlParameter("@credit", SqlDbType.Decimal, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 0.00m));
                        cmdToExecute.Parameters.Add(new SqlParameter("@creationDate", SqlDbType.Date, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                            _objSOMasterProperty.creationDate));
                        cmdToExecute.Parameters.Add(new SqlParameter("@modifiedDate", SqlDbType.Date, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        cmdToExecute.Parameters.Add(new SqlParameter("@DueDate", SqlDbType.Date, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        cmdToExecute.Parameters.Add(new SqlParameter("@coaidx", SqlDbType.Int, 500,
                            ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                            _objSOMasterProperty.CustomerCoaidx));
                        cmdToExecute.Transaction = this.Transaction;
                        _rowsAffected = cmdToExecute.ExecuteNonQuery();

                        #endregion

                        #region No Pay

                        if (_objSOMasterProperty.paidAmount == 0)
                        {
                            //cash entry bank
                            cmdToExecute = new SqlCommand();
                            // cmdToExecute.CommandType = CommandType.StoredProcedure;
                            cmdToExecute.CommandType = CommandType.StoredProcedure;
                            cmdToExecute.CommandText = "sp_InsertSIAccountGj";
                            cmdToExecute.Connection = _mainConnection;
                            cmdToExecute.Parameters.Add(new SqlParameter("@GLIdx", SqlDbType.Int, 50,
                                ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, GLIDX));
                            cmdToExecute.Parameters.Add(new SqlParameter("@TransTypeIdx", SqlDbType.Int, 500,
                                ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 2));
                            cmdToExecute.Parameters.Add(new SqlParameter("@useridx", SqlDbType.Int, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                                _objSOMasterProperty.createdByUserIdx));
                            cmdToExecute.Parameters.Add(new SqlParameter("@customeridx", SqlDbType.Int, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                                _objSOMasterProperty.customerIdx));
                            cmdToExecute.Parameters.Add(new SqlParameter("@employeeidx", SqlDbType.Int, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                            cmdToExecute.Parameters.Add(new SqlParameter("@vendoridx", SqlDbType.Int, 25,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                            cmdToExecute.Parameters.Add(new SqlParameter("@invoiceidx", SqlDbType.NVarChar, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                                _objSOMasterProperty.soNumber));
                            cmdToExecute.Parameters.Add(new SqlParameter("@debit", SqlDbType.Decimal, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                                _objSOMasterProperty.balanceAmount));
                            cmdToExecute.Parameters.Add(new SqlParameter("@credit", SqlDbType.Decimal, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 0.00m));
                            cmdToExecute.Parameters.Add(new SqlParameter("@creationDate", SqlDbType.Date, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                                _objSOMasterProperty.creationDate));
                            cmdToExecute.Parameters.Add(new SqlParameter("@modifiedDate", SqlDbType.Date, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                            cmdToExecute.Parameters.Add(new SqlParameter("@DueDate", SqlDbType.Date, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                            cmdToExecute.Parameters.Add(new SqlParameter("@coaidx", SqlDbType.Int, 500,
                                ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed,
                                _objSOMasterProperty.BankCOAIDX));
                            cmdToExecute.Transaction = this.Transaction;
                            _rowsAffected = cmdToExecute.ExecuteNonQuery();

                            #endregion

                        }
                    }
                }
                else
                {
                    if (_objSOMasterProperty.DetailData != null)
                    {
                        foreach (DataRow row in _objSOMasterProperty.DetailData.Rows)
                        {
                            row["salesorderIdx"] = cmdToExecute.Parameters["@ID"].Value.ToString();
                            _objSOMasterProperty.idx = Convert.ToInt32(cmdToExecute.Parameters["@ID"].Value.ToString());
                        }

                        _objSOMasterProperty.DetailData.AcceptChanges();

                        SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);
                        _objSOMasterProperty.DetailData.TableName = "SalesOrderDetails";

                        sbc.ColumnMappings.Clear();
                        sbc.ColumnMappings.Add("salesorderIdx", "salesorderIdx");
                        //sbc.ColumnMappings.Add(2, 1);
                        sbc.ColumnMappings.Add("productTypeIdx", "productTypeIdx");
                        sbc.ColumnMappings.Add("itemIdx", "itemIdx");
                        sbc.ColumnMappings.Add("salePrice", "salePrice");
                        sbc.ColumnMappings.Add("qty", "qty");
                        sbc.ColumnMappings.Add("amount", "amount");
                        sbc.ColumnMappings.Add("qty", "openItem");
                       // sbc.ColumnMappings.Add("ItemDescription", "ItemDescription");

                        //sbc.ColumnMappings.Add("Product_Code", "Product_Code");
                        //sbc.ColumnMappings.Add("Product", "Product_Name");
                        //sbc.ColumnMappings.Add("Status", "Status");

                        //sbc.ColumnMappings.Add("Department_Id", "Department_Id");


                        sbc.DestinationTableName = _objSOMasterProperty.DetailData.TableName;
                        sbc.WriteToServer(_objSOMasterProperty.DetailData);

                    }
                    #region Taxes

                    //if (_objSOMasterProperty.SalesTaxData != null)
                    //{
                    //    foreach (DataRow row in _objSOMasterProperty.SalesTaxData.Rows)
                    //    {
                    //        row["saleIdx"] = cmdToExecute.Parameters["@ID"].Value.ToString();
                    //        row["taxType"] = "1";
                    //        row["creationDate"] = DateTime.Now.ToString("yyyy-MM-dd");

                    //        //row["createdBy"] = Convert.ToInt16(Session["UID"].ToString());
                    //    }
                    //    _objSOMasterProperty.SalesTaxData.AcceptChanges();

                    //    SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);
                    //    _objSOMasterProperty.SalesTaxData.TableName = "salesTaxes";

                    //    sbc.ColumnMappings.Clear();
                    //    sbc.ColumnMappings.Add("taxIdx", "taxIdx");
                    //    sbc.ColumnMappings.Add("taxPercent", "taxPercent");
                    //    sbc.ColumnMappings.Add("status", "status");
                    //    sbc.ColumnMappings.Add("creationDate", "creationDate");
                    //    //sbc.ColumnMappings.Add(2, 1);
                    //    sbc.ColumnMappings.Add("saleIdx", "saleIdx");
                    //    sbc.ColumnMappings.Add("taxType", "taxType");
                    //    sbc.DestinationTableName = _objSOMasterProperty.SalesTaxData.TableName;
                    //    sbc.WriteToServer(_objSOMasterProperty.SalesTaxData);

                    //}

                    #endregion


                    #region Account GJ Entry

                    int GLIDX = (Int32)cmdToExecute.Parameters["@glIdx"].Value;
                    //purchase entry for account gj same for all types
                    cmdToExecute = new SqlCommand();
                    // cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.CommandText = "sp_InsertSIAccountGj";
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.Parameters.Add(new SqlParameter("@GLIdx", SqlDbType.Int, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, GLIDX));
                    cmdToExecute.Parameters.Add(new SqlParameter("@TransTypeIdx", SqlDbType.Int, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 2));

                    cmdToExecute.Parameters.Add(new SqlParameter("@useridx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.createdByUserIdx));

                    cmdToExecute.Parameters.Add(new SqlParameter("@vendoridx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                    cmdToExecute.Parameters.Add(new SqlParameter("@employeeidx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                    cmdToExecute.Parameters.Add(new SqlParameter("@customeridx", SqlDbType.Int, 25, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.customerIdx));
                    cmdToExecute.Parameters.Add(new SqlParameter("@coaidx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 6)); //Sales
                    cmdToExecute.Parameters.Add(new SqlParameter("@invoiceidx", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.soNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@debit", SqlDbType.Decimal, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 0.00m));
                    cmdToExecute.Parameters.Add(new SqlParameter("@credit", SqlDbType.Decimal, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.netAmount));
                    cmdToExecute.Parameters.Add(new SqlParameter("@creationDate", SqlDbType.Date, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.creationDate));
                    cmdToExecute.Parameters.Add(new SqlParameter("@modifiedDate", SqlDbType.Date, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                    cmdToExecute.Parameters.Add(new SqlParameter("@DueDate", SqlDbType.Date, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));

                    cmdToExecute.Transaction = this.Transaction;
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();

                    if (_objSOMasterProperty.shippingCost > 0)
                    {
                        //int GLIDX = (Int32)cmdToExecute.Parameters["@glIdx"].Value;
                        //purchase entry for account gj same for all types
                        cmdToExecute = new SqlCommand();
                        // cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.CommandText = "sp_InsertSIAccountGj";
                        cmdToExecute.Connection = _mainConnection;
                        cmdToExecute.Parameters.Add(new SqlParameter("@GLIdx", SqlDbType.Int, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, GLIDX));
                        cmdToExecute.Parameters.Add(new SqlParameter("@TransTypeIdx", SqlDbType.Int, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 2));

                        cmdToExecute.Parameters.Add(new SqlParameter("@useridx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.createdByUserIdx));

                        cmdToExecute.Parameters.Add(new SqlParameter("@vendoridx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        cmdToExecute.Parameters.Add(new SqlParameter("@employeeidx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        cmdToExecute.Parameters.Add(new SqlParameter("@customeridx", SqlDbType.Int, 25, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.customerIdx));
                        cmdToExecute.Parameters.Add(new SqlParameter("@coaidx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 8)); //Shipping Cost
                        cmdToExecute.Parameters.Add(new SqlParameter("@invoiceidx", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.soNumber));
                        cmdToExecute.Parameters.Add(new SqlParameter("@debit", SqlDbType.Decimal, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.shippingCost));
                        cmdToExecute.Parameters.Add(new SqlParameter("@credit", SqlDbType.Decimal, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 0.00m));
                        cmdToExecute.Parameters.Add(new SqlParameter("@creationDate", SqlDbType.Date, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.creationDate));
                        cmdToExecute.Parameters.Add(new SqlParameter("@modifiedDate", SqlDbType.Date, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        cmdToExecute.Parameters.Add(new SqlParameter("@DueDate", SqlDbType.Date, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));

                        cmdToExecute.Transaction = this.Transaction;
                        _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    }
                    if (_objSOMasterProperty.discount > 0)
                    {
                        //int GLIDX = (Int32)cmdToExecute.Parameters["@glIdx"].Value;
                        //purchase entry for account gj same for all types
                        cmdToExecute = new SqlCommand();
                        // cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.CommandText = "sp_InsertSIAccountGj";
                        cmdToExecute.Connection = _mainConnection;
                        cmdToExecute.Parameters.Add(new SqlParameter("@GLIdx", SqlDbType.Int, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, GLIDX));
                        cmdToExecute.Parameters.Add(new SqlParameter("@TransTypeIdx", SqlDbType.Int, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 2));

                        cmdToExecute.Parameters.Add(new SqlParameter("@useridx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.createdByUserIdx));

                        cmdToExecute.Parameters.Add(new SqlParameter("@vendoridx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        cmdToExecute.Parameters.Add(new SqlParameter("@employeeidx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        cmdToExecute.Parameters.Add(new SqlParameter("@customeridx", SqlDbType.Int, 25, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.customerIdx));
                        cmdToExecute.Parameters.Add(new SqlParameter("@coaidx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 9));//Discount
                        cmdToExecute.Parameters.Add(new SqlParameter("@invoiceidx", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.soNumber));
                        cmdToExecute.Parameters.Add(new SqlParameter("@debit", SqlDbType.Decimal, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.discount));
                        cmdToExecute.Parameters.Add(new SqlParameter("@credit", SqlDbType.Decimal, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 0.00m));
                        cmdToExecute.Parameters.Add(new SqlParameter("@creationDate", SqlDbType.Date, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.creationDate));
                        cmdToExecute.Parameters.Add(new SqlParameter("@modifiedDate", SqlDbType.Date, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        cmdToExecute.Parameters.Add(new SqlParameter("@DueDate", SqlDbType.Date, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));

                        cmdToExecute.Transaction = this.Transaction;
                        _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    }
                    //purchase end

                    //TAX entries
                    #region Account Gj Tax Entries

                    //if (_objSOMasterProperty.SalesTaxData != null)
                    //{
                    //    for (int i = 0; i < _objSOMasterProperty.SalesTaxData.Rows.Count; i++)
                    //    {

                    //        decimal taxpercntage = Convert.ToDecimal(_objSOMasterProperty.SalesTaxData.Rows[i]["taxPercent"].ToString());
                    //        int taxid = Convert.ToInt32(_objSOMasterProperty.SalesTaxData.Rows[i]["taxIdx"].ToString());
                    //        decimal taxamount = ((_objSOMasterProperty.netAmount / 100) * (taxpercntage));
                    //        cmdToExecute = new SqlCommand();
                    //        // cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //        cmdToExecute.CommandType = CommandType.StoredProcedure;
                    //        cmdToExecute.CommandText = "sp_InsertSIAccountGj";
                    //        cmdToExecute.Connection = _mainConnection;
                    //        cmdToExecute.Parameters.Add(new SqlParameter("@GLIdx", SqlDbType.Int, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, GLIDX));
                    //        cmdToExecute.Parameters.Add(new SqlParameter("@TransTypeIdx", SqlDbType.Int, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 112));

                    //        cmdToExecute.Parameters.Add(new SqlParameter("@useridx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.createdByUserIdx));

                    //        cmdToExecute.Parameters.Add(new SqlParameter("@customeridx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.customerIdx));
                    //        cmdToExecute.Parameters.Add(new SqlParameter("@employeeidx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                    //        cmdToExecute.Parameters.Add(new SqlParameter("@vendoridx", SqlDbType.Int, 25, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                    //        cmdToExecute.Parameters.Add(new SqlParameter("@coaidx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, taxid));
                    //        cmdToExecute.Parameters.Add(new SqlParameter("@invoiceidx", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.soNumber));
                    //        cmdToExecute.Parameters.Add(new SqlParameter("@debit", SqlDbType.Decimal, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 0.00m));
                    //        cmdToExecute.Parameters.Add(new SqlParameter("@credit", SqlDbType.Decimal, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, taxamount));
                    //        cmdToExecute.Parameters.Add(new SqlParameter("@creationDate", SqlDbType.Date, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.creationDate));
                    //        cmdToExecute.Parameters.Add(new SqlParameter("@modifiedDate", SqlDbType.Date, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                    //        cmdToExecute.Parameters.Add(new SqlParameter("@DueDate", SqlDbType.Date, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));

                    //        cmdToExecute.Transaction = this.Transaction;
                    //        _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    //    }
                    //}

                    #endregion

                    #region Full Payment

                    if (_objSOMasterProperty.balanceAmount == 0)
                    {

                        //cash entry bank
                        cmdToExecute = new SqlCommand();
                        // cmdToExecute.CommandType = CommandType.StoredProcedure;

                        cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.CommandText = "sp_InsertSIAccountGj";

                        cmdToExecute.Connection = _mainConnection;
                        cmdToExecute.Parameters.Add(new SqlParameter("@GLIdx", SqlDbType.Int, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, GLIDX));
                        cmdToExecute.Parameters.Add(new SqlParameter("@TransTypeIdx", SqlDbType.Int, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 2));

                        cmdToExecute.Parameters.Add(new SqlParameter("@useridx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.createdByUserIdx));

                        cmdToExecute.Parameters.Add(new SqlParameter("@customeridx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.customerIdx));
                        cmdToExecute.Parameters.Add(new SqlParameter("@employeeidx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        cmdToExecute.Parameters.Add(new SqlParameter("@vendoridx", SqlDbType.Int, 25, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));

                        cmdToExecute.Parameters.Add(new SqlParameter("@invoiceidx", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.soNumber));
                        cmdToExecute.Parameters.Add(new SqlParameter("@debit", SqlDbType.Decimal, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.paidAmount));
                        cmdToExecute.Parameters.Add(new SqlParameter("@credit", SqlDbType.Decimal, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 0.00m));
                        cmdToExecute.Parameters.Add(new SqlParameter("@creationDate", SqlDbType.Date, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.creationDate));
                        cmdToExecute.Parameters.Add(new SqlParameter("@modifiedDate", SqlDbType.Date, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        cmdToExecute.Parameters.Add(new SqlParameter("@DueDate", SqlDbType.Date, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        //cmdToExecute.Parameters.Add(new SqlParameter("@credit", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objMRMasterProperty.isPaid));
                        if (_objSOMasterProperty.paymentModeIdx == 1)
                        {
                            //cash
                            cmdToExecute.Parameters.Add(new SqlParameter("@coaidx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 7));
                        }
                        if (_objSOMasterProperty.paymentModeIdx == 2 || _objSOMasterProperty.paymentModeIdx == 3)
                        {
                            //bank
                            // var data= _objpinvoicepropert
                            cmdToExecute.Parameters.Add(new SqlParameter("@coaidx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.BankCOAIDX));
                        }

                        if (_objSOMasterProperty.paymentModeIdx == 4)
                        {
                            //cash
                            cmdToExecute.Parameters.Add(new SqlParameter("@coaidx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 55)); //Customer Payment
                        }

                        cmdToExecute.Transaction = this.Transaction;
                        //this.StartTransaction();
                        // cmdToExecute.Transaction = this.Transaction;
                        // Execute query.
                        _rowsAffected = cmdToExecute.ExecuteNonQuery();

                        //cash end


                    }


                    #endregion


                    #region partial Payment
                    if (_objSOMasterProperty.paidAmount != _objSOMasterProperty.totalAmount)
                    {

                        //cash entry bank
                        cmdToExecute = new SqlCommand();
                        // cmdToExecute.CommandType = CommandType.StoredProcedure;

                        cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.CommandText = "sp_InsertSIAccountGj";

                        cmdToExecute.Connection = _mainConnection;
                        cmdToExecute.Parameters.Add(new SqlParameter("@GLIdx", SqlDbType.Int, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, GLIDX));
                        cmdToExecute.Parameters.Add(new SqlParameter("@TransTypeIdx", SqlDbType.Int, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 2));

                        cmdToExecute.Parameters.Add(new SqlParameter("@useridx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.createdByUserIdx));

                        cmdToExecute.Parameters.Add(new SqlParameter("@customeridx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.customerIdx));
                        cmdToExecute.Parameters.Add(new SqlParameter("@employeeidx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        cmdToExecute.Parameters.Add(new SqlParameter("@vendoridx", SqlDbType.Int, 25, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));

                        cmdToExecute.Parameters.Add(new SqlParameter("@invoiceidx", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.soNumber));
                        cmdToExecute.Parameters.Add(new SqlParameter("@debit", SqlDbType.Decimal, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.paidAmount));
                        cmdToExecute.Parameters.Add(new SqlParameter("@credit", SqlDbType.Decimal, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 0.00m));
                        cmdToExecute.Parameters.Add(new SqlParameter("@creationDate", SqlDbType.Date, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.creationDate));
                        cmdToExecute.Parameters.Add(new SqlParameter("@modifiedDate", SqlDbType.Date, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        cmdToExecute.Parameters.Add(new SqlParameter("@DueDate", SqlDbType.Date, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        //cmdToExecute.Parameters.Add(new SqlParameter("@credit", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objMRMasterProperty.isPaid));
                        if (_objSOMasterProperty.paymentModeIdx == 1)
                        {
                            //cash
                            cmdToExecute.Parameters.Add(new SqlParameter("@coaidx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 7));
                        }
                        if (_objSOMasterProperty.paymentModeIdx == 2 || _objSOMasterProperty.paymentModeIdx == 3)
                        {
                            //bank
                            // var data= _objpinvoicepropert
                            cmdToExecute.Parameters.Add(new SqlParameter("@coaidx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.BankCOAIDX));
                        }
                        if (_objSOMasterProperty.paymentModeIdx == 4)
                        {
                            //cash
                            cmdToExecute.Parameters.Add(new SqlParameter("@coaidx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 55));//Customer Payment
                        }
                        cmdToExecute.Transaction = this.Transaction;
                        _rowsAffected = cmdToExecute.ExecuteNonQuery();


                        //acount receivable
                        cmdToExecute = new SqlCommand();
                        cmdToExecute.CommandType = CommandType.StoredProcedure;
                        cmdToExecute.CommandText = "sp_InsertSIAccountGj";
                        cmdToExecute.Connection = _mainConnection;
                        cmdToExecute.Parameters.Add(new SqlParameter("@GLIdx", SqlDbType.Int, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, GLIDX));
                        cmdToExecute.Parameters.Add(new SqlParameter("@TransTypeIdx", SqlDbType.Int, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 2));
                        cmdToExecute.Parameters.Add(new SqlParameter("@useridx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.createdByUserIdx));
                        cmdToExecute.Parameters.Add(new SqlParameter("@customeridx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.customerIdx));
                        cmdToExecute.Parameters.Add(new SqlParameter("@employeeidx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        cmdToExecute.Parameters.Add(new SqlParameter("@vendoridx", SqlDbType.Int, 25, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        cmdToExecute.Parameters.Add(new SqlParameter("@invoiceidx", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.soNumber));
                        cmdToExecute.Parameters.Add(new SqlParameter("@debit", SqlDbType.Decimal, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.balanceAmount));
                        cmdToExecute.Parameters.Add(new SqlParameter("@credit", SqlDbType.Decimal, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 0.00m));
                        cmdToExecute.Parameters.Add(new SqlParameter("@creationDate", SqlDbType.Date, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.creationDate));
                        cmdToExecute.Parameters.Add(new SqlParameter("@modifiedDate", SqlDbType.Date, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        cmdToExecute.Parameters.Add(new SqlParameter("@DueDate", SqlDbType.Date, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                        cmdToExecute.Parameters.Add(new SqlParameter("@coaidx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.CustomerCoaidx));
                        cmdToExecute.Transaction = this.Transaction;
                        _rowsAffected = cmdToExecute.ExecuteNonQuery();

                        #endregion

                        #region No Pay

                        if (_objSOMasterProperty.paidAmount == 0)
                        {
                            //cash entry bank
                            cmdToExecute = new SqlCommand();
                            // cmdToExecute.CommandType = CommandType.StoredProcedure;
                            cmdToExecute.CommandType = CommandType.StoredProcedure;
                            cmdToExecute.CommandText = "sp_InsertAccountGj";
                            cmdToExecute.Connection = _mainConnection;
                            cmdToExecute.Parameters.Add(new SqlParameter("@GLIdx", SqlDbType.Int, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, GLIDX));
                            cmdToExecute.Parameters.Add(new SqlParameter("@TransTypeIdx", SqlDbType.Int, 500, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, 2));
                            cmdToExecute.Parameters.Add(new SqlParameter("@useridx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.createdByUserIdx));
                            cmdToExecute.Parameters.Add(new SqlParameter("@customeridx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.customerIdx));
                            cmdToExecute.Parameters.Add(new SqlParameter("@employeeidx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                            cmdToExecute.Parameters.Add(new SqlParameter("@vendoridx", SqlDbType.Int, 25, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                            cmdToExecute.Parameters.Add(new SqlParameter("@invoiceidx", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.soNumber));
                            cmdToExecute.Parameters.Add(new SqlParameter("@debit", SqlDbType.Decimal, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.balanceAmount));
                            cmdToExecute.Parameters.Add(new SqlParameter("@credit", SqlDbType.Decimal, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, 0.00m));
                            cmdToExecute.Parameters.Add(new SqlParameter("@creationDate", SqlDbType.Date, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.creationDate));
                            cmdToExecute.Parameters.Add(new SqlParameter("@modifiedDate", SqlDbType.Date, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                            cmdToExecute.Parameters.Add(new SqlParameter("@DueDate", SqlDbType.Date, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, null));
                            cmdToExecute.Parameters.Add(new SqlParameter("@coaidx", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.BankCOAIDX));
                            cmdToExecute.Transaction = this.Transaction;
                            _rowsAffected = cmdToExecute.ExecuteNonQuery();
                            #endregion

                        }

                        #endregion

                        //#region Inventory Log and Inventory

                        for (int i = 0; i < _objSOMasterProperty.InvoiceDetails.Rows.Count; i++)
                        {
                            cmdToExecute = new SqlCommand();
                            cmdToExecute.CommandText = "[sp_SOInventoryMaster]";
                            cmdToExecute.CommandType = CommandType.StoredProcedure;
                            cmdToExecute.Connection = _mainConnection;

                            cmdToExecute.Parameters.Add(new SqlParameter("@productid", SqlDbType.Int, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToInt16(_objSOMasterProperty.InvoiceDetails.Rows[i]["itemIdx"])));
                            cmdToExecute.Parameters.Add(new SqlParameter("@newqty", SqlDbType.Int, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToDecimal(_objSOMasterProperty.InvoiceDetails.Rows[i]["qty"])));
                            cmdToExecute.Parameters.Add(new SqlParameter("@newrate", SqlDbType.Decimal, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToDecimal(_objSOMasterProperty.InvoiceDetails.Rows[i]["salePrice"])));
                          //  cmdToExecute.Parameters.Add(new SqlParameter("@newRetailrate", SqlDbType.Decimal, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToDecimal(_objSOMasterProperty.InvoiceDetails.Rows[i]["salePrice"])));
                            cmdToExecute.Parameters.Add(new SqlParameter("@branchIdx", SqlDbType.Int, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, Convert.ToDecimal(_objSOMasterProperty.InvoiceDetails.Rows[i]["branchIdx"])));

                            cmdToExecute.Transaction = this.Transaction;
                            _rowsAffected = cmdToExecute.ExecuteNonQuery();
                        }

                        //cmdToExecute = new SqlCommand();
                        //// cmdToExecute.CommandType = CommandType.StoredProcedure;
                        //cmdToExecute.CommandText = "dbo.[sp_ProcessSOForLogs]";
                        //cmdToExecute.CommandType = CommandType.StoredProcedure;
                        //cmdToExecute.Connection = _mainConnection;
                        //cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, piIdx));
                        //cmdToExecute.Parameters.Add(new SqlParameter("@WarehouseIdx", SqlDbType.Int, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.WarerHouseID));
                        ////cmdToExecute.Parameters.Add(new SqlParameter("@WarehouseIdx", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed,));
                        //cmdToExecute.Transaction = this.Transaction;
                        //_rowsAffected = cmdToExecute.ExecuteNonQuery();

                        //#endregion
                    }
                }

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    this.RollBack();
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_MASTER_Insert' reSOrted the ErrorCode: " + _errorCode);

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

        //Delete
        public bool Delete()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = @"update salesorder SET visible=0 where idx=@ID";
            //cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@companyIdx", SqlDbType.Int, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objUserProperty.companyIdx));
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.idx));

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
            cmdToExecute.CommandText = "dbo.[sp_GetAllSalesOrders]";
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
        public  DataTable SelectForDropDown()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetAllSalesOrdersForDDL]";
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
        public override DataTable SelectOne()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_SelctSOByid]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Bank Setup");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@SOid", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _objSOMasterProperty.idx));

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
        public  DataTable SelectAllInvoiceDetails(int id)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = @"select sd.*,pr.itemName from salesOrderDetails sd
inner join products pr on pr.idx = sd.itemIdx where sd.salesOrderIdx=@idx ";
            //cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Banks");
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
        public  DataTable GetStockandPrice(int productid)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_CalculateInventory]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Bank Setup");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@productid", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, productid));

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

        public DataTable GetStockandPriceBranchWise(SalesOrderVM_Property objSale)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_CalculateInventoryBranchWise]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Bank Setup");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@productid", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSale.itemIdx));
                cmdToExecute.Parameters.Add(new SqlParameter("@branchId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objSale.branchIdx));

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
        public DataTable GenerateSONo(LP_GenerateTransNumber_Property objTranNo)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GenerateTransNo]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("SO");
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
        public DataTable SelectSIBYDate(LP_Voucher_ViewModel objVCHR)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_SelctSIbyDate]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Bank Setup");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@customerid", SqlDbType.Int, 40, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objVCHR.customer_id));
                cmdToExecute.Parameters.Add(new SqlParameter("@datefrom", SqlDbType.DateTime, 40, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objVCHR.From_Date));
                cmdToExecute.Parameters.Add(new SqlParameter("@dateto", SqlDbType.DateTime, 40, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objVCHR.To_Date));


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


        public DataTable getSalesForReturn(int salesIdx)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_getSalesDataForReturn]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Bank Setup");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@idx", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, salesIdx));

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

        public DataTable CheckProductInInventory(int salesIdx)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_CheckProductInInventory]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Bank Setup");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@idx", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, salesIdx));

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
        public DataSet SelectAllSIDetailsDataById(int id)
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = @"select sd.*,so.* from SalesOrder so left join SalesOrderDetails sd on
sd.salesorderIdx=so.idx
where so.idx=@idx
select * from salesTaxes where taxType=1 and saleIdx=@idx";
            //cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Banks");
            DataSet DS = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@idx", SqlDbType.Int, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, id));


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
                adapter.Fill(DS);
                //  _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;

                //if (_errorCode != (int)LLBLError.AllOk)
                //{
                //    // Throw error.
                //    throw new Exception("Stored Procedure 'pr_PRODUCT_SETUP_SelectAll' reported the ErrorCode: " + _errorCode);
                //}

                return DS;
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
