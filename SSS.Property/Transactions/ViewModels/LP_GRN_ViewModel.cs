using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using SSS.Property.Setups;

namespace SSS.Property.Transactions.ViewModels
{
    public class LP_GRN_ViewModel
    {
        public List<LP_Performa_Invoice_Property> PerformaLISt { get; set; }
        public List<Branch_Property> BranchList { get; set; }
        public int branchIdx { get; set; }
        public int PINO { get; set; }
        public string poNumber { get; set; }
        public string grnNumber { get; set; }
        public decimal totalTD { get; set; }
        public decimal grandTotalExpense { get; set; }
        public decimal RetailPrice { get; set; }
        public int ID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date_Created { get; set; }
        [Required]
   
        public string Doc_No { get; set; }
        public int Supplier_ID { get; set; }
        public string Supplier_Name { get; set; }
        public int Gatepass_Type_ID { get; set; }
        public int Gatepass_ID { get; set; }
        public string Narration { get; set; }
        public string Ref1 { get; set; }
        public string Ref2 { get; set; }
        public string Ref3 { get; set; }
        
        [DataType(DataType.Date)]
        public int Parent_DocID { get; set; }
        public string Status { get; set; }
        public int User_ID { get; set; }
        public decimal Total_Amount { get; set; }
        public List<LP_Purchase_Master_Property> POList { get; set; }

        public List<LP_GRN_Detail_Property> GRNDeatilList { get; set; }

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
