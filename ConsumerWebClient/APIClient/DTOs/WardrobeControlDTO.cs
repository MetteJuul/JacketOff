using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace APIClient.DTOs {
    public class WardrobeControlDTO {
        public string WardrobeID_FK { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }
    }
}