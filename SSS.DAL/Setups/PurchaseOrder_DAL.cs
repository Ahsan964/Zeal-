using SNDDAL;
using SSS.Property;
using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SSS.DAL.Setups
{
   public class PurchaseOrder_DAL: DBInteractionBase
    {
        PurchaseOrderMaster objPurchaseOrderMaster;
        public PurchaseOrder_DAL()
        {

        }
        public PurchaseOrder_DAL(PurchaseOrderMaster objPurchaseOrderMasternew)
        {
            objPurchaseOrderMaster = objPurchaseOrderMasternew;
        }
        
        public string GetDocumentCode()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetDocumentCodeForPurchaseOrder]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Document");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                // cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objCompanyProperty.ID));

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
                // _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;
                //objCompanyProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_GetDocumentSetup' reported the ErrorCode: " + _errorCode);
                }
                string Docno = "";
                foreach (DataRow dr in toReturn.Rows)
                {
                    Docno = dr["DocumentNo"].ToString();
                }
                return Docno;
                // return toReturn.Rows[0]. .ToString();
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("COMPANY::SelectAll::Error occured.", ex);
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
            cmdToExecute.CommandText = "dbo.[sp_PurchaseOrderInsert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@documenttypeid", SqlDbType.Int, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.DocumentId));
                cmdToExecute.Parameters.Add(new SqlParameter("@pono", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.Po_no));
                cmdToExecute.Parameters.Add(new SqlParameter("@supplierid", SqlDbType.Int, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.Supplier_id));
                cmdToExecute.Parameters.Add(new SqlParameter("@documentdate", SqlDbType.DateTime, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.DocumentDateTime));

                cmdToExecute.Parameters.Add(new SqlParameter("@narration", SqlDbType.NVarChar, 80, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.Narration));
                cmdToExecute.Parameters.Add(new SqlParameter("@locationid", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.LocationId));
                //cmdToExecute.Parameters.Add(new SqlParameter("@TotalAmount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.TotalAmount));
                cmdToExecute.Parameters.Add(new SqlParameter("@status", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@userid", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.UserId));
                cmdToExecute.Parameters.Add(new SqlParameter("@supplierreference", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objPurchaseOrderMaster.Supplier_Dc_Reference));
                cmdToExecute.Parameters.Add(new SqlParameter("@lcnumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objPurchaseOrderMaster.LC_Number));
                cmdToExecute.Parameters.Add(new SqlParameter("@refothers", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objPurchaseOrderMaster.Ref_Others));
                cmdToExecute.Parameters.Add(new SqlParameter("@year", SqlDbType.Int, 50, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objPurchaseOrderMaster.Year));
                cmdToExecute.Parameters.Add(new SqlParameter("@period", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.Period));
                cmdToExecute.Parameters.Add(new SqlParameter("@isactive", SqlDbType.Bit, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.IsActive));
                cmdToExecute.Parameters.Add(new SqlParameter("@distibuter_id", SqlDbType.Int, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, SessionManager.CurrentUser.DistributorID));
                cmdToExecute.Parameters.Add(new SqlParameter("@instruction", SqlDbType.Text, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.Instructions));
                ////cmdToExecute.Parameters.Add(new SqlParameter("Processed", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Processed));
                ////cmdToExecute.Parameters.Add(new SqlParameter("Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Status));
                ////cmdToExecute.Parameters.Add(new SqlParameter("Pos_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Pos_ID));
                ////cmdToExecute.Parameters.Add(new SqlParameter("PersonnelRef_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.PersonnelRef_ID));
                ////cmdToExecute.Parameters.Add(new SqlParameter("Prp_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Prp_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@DeliveryDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.DeliveryDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@totalamount", SqlDbType.Decimal, 8, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.TotalAmount));
                ////cmdToExecute.Parameters.Add(new SqlParameter("Transactionid", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.ID));

                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 32, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.ID));
                ////cmdToExecute.Parameters.Add(new SqlParameter("ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                ////cmdToExecute.Parameters.Add(new SqlParameter("Record_Table_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Record_Table_Name));
                ////cmdToExecute.Parameters.Add(new SqlParameter("Operation", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Operation));
                ////cmdToExecute.Parameters.Add(new SqlParameter("Operated_By", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Operated_By));
                ////cmdToExecute.Parameters.Add(new SqlParameter("Operation_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Operation_Date));


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

                if (objPurchaseOrderMaster.DetailData != null)
                {
                    foreach (DataRow row in objPurchaseOrderMaster.DetailData.Rows) {
                        row["PurchaseMaster_Id"] = cmdToExecute.Parameters["@ID"].Value.ToString();
                        row["Master_Table_Id"] = cmdToExecute.Parameters["@ID"].Value.ToString();
                        row["Master_Table_Name"] = "Purchase Order";
                        row["Document_Table_Name"] = "Purchase Requisition";
                    }
                        string  p_docId= cmdToExecute.Parameters["@ID"].Value.ToString();

                    objPurchaseOrderMaster.DetailData.AcceptChanges();

                    SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);
                    objPurchaseOrderMaster.DetailData.TableName = "PurchaseOrder_Detail";

                    sbc.ColumnMappings.Clear();
                    sbc.ColumnMappings.Add("PurchaseMaster_Id", "PurchaseMaster_Id");
                    //sbc.ColumnMappings.Add(2, 1);
                    sbc.ColumnMappings.Add("Product_id", "Product_id");
                    sbc.ColumnMappings.Add("Rate", "Rate");
                    sbc.ColumnMappings.Add("Quantity", "Quantity");
                    sbc.ColumnMappings.Add("Pack_Unit_Id", "Pack_Unit_Id");
                    sbc.ColumnMappings.Add("Total_Price", "Total_Price");
                    //sbc.ColumnMappings.Add("Product_Code", "Product_Code");
                    sbc.ColumnMappings.Add("Product_Name", "Product_Name");
                    //sbc.ColumnMappings.Add("Status", "Status");

                    sbc.ColumnMappings.Add("Department_Id", "Department_Id");
                    sbc.ColumnMappings.Add("Description", "Description");

                    sbc.DestinationTableName = objPurchaseOrderMaster.DetailData.TableName;
                    sbc.WriteToServer(objPurchaseOrderMaster.DetailData);


                    //Parent Doc ENtries
                    objPurchaseOrderMaster.DetailData.AcceptChanges();
                    sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);
                    objPurchaseOrderMaster.DetailData.TableName = "Parent_Document_Entries";
                    DataTable st = objPurchaseOrderMaster.DetailData.DefaultView.ToTable(true, "Parent_document_ID", "Master_Table_Id", "Master_Table_Name", "Document_Table_Name");
                    sbc.ColumnMappings.Clear();
                    sbc.ColumnMappings.Add("Parent_document_ID", "Parent_Document_Id");
                    sbc.ColumnMappings.Add("Master_Table_Id", "Master_Table_Id");
                    sbc.ColumnMappings.Add("Master_Table_Name", "Master_Table_Name");
                    sbc.ColumnMappings.Add("Document_Table_Name", "Document_Table_Name");
                  

                    sbc.DestinationTableName = objPurchaseOrderMaster.DetailData.TableName;
                    sbc.WriteToServer(objPurchaseOrderMaster.DetailData.DefaultView.ToTable(true, "Parent_document_ID", "Master_Table_Id", "Master_Table_Name", "Document_Table_Name"));



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
        
        public DataTable SelectAllPO()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetPO_SelectAll]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("PurchaseOrder_Master");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@fromdata", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.FromDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@todate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.ToDate));

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
                // _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;
                //objCompanyProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_GetPO_SelectAll' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("COMPANY::SelectAll::Error occured.", ex);
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

        public DataSet SelectAllPurchaseOrders()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetPO_SelectAll]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("PurchaseOrder_Master");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@fromdata", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.FromDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@todate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.ToDate));

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
                // _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;
                //objCompanyProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_GetPO_SelectAll' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("COMPANY::SelectAll::Error occured.", ex);
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
        public DataSet SelectPurchaseOrdersByID()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetPO_SelectAll_By_ID]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("PurchaseOrder_Master");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 8, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.ID));
                //cmdToExecute.Parameters.Add(new SqlParameter("@todate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.ToDate));

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
                // _errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;
                //objCompanyProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_GetPO_SelectAll' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("COMPANY::SelectAll::Error occured.", ex);
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
        public override bool Update()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[Sp_Purchase_Order_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                //cmdToExecute.Parameters.Add(new SqlParameter("@documenttypeid", SqlDbType.Int, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.DocumentId));
                //cmdToExecute.Parameters.Add(new SqlParameter("@pono", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.Po_no));
                cmdToExecute.Parameters.Add(new SqlParameter("@supplier_Id", SqlDbType.Int, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.Supplier_id));
                //cmdToExecute.Parameters.Add(new SqlParameter("@documentdate", SqlDbType.DateTime, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.DocumentDateTime));

                cmdToExecute.Parameters.Add(new SqlParameter("@narration", SqlDbType.NVarChar, 80, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.Narration));
                cmdToExecute.Parameters.Add(new SqlParameter("@locationid", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.LocationId));
                //cmdToExecute.Parameters.Add(new SqlParameter("@TotalAmount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.TotalAmount));
                //cmdToExecute.Parameters.Add(new SqlParameter("@status", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@userid", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.UserId));
                cmdToExecute.Parameters.Add(new SqlParameter("@supplierrefrence", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objPurchaseOrderMaster.Supplier_Dc_Reference));
                cmdToExecute.Parameters.Add(new SqlParameter("@lcnumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objPurchaseOrderMaster.LC_Number));
                cmdToExecute.Parameters.Add(new SqlParameter("@refothers", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objPurchaseOrderMaster.Ref_Others));
                //cmdToExecute.Parameters.Add(new SqlParameter("@year", SqlDbType.Int, 50, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objPurchaseOrderMaster.Year));
                //cmdToExecute.Parameters.Add(new SqlParameter("@period", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.Period));
                //cmdToExecute.Parameters.Add(new SqlParameter("@isactive", SqlDbType.Bit, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.IsActive));
                cmdToExecute.Parameters.Add(new SqlParameter("@distributerid", SqlDbType.Int, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, SessionManager.CurrentUser.DistributorID));
                cmdToExecute.Parameters.Add(new SqlParameter("@instructions", SqlDbType.Text, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.Instructions));
                cmdToExecute.Parameters.Add(new SqlParameter("@totalamount", SqlDbType.Decimal, 18, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.TotalAmount));
                //cmdToExecute.Parameters.Add(new SqlParameter("@distributerid", SqlDbType.Int, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Status));
                ////cmdToExecute.Parameters.Add(new SqlParameter("Pos_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Pos_ID));
                ////cmdToExecute.Parameters.Add(new SqlParameter("PersonnelRef_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.PersonnelRef_ID));
                ////cmdToExecute.Parameters.Add(new SqlParameter("Prp_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Prp_ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@deliverydate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.DeliveryDate));
                ////cmdToExecute.Parameters.Add(new SqlParameter("Route_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Route_ID));
                ////cmdToExecute.Parameters.Add(new SqlParameter("Transactionid", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.ID));

                cmdToExecute.Parameters.Add(new SqlParameter("@PurchaseOrderMaseterID", SqlDbType.Int, 32, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.ID));
                ////cmdToExecute.Parameters.Add(new SqlParameter("ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                ////cmdToExecute.Parameters.Add(new SqlParameter("Record_Table_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Record_Table_Name));
                ////cmdToExecute.Parameters.Add(new SqlParameter("Operation", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Operation));
                ////cmdToExecute.Parameters.Add(new SqlParameter("Operated_By", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Operated_By));
                ////cmdToExecute.Parameters.Add(new SqlParameter("Operation_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Operation_Date));


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

                if (objPurchaseOrderMaster.DetailData != null)
                {
                    foreach (DataRow row in objPurchaseOrderMaster.DetailData.Rows)
                    {
                        row["PurchaseMaster_Id"] = cmdToExecute.Parameters["@PurchaseOrderMaseterID"].Value.ToString();
                        
                    }
                    
                    objPurchaseOrderMaster.DetailData.AcceptChanges();

                    SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);
                    objPurchaseOrderMaster.DetailData.TableName = "PurchaseOrder_Detail";

                    sbc.ColumnMappings.Clear();
                    sbc.ColumnMappings.Add("PurchaseMaster_Id", "PurchaseMaster_Id");
                    //sbc.ColumnMappings.Add(2, 1);
                    sbc.ColumnMappings.Add("Product_id", "Product_id");
                    sbc.ColumnMappings.Add("Rate", "Rate");
                    sbc.ColumnMappings.Add("Quantity", "Quantity");
                    sbc.ColumnMappings.Add("Pack_Unit_Id", "Pack_Unit_Id");
                    sbc.ColumnMappings.Add("Total_Price", "Total_Price");
                    //sbc.ColumnMappings.Add("Product_Code", "Product_Code");
                    sbc.ColumnMappings.Add("Product_Name", "Product_Name");
                    //sbc.ColumnMappings.Add("Status", "Status");

                    sbc.ColumnMappings.Add("Department_Id", "Department_Id");
                    sbc.ColumnMappings.Add("Description", "Description");

                    sbc.DestinationTableName = objPurchaseOrderMaster.DetailData.TableName;
                    sbc.WriteToServer(objPurchaseOrderMaster.DetailData);


                   


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
        public bool UpdateStatus()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_SSS_Status_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@tableName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.TableName));
                cmdToExecute.Parameters.Add(new SqlParameter("@recordId", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@operation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPurchaseOrderMaster.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@operationBy", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, SessionManager.CurrentUser.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@distributorId", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, SessionManager.CurrentUser.DistributorID));

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
                //_errorCode = (SqlInt32)cmdToExecute.Parameters["@ErrorCode"].Value;

                if (_errorCode != (int)LLBLError.AllOk)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;

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
    }
}
