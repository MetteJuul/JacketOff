using System;

namespace API.DTOs {
    public class WardrobeControlDTO {

        public int WardrobeID_FK { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }
        public Int64 RowID { get; set; }
    }
}
