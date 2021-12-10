using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIClient.DTOs {
    public class ItemDTO {
        public int ID { get; set; }
        public string WardrobeID_FK { get; set; }
        public int TypeID_FK { get; set; }
    }
}
