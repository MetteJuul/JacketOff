using DataAccess;
using System;

namespace API.DTOs {
    public class ItemTypeDTO {

        public int TypeID { get; set; }
        public decimal Price { get; set; }
        public string TypeName { get; set; }

    }
}
