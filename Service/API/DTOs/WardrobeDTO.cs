using System;
namespace API.DTOs {
    public class WardrobeDTO {

        public string ID { get; set; }

        public int MaxAmountOfItems { get; set; }

        public int Count { get; set; }

        public byte[] RowID { get; set; }

        public Int64 RowIDBig { get; set; }
    }
}
