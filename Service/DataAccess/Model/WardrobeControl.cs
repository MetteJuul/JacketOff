using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model {
    public class WardrobeControl {
        public int WardrobeID_FK { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }
        public Int64 RowID { get; set; }
    }
}
