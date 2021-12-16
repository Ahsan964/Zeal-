using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.Property.Transactions
{
    public class LP_ImportedExpense_Master_Property
    {
        // Added By Ahsan
        public int PINO { get; set; }
        public int IEcheck { get; set; }
        public string poNumber { get; set; }
        public decimal expense { get; set; }
        public int numberOfProducts { get; set; }
        public decimal ExchangeRate { get; set; }
        public int glIdx { get; set; }
        public decimal qty { get; set; }
        public decimal amount { get; set; }
        public decimal unitPrice { get; set; }
        public decimal pricePerProduct { get; set; }
        public int itemIdx { get; set; }
        public decimal grandTotalAVPKR { get; set; }
        public int warehouseIdx { get; set; }
        public int branchIdx { get; set; }
        public List<LP_InventoryLogs_Property> inventory_logs_list { get; set; }
        public List<LP_ImportedExpense_Master_Property> tempList { get; set; }
     
        public int TransactionTypeID { get; set; }
        public int MasterID { get; set; }
        public int FullReturn { get; set; }
        public int BRANCHID { get; set; }


        public int idx { get; set; }
        public string ieNumber { get; set; }
        public int commercialIdx { get; set; }
        public string reference { get; set; }
        public string date { get; set; }
        public decimal totalExpense { get; set; }
        public string creationDate { get; set; }
        public int createdByUserIdx { get; set; }
        public int lastModifiedByUserIdx { get; set; }
        public string lastModificationDate { get; set; }
        public int visible { get; set; }
        public int status { get; set; }
        private DataTable _detail_data;
        public DataTable DetailData
        {
            get
            {
                return _detail_data;
            }
            set
            {
                _detail_data = value;
            }
        }

        // Added By Ahsan
        public DataTable DetailDataInventory_logs
        {
            get
            {
                return _detail_data;
            }
            set
            {
                _detail_data = value;
            }
        }

        private string _tableName;
        public String TableName
        {
            get
            {
                return _tableName;
            }
            set
            {
                _tableName = value;
            }
        }
        public decimal totalCost { get; set; }
        public decimal valueAdditionPercent { get; set; } //Default 30%
        public decimal valueAddition { get; set; }
        public decimal additionalSalesTaxPercent { get; set; } //Default 3%
        public decimal additionalSalesTax { get; set; }
        public decimal profitPercent { get; set; }
        public decimal profit { get; set; }
        public decimal grandTotalExpense { get; set; }
        public decimal finalPercentage { get; set; } //Added By Arsalan 14-04-21
    }
}
