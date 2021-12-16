using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups
{
   public class LP_PageUser_Property
    {

        public int ID { get; set; }
        public int PageID { get; set; }
        public int UserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public bool status { get; set; }

        public List<LP_Pages_Property> PageList { get; set; }
        public List<User_Property> UserList { get; set; }

        public DataTable DetailData { get; set; }

        public string TableName { get; set; }

    }
}
