using System;
using System.Collections.Generic;

#nullable disable

namespace Libraries.Model
{
    public partial class Guest
    {
        public int GuestId { get; set; }
        public string Email { get; set; }

        public virtual RegisteredGuest RegisteredGuest { get; set; }
    }
}
