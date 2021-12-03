using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerDesktopClient.DTOs {
    public class ItemDTO {
        public int ID { get; set; }
        public WardrobeDTO wardrobeDTO { get; set; }
        public ItemTypeDTO itemTypeDTO { get; set; }

    }
}
