using System;
namespace API.DTOs {
    public class WardrobeDTO {

        public string ID { get; set; }

        public int MaxAmountOfItems { get; set; }

        public int Count { get; set; }

        public byte[] RowID { get; set; }

        public int64 RowIDBig { get; set; }
    }
}
