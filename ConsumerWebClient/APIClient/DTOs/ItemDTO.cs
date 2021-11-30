using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIClient.DTOs {
    internal class ItemDTO {
        public int ID { get; set; }
        public WardrobeDTO WardrobeDTO { get; set; }
        public ItemTypeDTO ItemTypeDTO { get; set; }
    }
}
