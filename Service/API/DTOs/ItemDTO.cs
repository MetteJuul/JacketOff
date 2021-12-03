using DataAccess;

namespace API.DTOs {
    public class ItemDTO {
        public int ID { get; set; }
        public WardrobeDTO wardrobeDTO { get; set; }
        public ItemTypeDTO itemTypeDTO { get; set; }
            
    }
}
