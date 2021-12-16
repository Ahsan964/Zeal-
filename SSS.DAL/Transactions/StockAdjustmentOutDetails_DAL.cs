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
using SSS.Property.Transactions;

namespace SSS.DAL.Transactions
{
    public class StockAdjustmentOutDetails_DAL : DBInteractionBase
    {
        SqlTransaction transaction;
        public bool Insert(DataTable detailsData)
        {
            try
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Open connection.
                    _mainConnection.Open();
                }

                transaction = _mainConnection.BeginTransaction();

                SqlBulkCopy sbc = new SqlBulkCopy(_mainConnection,SqlBulkCopyOptions.Default, transaction);
                sbc.DestinationTableName = detailsData.TableName;
                sbc.WriteToServer(detailsData);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return false;
            }
        }
    }
}
