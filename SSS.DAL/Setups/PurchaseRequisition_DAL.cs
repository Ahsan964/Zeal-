using SNDDAL;
using SSS.Property;
using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace SSS.DAL.Setups
{
     public  class PurchaseRequisition_DAL: DBInteractionBase
    {
        private PurchaseRequisitionMaster_Property objPurchaseRequisitionMaster_Property;
        
        public PurchaseRequisition_DAL()
        {

        }
        public PurchaseRequisition_DAL(PurchaseRequisitionMaster_Property objPurchaseRequisitionMasterProperty)
        {
            objPurchaseRequisitionMaster_Property = objPurchaseRequisitionMasterProperty;
        }

        public override bool Insert()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_PurchaseMaster_Insert]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@Document_Id", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.DocumentId));
                cmdToExecute.Parameters.Add(new SqlParameter("@DocumentName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.DocumentName));
                cmdToExecute.Parameters.Add(new SqlParameter("@DocumentDate", SqlDbType.DateTime, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.DocumentDateTime));
                cmdToExecute.Parameters.Add(new SqlParameter("@DocumentNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.DocumentNo));

                cmdToExecute.Parameters.Add(new SqlParameter("@Narration", SqlDbType.NVarChar, 80, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.Narration));
                cmdToExecute.Parameters.Add(new SqlParameter("@LocationId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.LocationId));
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalAmount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.TotalAmount));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@userid", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.UserId));
                cmdToExecute.Parameters.Add(new SqlParameter("@Posid", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.PosID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Discount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.Discount));
                cmdToExecute.Parameters.Add(new SqlParameter("@NetAmount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.NetAmount));
                cmdToExecute.Parameters.Add(new SqlParameter("@DeliveryDate", SqlDbType.DateTime, 50, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.DeliveryDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@Reference", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.Reference));
                cmdToExecute.Parameters.Add(new SqlParameter("@DocumentType", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.DocumentType));
                cmdToExecute.Parameters.Add(new SqlParameter("@IsActive", SqlDbType.Bit, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.IsActive));
                //cmdToExecute.Parameters.Add(new SqlParameter("Ref_Document1", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Ref_Document1));
                //cmdToExecute.Parameters.Add(new SqlParameter("Processed", SqlDbType.Bit, 1, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Processed));
                //cmdToExecute.Parameters.Add(new SqlParameter("Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Status));
                //cmdToExecute.Parameters.Add(new SqlParameter("Pos_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Pos_ID));
                //cmdToExecute.Parameters.Add(new SqlParameter("PersonnelRef_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.PersonnelRef_ID));
                //cmdToExecute.Parameters.Add(new SqlParameter("Prp_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Prp_ID));
                //cmdToExecute.Parameters.Add(new SqlParameter("DeliveryDate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.DeliveryDate));
                //cmdToExecute.Parameters.Add(new SqlParameter("Route_ID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Route_ID));
                //cmdToExecute.Parameters.Add(new SqlParameter("Transactionid", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.ID));

                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 32, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.ID));
                //cmdToExecute.Parameters.Add(new SqlParameter("ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));

                //cmdToExecute.Parameters.Add(new SqlParameter("Record_Table_Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Record_Table_Name));
                //cmdToExecute.Parameters.Add(new SqlParameter("Operation", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Operation));
                //cmdToExecute.Parameters.Add(new SqlParameter("Operated_By", SqlDbType.Int, 32, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Operated_By));
                //cmdToExecute.Parameters.Add(new SqlParameter("Operation_Date", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Operation_Date));


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

                if (objPurchaseRequisitionMaster_Property.DetailData != null)
                {
                    foreach (DataRow row in objPurchaseRequisitionMaster_Property.DetailData.Rows)
                        row["PurchaseMaster_Id"] = cmdToExecute.Parameters["@ID"].Value.ToString();

                    objPurchaseRequisitionMaster_Property.DetailData.AcceptChanges();

                    SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);
                    objPurchaseRequisitionMaster_Property.DetailData.TableName = "Purchase_Detail";

                    sbc.ColumnMappings.Clear();
                    sbc.ColumnMappings.Add("PurchaseMaster_Id", "PurchaseMaster_Id");
                    //sbc.ColumnMappings.Add(2, 1);
                    sbc.ColumnMappings.Add("Product_id", "Product_id");
                    sbc.ColumnMappings.Add("Rate", "Rate");
                    sbc.ColumnMappings.Add("Quantity", "Quantity");
                    sbc.ColumnMappings.Add("Pack_Unit_Id", "Pack_Unit_Id");
                    sbc.ColumnMappings.Add("TotalRate", "Total_Price");
                    sbc.ColumnMappings.Add("Product_Code", "Product_Code");
                    sbc.ColumnMappings.Add("Product", "Product_Name");
                    sbc.ColumnMappings.Add("Status", "Status");

                    sbc.ColumnMappings.Add("Department_Id", "Department_Id");
                    sbc.ColumnMappings.Add("Description", "Description");

                    sbc.DestinationTableName = objPurchaseRequisitionMaster_Property.DetailData.TableName;
                    sbc.WriteToServer(objPurchaseRequisitionMaster_Property.DetailData);

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
        public DataTable GetDocumentType()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetDocumentSetup]";
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
        public DataTable GetLocation()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[pr_LOCATIONS_SETUP_SelectAll]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Location");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, 0));

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
        public DataTable SelectAllPr()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetPR_SelectAll]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("Purchase_Master");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
               cmdToExecute.Parameters.Add(new SqlParameter("@fromdata", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.FromDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@todate", SqlDbType.DateTime, 8, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.ToDate));

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
        public DataTable GetDepartments()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_Getdepartments]";
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

        public DataTable GetPackingUnits()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetPACKINGUNITSETUP]";
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
        public string GetDocumentCode()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetDocumentCodeForPurchase]";
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
                foreach(DataRow dr in toReturn.Rows)
                {
                    Docno= dr["DocumentNo"].ToString();
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
        public DataSet GetPurchaseRequisitionById()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetPurchaseRequisitionById]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("TRANSACTION_MASTER_Detail");
            //DataTable toReturn = new DataTable("TRANSACTION_MASTER");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.ID));
               // cmdToExecute.Parameters.Add(new SqlParameter("@distributorId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Distributor_ID));

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
                //_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;
                //ObjTransactionMasterProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_MASTER_DETAIL_GetByTransactionMasterId' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TRANSACTION_MASTER::SelectAll::Error occured.", ex);
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
        public DataSet GetBulkPurchaseRequisitionById()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_GetBulkPurchaseRequisition]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            DataSet toReturn = new DataSet("TRANSACTION_MASTER_Detail");
            //DataTable toReturn = new DataTable("TRANSACTION_MASTER");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;
            cmdToExecute.CommandTimeout = 0;
            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.TempID));
                // cmdToExecute.Parameters.Add(new SqlParameter("@distributorId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, ObjTransactionMasterProperty.Distributor_ID));

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
                //_errorCode = (Int32)cmdToExecute.Parameters["@iErrorCode"].Value;
                //ObjTransactionMasterProperty.TotalRowsNum = Convert.ToInt32(cmdToExecute.Parameters["@TotalRowsNum"].Value);
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_MASTER_DETAIL_GetByTransactionMasterId' reported the ErrorCode: " + _errorCode);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TRANSACTION_MASTER::SelectAll::Error occured.", ex);
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
        public bool UpdatePurchaseRequisition()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_PurchaseRequisition_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                //Transaction_Master_Property objTransMaster = new Transaction_Master_Property();
                //objTransMaster.ID = ObjTransactionMasterProperty.ID;
                //objTransMaster.Distributor_ID = ObjTransactionMasterProperty.Distributor_ID;
                //Transaction_Master_DAL objTransaction_Master_DAL = new Transaction_Master_DAL(objTransMaster);

                //objTransMaster.ID = objTransaction_Master_DAL.GetGINIdByCMId();
                //if (objTransMaster.ID != 0)
                //{
                //    objTransMaster.Document_Date = SessionManager.CurrentUser.FinancialDate;
                //    objTransMaster.Flag = "DeAllocate";

                //    objTransaction_Master_DAL.AdjustTransactionalStock_SPOT();
                //}

                cmdToExecute.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Document_Id", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.DocumentId));
                cmdToExecute.Parameters.Add(new SqlParameter("@DocumentName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.DocumentName));
               // cmdToExecute.Parameters.Add(new SqlParameter("@DocumentDate", SqlDbType.DateTime, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.DocumentDateTime));
               // cmdToExecute.Parameters.Add(new SqlParameter("@DocumentNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.DocumentNo));

                cmdToExecute.Parameters.Add(new SqlParameter("@Narration", SqlDbType.NVarChar, 80, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.Narration));
                cmdToExecute.Parameters.Add(new SqlParameter("@LocationId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.LocationId));
                cmdToExecute.Parameters.Add(new SqlParameter("@TotalAmount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.TotalAmount));
                cmdToExecute.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 20, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.Status));
                cmdToExecute.Parameters.Add(new SqlParameter("@userid", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.UserId));
                cmdToExecute.Parameters.Add(new SqlParameter("@Posid", SqlDbType.Int, 4, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.PosID));
                cmdToExecute.Parameters.Add(new SqlParameter("@Discount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.Discount));
                cmdToExecute.Parameters.Add(new SqlParameter("@NetAmount", SqlDbType.Decimal, 9, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.NetAmount));
                cmdToExecute.Parameters.Add(new SqlParameter("@DeliveryDate", SqlDbType.DateTime, 50, ParameterDirection.Input, true, 18, 1, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.DeliveryDate));
                cmdToExecute.Parameters.Add(new SqlParameter("@Reference", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.Reference));
                cmdToExecute.Parameters.Add(new SqlParameter("@DocumentType", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.DocumentType));
                cmdToExecute.Parameters.Add(new SqlParameter("@IsActive", SqlDbType.Bit, 20, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.IsActive));
                //cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, "NULL"));

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
                this.StartTransaction();
                cmdToExecute.Transaction = this.Transaction;
                // Execute query.
                _rowsAffected = cmdToExecute.ExecuteNonQuery();


                if (objPurchaseRequisitionMaster_Property.DetailData != null)
                {
                    foreach (DataRow row in objPurchaseRequisitionMaster_Property.DetailData.Rows)
                        row["PurchaseMaster_Id"] = objPurchaseRequisitionMaster_Property.ID.ToString();//cmdToExecute.Parameters["@ID"].Value.ToString();

                    objPurchaseRequisitionMaster_Property.DetailData.AcceptChanges();

                    SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection, SqlBulkCopyOptions.Default, this.Transaction);
                    objPurchaseRequisitionMaster_Property.DetailData.TableName = "Purchase_Detail";

                    sbc.ColumnMappings.Clear();
                    sbc.ColumnMappings.Add("PurchaseMaster_Id", "PurchaseMaster_Id");
                    //sbc.ColumnMappings.Add(2, 1);
                    sbc.ColumnMappings.Add("Product_id", "Product_id");
                    sbc.ColumnMappings.Add("Rate", "Rate");
                    sbc.ColumnMappings.Add("Quantity", "Quantity");
                    sbc.ColumnMappings.Add("Pack_Unit_Id", "Pack_Unit_Id");
                    sbc.ColumnMappings.Add("TotalRate", "Total_Price");
                    sbc.ColumnMappings.Add("Product_Code", "Product_Code");
                    sbc.ColumnMappings.Add("Product", "Product_Name");
                    sbc.ColumnMappings.Add("Status", "Status");

                    sbc.ColumnMappings.Add("Department_Id", "Department_Id");
                    sbc.ColumnMappings.Add("Description", "Description");


                    sbc.DestinationTableName = objPurchaseRequisitionMaster_Property.DetailData.TableName;
                    sbc.WriteToServer(objPurchaseRequisitionMaster_Property.DetailData);

                }

               // _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;

                this.Commit();
                if (_errorCode != (int)LLBLError.AllOk)
                {
                    this.RollBack();
                    // Throw error.
                    throw new Exception("Stored Procedure 'sp_TRANSACTION_MASTER_Update' reported the ErrorCode: " + _errorCode);
                }

                return true;
            }
            catch (Exception ex)
            {
                // some error occured. Bubble it to caller and encapsulate Exception object
                throw new Exception("TRANSACTION_MASTER::Update::Error occured.", ex);
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
        public bool UpdateStatus()
        {
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "dbo.[sp_SSS_Status_Update]";
            cmdToExecute.CommandType = CommandType.StoredProcedure;

            // Use base class' connection object
            cmdToExecute.Connection = _mainConnection;

            try
            {
                cmdToExecute.Parameters.Add(new SqlParameter("@tableName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.TableName));
                cmdToExecute.Parameters.Add(new SqlParameter("@recordId", SqlDbType.Int, 32, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.ID));
                cmdToExecute.Parameters.Add(new SqlParameter("@operation", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, objPurchaseRequisitionMaster_Property.Status));
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
