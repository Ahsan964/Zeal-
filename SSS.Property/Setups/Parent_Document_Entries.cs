using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSS.Property.Setups
{
    [Serializable()]
    public class Parent_Document_Entries
    {
        public int ID { get; set; }
        public string Master_Table_ID { get; set; }

        public string Master_Table_Name { get; set; }

        public string Parent_Document_ID { get; set; }

        public string Document_Table_Name { get; set; }

    }
}
