using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess {
    public class Item {
        public int ItemID { get; set; }
        public string WardrobeID_FK { get; set; }
        public int TypeID_FK { get; set; }

    }
}
