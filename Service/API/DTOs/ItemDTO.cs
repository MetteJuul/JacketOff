using DataAccess;

namespace API.DTOs {
    public class ItemDTO {
        public int ID { get; set; }
        public string WardrobeID_FK { get; set; }
        public int TypeID_FK { get; set; }
    }
}
