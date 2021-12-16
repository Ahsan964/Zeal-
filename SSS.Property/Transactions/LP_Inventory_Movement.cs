using SSS.Property.Setups;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.Property.Transactions.ViewModels
{
    public class LP_Inventory_Movement
    {
        public int idx { get; set; }

        public int FromBranchId { get; set; }
        public int ToBranchId { get; set; }

        public int FromWareHouseId { get; set; }
        public int ToWareHouseID { get; set; }

        public int ProdductID { get; set; }

        public decimal Qty { get; set; }
        public decimal stock { get; set; }

        public int TransactionType { get; set; }

        public int Useridx { get; set; }
        public DateTime DateCreated { get; set; }
        public string Description { get; set; }

        public List<Product_Property> ProductList { get; set; }

        public List<WareHouse_Property> WareHouseList { get; set; }

        public List<Branch_Property> BranchList { get; set; }
        public List<LP_InventoryLogs_Property> InventoryLogs { get; set; }

        public DataTable DetailData{ get; set; }

        public string TableName { get; set; }
    }
}
