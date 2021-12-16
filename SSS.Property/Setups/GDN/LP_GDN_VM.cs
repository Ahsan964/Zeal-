using SSS.Property.Transactions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups.GDN
{
   public class LP_GDN_VM
    {
        public string DriverAddress { get; set; }
        public string memo { get; set; }
        public string DriverName { get; set; }
        public string DriverCnic { get; set; }

        public int ID { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date_Created { get; set; }
        public int Doc_Type { get; set; }
        public string Doc_No { get; set; }
        public int Supplier_ID { get; set; }
        public string Supplier_Name { get; set; }
        public int Gatepass_Type_ID { get; set; }
        public int Gatepass_ID { get; set; }
        public string Driver_Name { get; set; }
        public string VehicleName { get; set; }
        public string Narration { get; set; }
        public string Ref1 { get; set; }
        public string Ref2 { get; set; }
        public string Ref3 { get; set; }
        public int Parent_DocID { get; set; }
        public string Status { get; set; }
        public int User_ID { get; set; }
        public decimal Total_Amount { get; set; }
        public int BRANCHID { get; set; }


        public List<LP_SalesOrder_Master_Property> SalesOrderList { get; set; }
        public List<LP_GDNDetail_Property> GDNDetailList { get; set; }

        public int Product_Id { get; set; }

        public int Quantity { get; set; }

        public decimal Rate { get; set; }

        public decimal TotalAmount { get; set; }
        public string itemName { get; set; }
        public decimal POQTY { get; set; }

        public decimal POUNITPRICE { get; set; }
        public decimal POAMOUNT { get; set; }

    }
}
