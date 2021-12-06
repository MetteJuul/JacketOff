using System;

namespace API.DTOs {
    public class WardrobeControlDTO {

        public string WardrobeID_FK { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }

        //public byte[] RowID { get; set; }
        public Int64 BigRowID { get; set; }
    }
}
