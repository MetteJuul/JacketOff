using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIClient.DTOs {
    public class ItemTypeDTO {

        public int ID { get; set; }
        public decimal Price { get; set; }  
        public string TypeName { get; set; }    
    }
}
