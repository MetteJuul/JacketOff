using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Exceptions {
    public class NoReservationFoundException : Exception {

        public NoReservationFoundException(string message, string identifier) : base(message){
        Identifier = identifier;
    }

        // prop for at vise eksempel
        public string Identifier { get; set; }
    }
}
