using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerDesktopClient.DTOs {
    public class GuestDTO {
        public int GuestID { get; set; }
        public string Email { get; set; }

        public override string ToString() {
            return Email;
        }
    }
}
